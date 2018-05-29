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
    /// Interação lógica para UserControlCadastroAvaliacaoFisica.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisica : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoMedida = "Medida(Cm)";
        private string txtBoxTextoMassa = "Massa(Kg)";
        private string txtBoxTextoPressao = "Pressão(mmHg)";
        private string txtBoxTextoFrequenciaCardiaca = "Frequência(btm)";



        public UserControlCadastroAvaliacaoFisica(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxAltura, txtBoxTextoMedida);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxMassa, txtBoxTextoMedida);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialDiastolica, txtBoxTextoPressao);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialSistolica, txtBoxTextoPressao);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);

        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Altura =  float.Parse(txtBoxAltura.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PressaoArterialDiastolica = float.Parse(txtBoxPressaoArterialDiastolica.Text);
            avaliacaoFisica.PressaoArterialSistolica = float.Parse(txtBoxPressaoArterialSistolica.Text);
            avaliacaoFisica.FrequenciaCardiaca = float.Parse(txtBoxFrenquenciaCardiaca.Text);
            avaliacaoFisica.Massa = float.Parse(txtBoxMassa.Text);
            if (rd0_2.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "0-2 Dias";
            } else if(rd3_5.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "3-5 Dias";
            } else if (rd6_7.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "6-7 Dias";
            }

            if (rdBom.IsChecked == true)
            {
                avaliacaoFisica.Flexibilidade = "Bom";
            }
            else if (rdRegular.IsChecked == true)
            {
                avaliacaoFisica.Flexibilidade = "Regular";
            }
            else if (rdRuim.IsChecked == true)
            {
                avaliacaoFisica.Flexibilidade = "Ruim";
            }

            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa", avaliacaoFisica);
        }

        private void txtBoxAltura_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxAltura);
        }

        private void txtBoxAltura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxAltura, txtBoxTextoMedida);
        }

        private void txtBoxMassa_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxMassa);
        }

        private void txtBoxMassa_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxMassa, txtBoxTextoMassa);
        }
        private void txtBoxFrenquenciaCardiaca_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxFrenquenciaCardiaca);
        }

        private void txtBoxFrenquenciaCardiaca_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);
        }
        private void txtBoxPressaoArterialDiastolica_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPressaoArterialDiastolica);
        }

        private void txtBoxPressaoArterialDiastolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialDiastolica, txtBoxTextoPressao);
        }
        private void txtBoxPressaoArterialSistolica_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPressaoArterialSistolica);
        }

        private void txtBoxPressaoArterialSistolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialSistolica, txtBoxTextoPressao);
        }

    }
}
