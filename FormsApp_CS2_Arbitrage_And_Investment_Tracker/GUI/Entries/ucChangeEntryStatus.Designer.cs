namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries
{
    partial class ucChangeEntryStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(837, 279);
            dataGridView1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(342, 462);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(402, 444);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Status";
            // 
            // button1
            // 
            button1.Location = new Point(342, 503);
            button1.Name = "button1";
            button1.Size = new Size(190, 51);
            button1.TabIndex = 9;
            button1.Text = "Close the Entry";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(564, 503);
            button2.Name = "button2";
            button2.Size = new Size(190, 51);
            button2.TabIndex = 10;
            button2.Text = "Main App";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(395, 8);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 11;
            label2.Text = "Entry Manager";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(29, 321);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(190, 23);
            comboBox2.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(29, 350);
            button3.Name = "button3";
            button3.Size = new Size(190, 51);
            button3.TabIndex = 13;
            button3.Text = "Load the Entries";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(342, 418);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 23);
            dateTimePicker1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(402, 400);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 15;
            label3.Text = "Sell Time";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(342, 374);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(190, 23);
            numericUpDown1.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(402, 350);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 17;
            label4.Text = "Sell Price";
            // 
            // ucChangeEntryStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Salmon;
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(button3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "ucChangeEntryStatus";
            Size = new Size(900, 600);
            Load += ucChangeEntryStatus_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private ComboBox comboBox2;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label4;
    }
}
