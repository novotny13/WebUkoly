namespace CoffeeList
{
    partial class Form1
    {
      
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            this.comboBoxPeople = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelCoffeeTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewStatistics = new System.Windows.Forms.DataGridView();
            this.labelPeople = new System.Windows.Forms.Label();
            this.labelCoffeeTypes = new System.Windows.Forms.Label();
            this.labelStatistics = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatistics)).BeginInit();
            this.SuspendLayout();
        
            this.comboBoxPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeople.FormattingEnabled = true;
            this.comboBoxPeople.Location = new System.Drawing.Point(12, 29);
            this.comboBoxPeople.Name = "comboBoxPeople";
            this.comboBoxPeople.Size = new System.Drawing.Size(258, 23);
            this.comboBoxPeople.TabIndex = 0;
        
            this.flowLayoutPanelCoffeeTypes.AutoScroll = true;
            this.flowLayoutPanelCoffeeTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelCoffeeTypes.Location = new System.Drawing.Point(12, 78);
            this.flowLayoutPanelCoffeeTypes.Name = "flowLayoutPanelCoffeeTypes";
            this.flowLayoutPanelCoffeeTypes.Size = new System.Drawing.Size(258, 150);
            this.flowLayoutPanelCoffeeTypes.TabIndex = 1;
        
            this.dataGridViewStatistics.AllowUserToAddRows = false;
            this.dataGridViewStatistics.AllowUserToDeleteRows = false;
            this.dataGridViewStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatistics.Location = new System.Drawing.Point(12, 257);
            this.dataGridViewStatistics.Name = "dataGridViewStatistics";
            this.dataGridViewStatistics.ReadOnly = true;
            this.dataGridViewStatistics.RowTemplate.Height = 25;
            this.dataGridViewStatistics.Size = new System.Drawing.Size(540, 150);
            this.dataGridViewStatistics.TabIndex = 2;
       
            this.labelPeople.AutoSize = true;
            this.labelPeople.Location = new System.Drawing.Point(12, 11);
            this.labelPeople.Name = "labelPeople";
            this.labelPeople.Size = new System.Drawing.Size(41, 15);
            this.labelPeople.TabIndex = 3;
            this.labelPeople.Text = "People";
          
            this.labelCoffeeTypes.AutoSize = true;
            this.labelCoffeeTypes.Location = new System.Drawing.Point(12, 60);
            this.labelCoffeeTypes.Name = "labelCoffeeTypes";
            this.labelCoffeeTypes.Size = new System.Drawing.Size(75, 15);
            this.labelCoffeeTypes.TabIndex = 4;
            this.labelCoffeeTypes.Text = "Coffee Types";
        
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Location = new System.Drawing.Point(12, 239);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(56, 15);
            this.labelStatistics.TabIndex = 5;
            this.labelStatistics.Text = "Statistics";
        
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 419);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.labelCoffeeTypes);
            this.Controls.Add(this.labelPeople);
            this.Controls.Add(this.dataGridViewStatistics);
            this.Controls.Add(this.flowLayoutPanelCoffeeTypes);
            this.Controls.Add(this.comboBoxPeople);
            this.Name = "Form1";
            this.Text = "Coffee List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPeople;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCoffeeTypes;
        private System.Windows.Forms.DataGridView dataGridViewStatistics;
        private System.Windows.Forms.Label labelPeople;
        private System.Windows.Forms.Label labelCoffeeTypes;
        private System.Windows.Forms.Label labelStatistics;
    }
}
