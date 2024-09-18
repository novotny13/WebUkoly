namespace CoffeeApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPeople = new System.Windows.Forms.Panel();
            this.panelSliders = new System.Windows.Forms.Panel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonShowStats = new System.Windows.Forms.Button();
            this.comboBoxMonths = new System.Windows.Forms.ComboBox();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.colDrinkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrinkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPeople
            // 
            this.panelPeople.AutoScroll = true;
            this.panelPeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPeople.Location = new System.Drawing.Point(12, 12);
            this.panelPeople.Name = "panelPeople";
            this.panelPeople.Size = new System.Drawing.Size(300, 150);
            this.panelPeople.TabIndex = 0;
            // 
            // panelSliders
            // 
            this.panelSliders.AutoScroll = true;
            this.panelSliders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSliders.Location = new System.Drawing.Point(12, 180);
            this.panelSliders.Name = "panelSliders";
            this.panelSliders.Size = new System.Drawing.Size(300, 200);
            this.panelSliders.TabIndex = 1;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(12, 400);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(150, 30);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonShowStats
            // 
            this.buttonShowStats.Location = new System.Drawing.Point(12, 440);
            this.buttonShowStats.Name = "buttonShowStats";
            this.buttonShowStats.Size = new System.Drawing.Size(150, 30);
            this.buttonShowStats.TabIndex = 3;
            this.buttonShowStats.Text = "Show Statistics";
            this.buttonShowStats.UseVisualStyleBackColor = true;
            this.buttonShowStats.Click += new System.EventHandler(this.buttonShowStats_Click);
            // 
            // comboBoxMonths
            // 
            this.comboBoxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonths.FormattingEnabled = true;
            this.comboBoxMonths.Items.AddRange(new object[] {
            "All",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonths.Location = new System.Drawing.Point(180, 445);
            this.comboBoxMonths.Name = "comboBoxMonths";
            this.comboBoxMonths.Size = new System.Drawing.Size(150, 21);
            this.comboBoxMonths.TabIndex = 4;
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AllowUserToAddRows = false;
            this.dataGridViewStats.AllowUserToDeleteRows = false;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDrinkName,
            this.colUserName,
            this.colDrinkCount});
            this.dataGridViewStats.Location = new System.Drawing.Point(330, 12);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.ReadOnly = true;
            this.dataGridViewStats.Size = new System.Drawing.Size(400, 458);
            this.dataGridViewStats.TabIndex = 5;
            // 
            // colDrinkName
            // 
            this.colDrinkName.HeaderText = "Drink Name";
            this.colDrinkName.Name = "colDrinkName";
            this.colDrinkName.ReadOnly = true;
            this.colDrinkName.Width = 120;
            // 
            // colUserName
            // 
            this.colUserName.HeaderText = "User Name";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 120;
            // 
            // colDrinkCount
            // 
            this.colDrinkCount.HeaderText = "Count";
            this.colDrinkCount.Name = "colDrinkCount";
            this.colDrinkCount.ReadOnly = true;
            this.colDrinkCount.Width = 60;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.comboBoxMonths);
            this.Controls.Add(this.buttonShowStats);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.panelSliders);
            this.Controls.Add(this.panelPeople);
            this.Name = "Form1";
            this.Text = "Coffee App";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPeople;
        private System.Windows.Forms.Panel panelSliders;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonShowStats;
        private System.Windows.Forms.ComboBox comboBoxMonths;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrinkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrinkCount;
    }
}
