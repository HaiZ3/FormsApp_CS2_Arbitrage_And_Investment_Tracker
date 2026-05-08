namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.CurrencyConverter
{
    partial class frmCurrencyConverter
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "USD", "CNY", "EUR" });
            comboBox1.Location = new Point(353, 185);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 23);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "USD", "CNY", "EUR" });
            comboBox2.Location = new Point(353, 297);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(190, 23);
            comboBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(401, 167);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 2;
            label1.Text = "From Currency";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(401, 279);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 3;
            label2.Text = "To Currency";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(353, 235);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(353, 346);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(190, 23);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(353, 395);
            button1.Name = "button1";
            button1.Size = new Size(190, 51);
            button1.TabIndex = 9;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(353, 469);
            button2.Name = "button2";
            button2.Size = new Size(190, 51);
            button2.TabIndex = 10;
            button2.Text = "Refresh Rates";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(353, 65);
            button3.Name = "button3";
            button3.Size = new Size(190, 51);
            button3.TabIndex = 11;
            button3.Text = "Close the Converter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // frmCurrencyConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Salmon;
            ClientSize = new Size(1034, 561);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Name = "frmCurrencyConverter";
            Text = "CurrencyConverter";
            Load += frmCurrencyConverter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}