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
        private string txtBoxTextoMedida = "cm";
        private string txtBoxTextoMassa = "Kg";
        private string txtBoxTextoPressao = "mmHg";
        private string txtBoxTextoFrequenciaCardiaca = "bpm";



        public UserControlCadastroAvaliacaoFisica(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxAltura, txtBoxTextoMedida);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxMassa, txtBoxTextoMedida);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialDiastolica, ("Diast. " + txtBoxTextoPressao));
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialSistolica, ("Sist. " + txtBoxTextoPressao));
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);

        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Altura =  float.Parse(txtBoxAltura.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PressaoArterialDiastolica = float.Parse(txtBoxPressaoArterialDiastolica.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PressaoArterialSistolica = float.Parse(txtBoxPressaoArterialSistolica.Text.Replace(",", ".").Trim());
            avaliacaoFisica.FrequenciaCardiaca = float.Parse(txtBoxFrenquenciaCardiaca.Text.Replace(",", ".").Trim());
            avaliacaoFisica.Massa = float.Parse(txtBoxMassa.Text.Replace(",", ".").Trim());
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

        private void TxtBoxAltura_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxAltura);
        }

        private void TxtBoxAltura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxAltura, txtBoxTextoMedida);
        }

        private void TxtBoxMassa_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxMassa);
        }

        private void TxtBoxMassa_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxMassa, txtBoxTextoMassa);
        }
        private void TxtBoxFrenquenciaCardiaca_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxFrenquenciaCardiaca);
        }

        private void TxtBoxFrenquenciaCardiaca_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);
        }
        private void TxtBoxPressaoArterialDiastolica_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPressaoArterialDiastolica);
        }

        private void TxtBoxPressaoArterialDiastolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialDiastolica, ("Diast. "+txtBoxTextoPressao));
        }
        private void TxtBoxPressaoArterialSistolica_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPressaoArterialSistolica);
        }

        private void TxtBoxPressaoArterialSistolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialSistolica, ("Sist. "+ txtBoxTextoPressao));
        }

    }
}
