using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles
{
    public static class Styler
    {
        public static void StyleButton(Button btn, string text)
        {
            btn.Text = text;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(45, 45, 45);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 102, 184);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btn.Padding = new Padding(15, 8, 15, 8);
            btn.Cursor = Cursors.Hand;
        }
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 35;

            dgv.GridColor = Color.FromArgb(50, 50, 50);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }
    }
}
