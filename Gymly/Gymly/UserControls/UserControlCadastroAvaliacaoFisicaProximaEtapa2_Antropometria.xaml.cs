using System;
using System.Text;
using Gymly.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoMedidaMM = "mm";
        private string acao;
        private StringBuilder erroBuilder;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica , string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            InitializeComponent();
            if (acao.Equals("Editar"))
            {
                txtBoxDobraCutaneaAbdominal.Text = avaliacaoFisica.DobraCutaneaAbdominal.ToString();
                txtBoxDobraCutaneaAxilarMedia.Text = avaliacaoFisica.DobraCutaneaAxilarMedia.ToString();
                txtBoxDobraCutaneaBiceps.Text = avaliacaoFisica.DobraCutaneaBiceps.ToString();
                txtBoxDobraCutaneaCoxa.Text = avaliacaoFisica.DobraCutaneaCoxa.ToString();
                txtBoxDobraCutaneaPerna.Text = avaliacaoFisica.DobraCutaneaPerna.ToString();
                txtBoxDobraCutaneaSubescapular.Text = avaliacaoFisica.DobraCutaneaSubescapular.ToString();
                txtBoxDobraCutaneaSuprailiaca.Text = avaliacaoFisica.DobraCutaneaSuprailiaca.ToString();
                txtBoxDobraCutaneaTorax.Text = avaliacaoFisica.DobraCutaneaTorax.ToString();
                txtBoxDobraCutaneaTriceps.Text = avaliacaoFisica.DobraCutaneaTriceps.ToString();

            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaAbdominal, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaAxilarMedia, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaBiceps, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaCoxa, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaPerna, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaSubescapular, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaSuprailiaca, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaTorax, txtBoxTextoMedidaMM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDobraCutaneaTriceps, txtBoxTextoMedidaMM);
            }
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
             erroBuilder = new StringBuilder();

            avaliacaoFisica.DobraCutaneaAbdominal = ObtemValor(txtBoxDobraCutaneaAbdominal, "mm", avaliacaoFisica.DobraCutaneaAbdominal, "Dobra Cutânea Abdominal");
            avaliacaoFisica.DobraCutaneaAxilarMedia = ObtemValor(txtBoxDobraCutaneaAxilarMedia, "mm", avaliacaoFisica.DobraCutaneaAxilarMedia, "Dobra Cutânea Axilar Média");
            avaliacaoFisica.DobraCutaneaBiceps = ObtemValor(txtBoxDobraCutaneaBiceps, "mm", avaliacaoFisica.DobraCutaneaBiceps, "Dobra Cutânea Biceps");
            avaliacaoFisica.DobraCutaneaCoxa = ObtemValor(txtBoxDobraCutaneaCoxa, "mm", avaliacaoFisica.DobraCutaneaCoxa, "Dobra Cutânea Coxa");
            avaliacaoFisica.DobraCutaneaPerna = ObtemValor(txtBoxDobraCutaneaPerna, "mm", avaliacaoFisica.DobraCutaneaPerna, "Dobra Cutânea Perna");
            avaliacaoFisica.DobraCutaneaSubescapular = ObtemValor(txtBoxDobraCutaneaSubescapular, "mm", avaliacaoFisica.DobraCutaneaSubescapular, "Dobra Cutânea Subescapular");
            avaliacaoFisica.DobraCutaneaSuprailiaca = ObtemValor(txtBoxDobraCutaneaSuprailiaca, "mm", avaliacaoFisica.Envergadura, "Dobra Cutânea Supra-Ilíaca");
            avaliacaoFisica.DobraCutaneaTorax = ObtemValor(txtBoxDobraCutaneaTorax, "mm", avaliacaoFisica.DobraCutaneaTorax, "Dobra Cutânea Tórax");
            avaliacaoFisica.DobraCutaneaTriceps = ObtemValor(txtBoxDobraCutaneaTriceps, "mm", avaliacaoFisica.DobraCutaneaTriceps, "Dobra Cutânea Triceps");


            /*try
            {
                if (!txtBoxDobraCutaneaAbdominal.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaAbdominal = float.Parse(txtBoxDobraCutaneaAbdominal.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea Abdominal.");
            }
            try
            {
                if (!txtBoxDobraCutaneaAxilarMedia.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaAxilarMedia = float.Parse(txtBoxDobraCutaneaAxilarMedia.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea Axilar Media.");
           }

            try
            {
                if (!txtBoxDobraCutaneaBiceps.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaBiceps = float.Parse(txtBoxDobraCutaneaBiceps.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea do Biceps.");
            }
            try
            {
                if (!txtBoxDobraCutaneaCoxa.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaCoxa = float.Parse(txtBoxDobraCutaneaCoxa.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea da Coxa.");

            }
            try
            {
                if (!txtBoxDobraCutaneaPerna.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaPerna = float.Parse(txtBoxDobraCutaneaPerna.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea da Perna.");

            }
            try
            {
                if (!txtBoxDobraCutaneaSubescapular.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaSubescapular = float.Parse(txtBoxDobraCutaneaSubescapular.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea da Perna.");

            }

            try
            {
                if (!txtBoxDobraCutaneaSuprailiaca.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaSuprailiaca = float.Parse(txtBoxDobraCutaneaSuprailiaca.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea Supra-Ilíaca.");

            }
            try
            {
                if (!txtBoxDobraCutaneaTorax.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaTorax = float.Parse(txtBoxDobraCutaneaTorax.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea do Tórax.");

            }
            try
            {
                if (!txtBoxDobraCutaneaTriceps.Text.Equals("mm"))
                    avaliacaoFisica.DobraCutaneaTriceps = float.Parse(txtBoxDobraCutaneaTriceps.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Dobra Cutânea do Triceps.");

            }
            */

            if (erroBuilder.Length != 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(erroBuilder.ToString());
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa3", avaliacaoFisica, acao);
            }

      
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

        private void TxtBoxDobraCutaneaSubescapular_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaSubescapular);
        }

        private void TxtBoxDobraCutaneaSubescapular_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaSubescapular, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTriceps_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaTriceps, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTriceps_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaTriceps);
        }

        private void TxtBoxDobraCutaneaBiceps_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaBiceps);
        }

        private void TxtBoxDobraCutaneaBiceps_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaBiceps, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTorax_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaTorax, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaTorax_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaTorax);
        }

        private void TxtBoxDobraCutaneaAxilarMedia_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaAxilarMedia);
        }

        private void TxtBoxDobraCutaneaAxilarMedia_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaAxilarMedia, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaSuprailiaca_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaSuprailiaca, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaSuprailiaca_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaSuprailiaca);
        }

        private void TxtBoxDobraCutaneaAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaAbdominal);
        }

        private void TxtBoxDobraCutaneaAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaAbdominal, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaCoxa_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaCoxa, txtBoxTextoMedidaMM);
        }

        private void TxtBoxDobraCutaneaCoxa_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaCoxa);
        }

        private void TxtBoxDobraCutaneaPerna_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDobraCutaneaPerna);
        }

        private void TxtBoxDobraCutaneaPerna_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDobraCutaneaPerna, txtBoxTextoMedidaMM);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
