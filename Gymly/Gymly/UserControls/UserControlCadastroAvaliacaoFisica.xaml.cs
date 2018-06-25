using Gymly.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private StringBuilder erroBuilder;


        public UserControlCadastroAvaliacaoFisica(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica, string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            InitializeComponent();

           
            if (acao.Equals("Editar"))
            {
                Edicao();
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

        public void Edicao()
        {
            txtBoxAltura.Text = avaliacaoFisica.Altura.ToString();
            txtBoxMassa.Text = avaliacaoFisica.Massa.ToString();
            txtBoxPressaoArterialDiastolica.Text = avaliacaoFisica.PressaoArterialDiastolica.ToString();
            txtBoxPressaoArterialSistolica.Text = avaliacaoFisica.PressaoArterialSistolica.ToString();
            txtBoxFrenquenciaCardiaca.Text = avaliacaoFisica.FrequenciaCardiaca.ToString();

            if (avaliacaoFisica.QtdadeDiasDeTreino != null)
            {

                if (avaliacaoFisica.QtdadeDiasDeTreino.Equals("0-2 Dias"))
                {
                    rd0_2.IsChecked = true;
                }
                else if (avaliacaoFisica.QtdadeDiasDeTreino.Equals("3-5 Dias"))
                {
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

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            erroBuilder = new StringBuilder();

            if(txtBoxAltura.Text.Equals("cm") || txtBoxPressaoArterialDiastolica.Text.Equals("Diast. mmHg") ||
                txtBoxPressaoArterialSistolica.Text.Equals("Sist. mmHg") || txtBoxFrenquenciaCardiaca.Text.Equals("bpm") ||
                txtBoxMassa.Text.Equals("kg"))
            {
                exibeAviso();
                return;
            }

            avaliacaoFisica.Altura = ObtemValor(txtBoxAltura, "cm", avaliacaoFisica.Altura, "Altura");
            avaliacaoFisica.PressaoArterialDiastolica = ObtemValor(txtBoxPressaoArterialDiastolica, "Diast. mmHg", avaliacaoFisica.PressaoArterialDiastolica, "Pressão Arterial Diastolica");
            avaliacaoFisica.PressaoArterialSistolica = ObtemValor(txtBoxPressaoArterialSistolica, "Sist. mmHg", avaliacaoFisica.PressaoArterialSistolica, "Pressão Arterial Sistolica");
            avaliacaoFisica.FrequenciaCardiaca = ObtemValor(txtBoxFrenquenciaCardiaca, "bpm", avaliacaoFisica.FrequenciaCardiaca, "Frequência Cardíaca");
            avaliacaoFisica.Massa =  ObtemValor(txtBoxMassa, "kg", avaliacaoFisica.Massa, "Peso");

            if (rd0_2.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "0-2 Dias";
            }
            else if (rd3_5.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "3-5 Dias";
            }
            else if (rd6_7.IsChecked == true)
            {
                avaliacaoFisica.QtdadeDiasDeTreino = "6-7 Dias";
            }
            else
            {
                exibeAviso();
                return;
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
            else
            {
                exibeAviso();
                return;
            }

            if (erroBuilder.Length != 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(erroBuilder.ToString());
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa", avaliacaoFisica, acao);
            }

           


        }

        private void exibeAviso()
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("Preencha todos os campos para continuar!");
        }

        private float ObtemValor(TextBox txtBox, string hint, float valor, string nome)
        {
            try
            {
                if (!txtBox.Text.Equals(hint))
                    return float.Parse(txtBox.Text.Replace(".", ",").Trim());

                return valor;
            }
            catch (Exception)
            {
                erroBuilder.AppendLine(string.Format("Formato inválido para {0}.", nome));
                return valor;
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


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
           Regex regex = new Regex("[^0-9,.]+");
           e.Handled = regex.IsMatch(e.Text);
           
        }

    }
}
