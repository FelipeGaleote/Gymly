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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa6.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa6 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoTempo = "Tempo(s)";
        private string txtBoxTextoDistancia = "Dist.(m)";
        private string txtBoxTextoQuantidade = "Repetição";

        public UserControlCadastroAvaliacaoFisicaProximaEtapa6(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDistanciaCooper, txtBoxTextoDistancia);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeAbdominal, txtBoxTextoQuantidade);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeFlexao, txtBoxTextoQuantidade);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoFlexao, txtBoxTextoTempo);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoAbdominal, txtBoxTextoTempo);
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapaFInal");
        }

        private void TxtBoxTempoFlexao_GotFocus(object sender, RoutedEventArgs e)
        {
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
            EditorTxtBox.GotFocus(txtBoxQtdadeFlexao);
        }

        private void TxtBoxTempoAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
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
            EditorTxtBox.GotFocus(txtBoxQtdadeAbdominal);
        }

        private void TxtBoxDistanciaCooper_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxDistanciaCooper);
        }

        private void TxtBoxDistanciaCooper_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDistanciaCooper, txtBoxTextoDistancia);
        }
    }
}
