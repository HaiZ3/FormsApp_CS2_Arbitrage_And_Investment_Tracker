namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp
{
    partial class ucMainApp
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
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(403, 23);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 0;
            label1.Text = "Main App";
            // 
            // button2
            // 
            button2.Location = new Point(254, 497);
            button2.Name = "button2";
            button2.Size = new Size(190, 63);
            button2.TabIndex = 2;
            button2.Text = "Load an existing sheet";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(27, 497);
            button3.Name = "button3";
            button3.Size = new Size(190, 63);
            button3.TabIndex = 3;
            button3.Text = "Create a new sheet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(837, 384);
            dataGridView1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(319, 468);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(471, 497);
            button1.Name = "button1";
            button1.Size = new Size(170, 63);
            button1.TabIndex = 6;
            button1.Text = "Add an entry";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(664, 497);
            button4.Name = "button4";
            button4.Size = new Size(170, 63);
            button4.TabIndex = 7;
            button4.Text = "Close an entry";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ucMainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Salmon;
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Name = "ucMainApp";
            Size = new Size(900, 600);
            Load += ucMainApp_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button4;
    }
}
