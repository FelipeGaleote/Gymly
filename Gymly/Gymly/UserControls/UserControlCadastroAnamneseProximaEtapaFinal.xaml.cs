using Gymly.BD;
using Gymly.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            if (anamnese.Observacao != null && !anamnese.Observacao.Equals(""))
                txtBoxObservacao.Text = anamnese.Observacao;
            else
                MostraDica();

        }

        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxObservacao.Text.Equals("Observação"))
            {
                txtBoxObservacao.Clear();
                txtBoxObservacao.Foreground = Brushes.Black;
            }
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            MostraDica();
        }

        private void MostraDica()
        {
            if (txtBoxObservacao.Text == String.Empty)
            {
                txtBoxObservacao.Text = txtBoxTextoObservacao;
                txtBoxObservacao.Foreground = Brushes.Gray;
            }
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if(!txtBoxObservacao.Text.Equals("Observação"))
            anamnese.Observacao = txtBoxObservacao.Text;
            if (anamnese.CpfAluno != null && !anamnese.CpfAluno.Equals(""))
            {
                Anamnese an = BDAnamnese.SelecionaAnamnesePeloCpf(anamnese.CpfAluno);
                if (an.CpfAluno != null)
                {
                    BD.BDAnamnese.AtualizaAnamnese(anamnese);
                }
                else
                {
                    BDAnamnese.InsereAnamnese(anamnese, anamnese.CpfAluno);

                }
                Xceed.Wpf.Toolkit.MessageBox.Show("Anamnese cadastrada com sucesso!", "Anamnese", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                mainWindow.MudarUserControl("detalhesAluno", anamnese.CpfAluno);
            } else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("CPF do aluno não pode ser nulo", "Anamnese", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
