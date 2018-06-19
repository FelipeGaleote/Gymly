using Gymly.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa6.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa6 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoTempo = "Tempo(s)";
        private string txtBoxTextoDistancia = "Dist.(m)";
        private string txtBoxTextoQuantidade = "Repetição";
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa6(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica , string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;

            InitializeComponent();
            if (acao.Equals("Editar"))
            {
                txtBoxDistanciaCooper.Text = avaliacaoFisica.DistanciaCooper.ToString();
                txtBoxQtdadeAbdominal.Text = avaliacaoFisica.QtdadeAbdominais.ToString();
                txtBoxQtdadeFlexao.Text = avaliacaoFisica.QtdadeFlexao.ToString();
                txtBoxTempoFlexao.Text = avaliacaoFisica.TempoFlexao.ToString();
                txtBoxTempoAbdominal.Text = avaliacaoFisica.TempoAbdominal.ToString();

            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDistanciaCooper, txtBoxTextoDistancia);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeAbdominal, txtBoxTextoQuantidade);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeFlexao, txtBoxTextoQuantidade);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoFlexao, txtBoxTextoTempo);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoAbdominal, txtBoxTextoTempo);
            }
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            if(!txtBoxDistanciaCooper.Text.Equals("Dist.(m)"))
            avaliacaoFisica.DistanciaCooper = float.Parse(txtBoxDistanciaCooper.Text.Replace( ".",",").Trim());
            if (!txtBoxQtdadeAbdominal.Text.Equals("Repetição"))
                avaliacaoFisica.QtdadeAbdominais = int.Parse(txtBoxQtdadeAbdominal.Text.Trim());
            if (!txtBoxQtdadeFlexao.Text.Equals("Repetição"))
                avaliacaoFisica.QtdadeFlexao = int.Parse(txtBoxQtdadeFlexao.Text.Trim());
            if (!txtBoxTempoFlexao.Text.Equals("Tempo(s)"))
                avaliacaoFisica.TempoFlexao = float.Parse(txtBoxTempoFlexao.Text.Replace( ".",",").Trim());
            if (!txtBoxTempoAbdominal.Text.Equals("Tempo(s)"))
                avaliacaoFisica.TempoAbdominal = float.Parse(txtBoxTempoAbdominal.Text.Replace( ".",",").Trim());
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapaFinal", avaliacaoFisica,acao);
        }

        private void TxtBoxTempoFlexao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxTempoFlexao);
        }

        private void TxtBoxTempoFlexao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxTempoFlexao, txtBoxTextoTempo);
        }

        private void TxtBoxQtdadeFlexao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxQtdadeFlexao, txtBoxTextoQuantidade);
        }

        private void TxtBoxQtdadeFlexao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxQtdadeFlexao);
        }

        private void TxtBoxTempoAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxTempoAbdominal);
        }

        private void TxtBoxTempoAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxTempoAbdominal, txtBoxTextoTempo);
        }

        private void TxtBoxQtdadeAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxQtdadeAbdominal, txtBoxTextoQuantidade);
        }

        private void TxtBoxQtdadeAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxQtdadeAbdominal);
        }

        private void TxtBoxDistanciaCooper_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDistanciaCooper);
        }

        private void TxtBoxDistanciaCooper_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDistanciaCooper, txtBoxTextoDistancia);
        }
    }
}
