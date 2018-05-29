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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa4.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa4 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string caminhoFotoDeLado;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa4(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;

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
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa5", avaliacaoFisica);
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
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica);
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
