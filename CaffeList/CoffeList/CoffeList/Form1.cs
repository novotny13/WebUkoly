using CoffeeApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeList
{
    public partial class Form1 : Form
    {
        private HttpClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();

           
            LoadPeople();
            LoadCoffeeTypes();
            LoadStatistics(1); 
        }

        private async Task LoadPeople()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    var byteArray = Encoding.ASCII.GetBytes("Coffe:Kafe");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var jsonString = await client.GetStringAsync("http://ajax1.lmsoft.cz/procedure.php?cmd=getPeopleList");
                    var jsonDocument = JsonDocument.Parse(jsonString);
                    var peopleDict = jsonDocument.RootElement.EnumerateObject();
                   
                    comboBoxPeople.Items.Clear();

                    foreach (var person in peopleDict)
                    {
                        var personObj = person.Value;
                        string id = personObj.GetProperty("ID").GetString();
                        string name = personObj.GetProperty("name").GetString();

                        Console.WriteLine( id );
                        Console.WriteLine(name);

                        Person person1 = new Person(id,name);
                        comboBoxPeople.Items.Add( person1);
                      
                    }

                    if (comboBoxPeople.Items.Count > 0)
                        comboBoxPeople.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading people: {ex.Message}");
            }
        }


        private async Task LoadCoffeeTypes()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                   
                       var byteArray = Encoding.ASCII.GetBytes("Coffe:Kafe");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var jsonString = await client.GetStringAsync("http://ajax1.lmsoft.cz/procedure.php?cmd=getTypesList");
                    var jsonDocument = JsonDocument.Parse(jsonString);
                    var coffeeDict = jsonDocument.RootElement.EnumerateObject();

                    flowLayoutPanelCoffeeTypes.Controls.Clear();

                    foreach (var coffeeType in coffeeDict)
                    {
                        var coffeeObj = coffeeType.Value;
                        string id = coffeeObj.GetProperty("ID").GetString();
                        string type = coffeeObj.GetProperty("typ").GetString();

                      
                        Label coffeeLabel = new Label
                        {
                            Text = type,
                            Width = 100
                        };

                       
                        TrackBar slider = new TrackBar
                        {
                            Minimum = 0,
                            Maximum = 10,
                            Value = 0,
                            TickStyle = TickStyle.None,
                            Width = 200,
                            Tag = id 
                        };

                        
                        Label sliderValueLabel = new Label
                        {
                            Text = "0",
                            Width = 50
                        };

                      
                        slider.ValueChanged += (s, e) =>
                        {
                            sliderValueLabel.Text = slider.Value.ToString();
                        };

                     
                        flowLayoutPanelCoffeeTypes.Controls.Add(coffeeLabel);
                        flowLayoutPanelCoffeeTypes.Controls.Add(slider);
                        flowLayoutPanelCoffeeTypes.Controls.Add(sliderValueLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading coffee types: {ex.Message}");
            }
        }


        private async void LoadStatistics(int monthId)
        {
            try
            {
                string url = $"http://ajax1.lmsoft.cz/procedure.php?cmd=getSummaryOfDrinks&month={monthId}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                var byteArray = Encoding.ASCII.GetBytes("coffee:kafe");
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                var statisticsList = JsonSerializer.Deserialize<List<List<string>>>(jsonString);

                dataGridViewStatistics.Columns.Clear(); 
                dataGridViewStatistics.Rows.Clear();     

               
                dataGridViewStatistics.Columns.Add("Type", "Type");
                dataGridViewStatistics.Columns.Add("Count", "Count");
                dataGridViewStatistics.Columns.Add("Name", "Name");


                foreach (var stat in statisticsList)
                {
                    dataGridViewStatistics.Rows.Add(stat[0], stat[1], stat[2]);  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}");
            }
        }
    }
}
