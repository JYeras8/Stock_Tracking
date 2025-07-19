using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracker
{
    public class General
    {
        public static bool isNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                return true;
            else
                return false;
        }
    


        public static void ApplyCMBUniversalStyle(ComboBox combo)
        {
            // Background color when enabled
            combo.BackColor = Color.Black; // Example black background

            // Foreground text color
            combo.ForeColor = Color.Lime; // Example green text

            // Dropdown style (Optional)
            combo.DropDownStyle = ComboBoxStyle.DropDownList; // Forces selection only

            // Flat style (Optional)
            combo.FlatStyle = FlatStyle.Flat;

            // Font (Optional)
            combo.Font = new Font("Silkscreen", 12, FontStyle.Bold);
        }

    

    


        public static void ApplyCMBDisabledStyle(ComboBox combo)
        {
            combo.BackColor = Color.DarkGray;
            combo.ForeColor = Color.WhiteSmoke;
            combo.Font = new Font("Silkscreen", 12, FontStyle.Bold);
        }

        public static void StyleDataGridView(DataGridView dgv) //style every data grid view.
        {
            //Colors
            dgv.BackgroundColor = Color.Black;
            dgv.ForeColor = Color.Lime;
            dgv.GridColor = Color.Green;
            dgv.DefaultCellStyle.BackColor = Color.Black;
            dgv.DefaultCellStyle.ForeColor = Color.Lime;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Lime;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set font on BOTH header and cells
            Font silkscreenFont = new Font("Silkscreen", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Font = silkscreenFont;
            dgv.DefaultCellStyle.Font = silkscreenFont;

            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
        }
    }


}
