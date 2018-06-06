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
using Gymly.Models;
using Gymly.BD;
using Xceed.Wpf.Toolkit;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAnamneseProximaEtapaFinal.xam
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapaFinal : UserControl
    {
        private MainWindow mainWindow;
        private Anamnese anamnese;
        private String txtBoxTextoObservacao = "Observação";
        public UserControlCadastroAnamneseProximaEtapaFinal(MainWindow mainWindow, Anamnese anamnese)
        {
            this.anamnese = anamnese;
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxObservacao.Clear();
            txtBoxObservacao.Foreground = Brushes.Black;
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxObservacao.Text == String.Empty)
            {
                txtBoxObservacao.Text = txtBoxTextoObservacao;
                txtBoxObservacao.Foreground = Brushes.Gray;
            }
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            anamnese.Observacao = txtBoxObservacao.Text;
            if (anamnese.CpfAluno != null && !anamnese.CpfAluno.Equals(""))
            {
                BDAnamnese.InsereAnamnese(anamnese, anamnese.CpfAluno);
                Xceed.Wpf.Toolkit.MessageBox.Show("Anamnese cadastrada com sucesso!", "Anamnese", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                mainWindow.MudarUserControl("aluno");
            } else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("CPF do aluno não pode ser nulo", "Anamnese", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
