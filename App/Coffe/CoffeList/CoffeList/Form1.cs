using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private int _selectedUserId;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("coffee:kafe")));

            LoadPeopleList();
            LoadTypesList();
        }

        private async void LoadPeopleList()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://ajax1.lmsoft.cz/procedure.php?cmd=getPeopleList");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var people = JsonSerializer.Deserialize<dynamic>(json);

                foreach (var person in people)
                {
                    RadioButton rb = new RadioButton
                    {
                        Text = person.name,
                        Tag = person.ID,
                        AutoSize = true
                    };
                    rb.CheckedChanged += (s, e) => _selectedUserId = (int)((RadioButton)s).Tag;
                    panelPeople.Controls.Add(rb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading people list: " + ex.Message);
            }
        }

        private async void LoadTypesList()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://ajax1.lmsoft.cz/procedure.php?cmd=getTypesList");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var types = JsonSerializer.Deserialize<dynamic>(json);

                foreach (var type in types)
                {
                    TrackBar slider = new TrackBar
                    {
                        Minimum = 0,
                        Maximum = 10,
                        Tag = type.typ,
                        TickStyle = TickStyle.None,
                        Size = new System.Drawing.Size(200, 45)
                    };
                    Label sliderLabel = new Label { Text = $"{type.typ}: 0" };

                    slider.ValueChanged += (s, e) =>
                    {
                        sliderLabel.Text = $"{type.typ}: {slider.Value}";
                    };

                    panelSliders.Controls.Add(slider);
                    panelSliders.Controls.Add(sliderLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading coffee types: " + ex.Message);
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            var drinks = new dynamic[panelSliders.Controls.Count / 2];
            int i = 0;
            foreach (Control c in panelSliders.Controls)
            {
                if (c is TrackBar slider)
                {
                    drinks[i++] = new { typ = slider.Tag.ToString(), amount = slider.Value };
                }
            }

            var payload = new
            {
                userId = _selectedUserId,
                drinks = drinks
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://ajax1.lmsoft.cz/procedure.php?cmd=saveDrinks", content);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Data successfully submitted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting data: " + ex.Message);
            }
        }

        private async void buttonShowStats_Click(object sender, EventArgs e)
        {
            int monthId = comboBoxMonths.SelectedIndex; // 0 for all, 1 for January, etc.

            try
            {
                var response = await _httpClient.GetAsync($"http://ajax1.lmsoft.cz/procedure.php?cmd=getSummaryOfDrinks&month={monthId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var stats = JsonSerializer.Deserialize<dynamic>(json);

                dataGridViewStats.Rows.Clear();
                foreach (var stat in stats)
                {
                    dataGridViewStats.Rows.Add(stat[0], stat[2], stat[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }
    }
}
