using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gymly.Models
{
    class EditorTxtBox
    {
        
        public static void AdicionaTextoInicialTxtBox(TextBox txtBox, string texto)
        {
            txtBox.Text = texto;
            txtBox.Foreground = Brushes.Gray;
        }

        public static void GotFocus(TextBox txtBox) {
            txtBox.Clear();
            txtBox.Foreground = Brushes.Black;
        }
        public static void LostFocus(TextBox txtBox, string texto) {
            if (txtBox.Text == String.Empty)
            {
                txtBox.Text = texto;
                txtBox.Foreground = Brushes.Gray;
            }
        }
    }
}
