using Gymly.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisica.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisica : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string acao;
        private string txtBoxTextoMedida = "cm";
        private string txtBoxTextoMassa = "kg";
        private string txtBoxTextoPressao = "mmHg";
        private string txtBoxTextoFrequenciaCardiaca = "bpm";



        public UserControlCadastroAvaliacaoFisica(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica, string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            InitializeComponent();
            if (acao.Equals("Editar"))
            {
                txtBoxAltura.Text = avaliacaoFisica.Altura.ToString();
                txtBoxMassa.Text = avaliacaoFisica.Massa.ToString();
                txtBoxPressaoArterialDiastolica.Text = avaliacaoFisica.PressaoArterialDiastolica.ToString();
                txtBoxPressaoArterialSistolica.Text = avaliacaoFisica.PressaoArterialSistolica.ToString();
                txtBoxFrenquenciaCardiaca.Text = avaliacaoFisica.FrequenciaCardiaca.ToString();

                if (avaliacaoFisica.QtdadeDiasDeTreino != null)
                {

                    if (avaliacaoFisica.QtdadeDiasDeTreino.Equals("0-2 Dias")) {
                        rd0_2.IsChecked = true;
                    }
                    else if (avaliacaoFisica.QtdadeDiasDeTreino.Equals("3-5 Dias")) {
                        rd3_5.IsChecked = true;
                    }
                    else if (avaliacaoFisica.QtdadeDiasDeTreino.Equals("6-7 Dias"))
                    {
                        rd6_7.IsChecked = true;
                    }
                    
                }
                if (avaliacaoFisica.Flexibilidade != null)
                {

                    rdBom.IsChecked = avaliacaoFisica.Flexibilidade.Equals("Bom");
                    rdRegular.IsChecked = avaliacaoFisica.Flexibilidade.Equals("Regular");
                    rdRuim.IsChecked = avaliacaoFisica.Flexibilidade.Equals("Ruim");
                }
            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxAltura, txtBoxTextoMedida);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxMassa, txtBoxTextoMassa);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialDiastolica,
                    ("Diast. " + txtBoxTextoPressao));
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPressaoArterialSistolica,
                    ("Sist. " + txtBoxTextoPressao));
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);

            }
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            if(!txtBoxAltura.Text.Equals("cm")) 
                avaliacaoFisica.Altura =  float.Parse(txtBoxAltura.Text.Trim());
            if (!txtBoxPressaoArterialDiastolica.Text.Equals("Diast. mmHg"))
                avaliacaoFisica.PressaoArterialDiastolica = float.Parse(txtBoxPressaoArterialDiastolica.Text.Trim());
            if (!txtBoxPressaoArterialSistolica.Text.Equals("Sist. mmHg")) 
                avaliacaoFisica.PressaoArterialSistolica = float.Parse(txtBoxPressaoArterialSistolica.Text.Trim());
            if (!txtBoxFrenquenciaCardiaca.Text.Equals("bpm"))
                avaliacaoFisica.FrequenciaCardiaca = float.Parse(txtBoxFrenquenciaCardiaca.Text.Trim());
            if (!txtBoxMassa.Text.Equals("kg"))
                avaliacaoFisica.Massa = float.Parse(txtBoxMassa.Text.Trim());
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
            if(avaliacaoFisica.PressaoArterialSistolica == avaliacaoFisica.PressaoArterialDiastolica)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Valores de pressão arterial inválidos! Insira valores válidos.", "Pressão Arterial", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa", avaliacaoFisica, acao);
            }

            
        }

        private void TxtBoxAltura_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxAltura);
        }

        private void TxtBoxAltura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxAltura, txtBoxTextoMedida);
        }

        private void TxtBoxMassa_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxMassa);
        }

        private void TxtBoxMassa_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxMassa, txtBoxTextoMassa);
        }
        private void TxtBoxFrenquenciaCardiaca_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxFrenquenciaCardiaca);
        }

        private void TxtBoxFrenquenciaCardiaca_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxFrenquenciaCardiaca, txtBoxTextoFrequenciaCardiaca);
        }
        private void TxtBoxPressaoArterialDiastolica_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPressaoArterialDiastolica);
        }

        private void TxtBoxPressaoArterialDiastolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialDiastolica, ("Diast. "+txtBoxTextoPressao));
        }
        private void TxtBoxPressaoArterialSistolica_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPressaoArterialSistolica);
        }

        private void TxtBoxPressaoArterialSistolica_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPressaoArterialSistolica, ("Sist. "+ txtBoxTextoPressao));
        }

    }
}
