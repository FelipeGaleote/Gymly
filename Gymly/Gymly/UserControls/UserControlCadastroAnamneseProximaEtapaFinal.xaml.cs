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
    /// Interação lógica para UserControlCadastroAnamneseProximaEtapaFinal.xam
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapaFinal : UserControl
    {
        private MainWindow mainWindow;
        private String txtBoxTextoObservacao = "Observação";
        public UserControlCadastroAnamneseProximaEtapaFinal(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void txtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxObservacao.Clear();
            txtBoxObservacao.Foreground = Brushes.Black;
        }

        private void txtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxObservacao.Text == String.Empty)
            {
                txtBoxObservacao.Text = txtBoxTextoObservacao;
                txtBoxObservacao.Foreground = Brushes.Gray;
            }
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            //Salvar no bd
            mainWindow.mudarUserControl("aluno");
        }
    }
}
