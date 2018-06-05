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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapaFinal.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapaFinal : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        public UserControlCadastroAvaliacaoFisicaProximaEtapaFinal(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Observacao = txtBoxObservacao.Text.Trim();
            //BDAvaliacaoFisica.InsereAvaliacaoFisica(avaliacaoFisica);
            //colocar um messagebox para perguntar se deseja imprimir a avaliação fisica ----
            mainWindow.MudarUserControl("aluno");
        }
        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }


    }
}
