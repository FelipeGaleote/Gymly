using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAnamneseProximaEtapa2.xam
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapa2 : UserControl
    {
        private MainWindow mainWindow;
        public UserControlCadastroAnamneseProximaEtapa2(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void btnEtapa4_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapa3");
        }
    }
}
