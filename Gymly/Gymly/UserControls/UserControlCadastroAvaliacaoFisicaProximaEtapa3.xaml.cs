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

        public UserControlCadastroAvaliacaoFisicaProximaEtapa3(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
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
            
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa4", avaliacaoFisica);
        }

        private void BtnPulaFotos_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.CaminhoImagemFrontal = String.Empty;
            avaliacaoFisica.ObservacaoImagemFrontal = String.Empty;
            avaliacaoFisica.CaminhoImagemCostas = String.Empty;
            avaliacaoFisica.ObservacaoImagemCostas = String.Empty;
            avaliacaoFisica.CaminhoImagemLateral = String.Empty;
            avaliacaoFisica.ObservacaoImagemLateral = String.Empty;
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica);
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
                btnAddFotoDeFrente.Background = Brushes.Transparent;
                btnAddFotoDeFrente.BorderBrush = null;
            }
        }
    }
}
