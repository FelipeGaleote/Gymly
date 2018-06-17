using Gymly.BD;
using Gymly.Models;
using System.Windows;
using System.Windows.Controls;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapaFinal.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapaFinal : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapaFinal(MainWindow mainWindow,
            AvaliacaoFisica avaliacaoFisica, string acao)
        {

            InitializeComponent();
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            if (acao.Equals("Editar"))
            {
                txtBoxObservacao.Text = avaliacaoFisica.Observacao;


            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
            }
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Observacao = txtBoxObservacao.Text.Trim();
            if (acao.Equals("Editar"))
            {
                BDAvaliacaoFisica.AtualizaAvaliacaoFisica(avaliacaoFisica);
            }
            else
            {
                BDAvaliacaoFisica.InsereAvaliacaoFisica(avaliacaoFisica);
             }
            
            //colocar um messagebox para perguntar se deseja imprimir a avaliação fisica ----
            mainWindow.MudarUserControl("aluno");
        }
        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }


    }
}
