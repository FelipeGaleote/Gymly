using Gymly.Models;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa3.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa3 : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string caminhoFotoDeFrente;
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa3(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica,string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            
            InitializeComponent();
   
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
            if (acao.Equals("Editar"))
            {
                preencheCampos();
            }

        }
        
        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            

            if (caminhoFotoDeFrente != null && !caminhoFotoDeFrente.Equals(""))
            {
                avaliacaoFisica.CaminhoImagemFrontal = caminhoFotoDeFrente;
            }
            else
            {
                avaliacaoFisica.CaminhoImagemFrontal = String.Empty;

            }
            if(txtBoxObservacao.Text != String.Empty)
            {
                avaliacaoFisica.ObservacaoImagemFrontal = txtBoxObservacao.Text;
            }
            
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa4", avaliacaoFisica,acao);
        }

        private void BtnPulaFotos_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.CaminhoImagemFrontal = String.Empty;
            avaliacaoFisica.ObservacaoImagemFrontal = String.Empty;
            avaliacaoFisica.CaminhoImagemCostas = String.Empty;
            avaliacaoFisica.ObservacaoImagemCostas = String.Empty;
            avaliacaoFisica.CaminhoImagemLateral = String.Empty;
            avaliacaoFisica.ObservacaoImagemLateral = String.Empty;
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica,acao);
        }

        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnAddFotoDeFrente_Click(object sender, RoutedEventArgs e)
        {
            caminhoFotoDeFrente = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeFrente != null && !caminhoFotoDeFrente.Equals(""))
            {
                ImageFotoDeFrente.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeFrente);
                btnAddFotoDeFrente.Background = System.Windows.Media.Brushes.Transparent;
                btnAddFotoDeFrente.BorderBrush = null;
            }
        }
        public void preencheCampos()
        {
            if (!avaliacaoFisica.CaminhoImagemFrontal.Equals("") && avaliacaoFisica.CaminhoImagemFrontal != null) { 
                ImageFotoDeFrente.Source = GerenciadorDeArquivos.BuscaImagem(avaliacaoFisica.CaminhoImagemFrontal);
                btnAddFotoDeFrente.Background = System.Windows.Media.Brushes.Transparent;
                btnAddFotoDeFrente.BorderBrush = null;
                caminhoFotoDeFrente = avaliacaoFisica.CaminhoImagemFrontal;
            }
            if(!avaliacaoFisica.ObservacaoImagemFrontal.Equals("") && avaliacaoFisica.ObservacaoImagemFrontal != null)
            {
                txtBoxObservacao.Text = avaliacaoFisica.ObservacaoImagemFrontal;
            }
        }
    }
}
