using Gymly.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa4.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa4 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string caminhoFotoDeLado;
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa4(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica,string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;

            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            if (caminhoFotoDeLado != null && !caminhoFotoDeLado.Equals(""))
            {
                avaliacaoFisica.CaminhoImagemFrontal = caminhoFotoDeLado;
            }
            else
            {
                avaliacaoFisica.CaminhoImagemFrontal = String.Empty;

            }
            if (txtBoxObservacao.Text != String.Empty)
            {
                avaliacaoFisica.ObservacaoImagemFrontal = txtBoxObservacao.Text;
            }
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa5", avaliacaoFisica , acao);
        }
        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnPulaFotos_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.CaminhoImagemCostas = String.Empty;
            avaliacaoFisica.ObservacaoImagemCostas = String.Empty;
            avaliacaoFisica.CaminhoImagemLateral = String.Empty;
            avaliacaoFisica.ObservacaoImagemLateral = String.Empty;
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica,acao);
        }
        private void BtnAddFotoDeLado_Click(object sender, RoutedEventArgs e)
        {
            caminhoFotoDeLado = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeLado != null && !caminhoFotoDeLado.Equals(""))
            {
                ImageFotoDeLado.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeLado);
                btnAddFotoDeLado.Background = Brushes.Transparent;
                btnAddFotoDeLado.BorderBrush = null;
            }
        }
    }
}
