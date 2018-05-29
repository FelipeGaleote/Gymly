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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa5.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa5 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string caminhoFotoDeCostas;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa5(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            if (caminhoFotoDeCostas != null && !caminhoFotoDeCostas.Equals(""))
            {
                avaliacaoFisica.CaminhoImagemCostas = caminhoFotoDeCostas;
            }
            else
            {
                avaliacaoFisica.CaminhoImagemCostas = String.Empty;

            }
            if (txtBoxObservacao.Text != String.Empty)
            {
                avaliacaoFisica.CaminhoImagemCostas = txtBoxObservacao.Text;
            }

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

        private void BtnPulaFotos_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.CaminhoImagemCostas = String.Empty;
            avaliacaoFisica.ObservacaoImagemCostas = String.Empty;
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica);
        }
        private void BtnAddFotoDeCostas_Click(object sender, RoutedEventArgs e)
        {
            caminhoFotoDeCostas = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeCostas != null && !caminhoFotoDeCostas.Equals(""))
            {
                ImageFotoDeCostas.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeCostas);
                btnAddFotoDeCostas.Background = Brushes.Transparent;
                btnAddFotoDeCostas.BorderBrush = null;
            }
        }
    }
}
