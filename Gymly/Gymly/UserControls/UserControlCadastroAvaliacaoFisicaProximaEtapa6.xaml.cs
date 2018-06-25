using System;
using Gymly.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;

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
        private string acao;
        private StringBuilder erroBuilder;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa6(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica , string acao)
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
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxDistanciaCooper, txtBoxTextoDistancia);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeAbdominal, txtBoxTextoQuantidade);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxQtdadeFlexao, txtBoxTextoQuantidade);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoFlexao, txtBoxTextoTempo);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTempoAbdominal, txtBoxTextoTempo);
            }
        }

        public void Edicao()
        {
            txtBoxDistanciaCooper.Text = avaliacaoFisica.DistanciaCooper.ToString();
            txtBoxQtdadeAbdominal.Text = avaliacaoFisica.QtdadeAbdominais.ToString();
            txtBoxQtdadeFlexao.Text = avaliacaoFisica.QtdadeFlexao.ToString();
            txtBoxTempoFlexao.Text = avaliacaoFisica.TempoFlexao.ToString();
            txtBoxTempoAbdominal.Text = avaliacaoFisica.TempoAbdominal.ToString();
            if (avaliacaoFisica.NivelFlexoes != null)
            {
                if (avaliacaoFisica.NivelFlexoes.Equals("Bom"))
                {
                    rdFBom.IsChecked = true;
                }
                else if (avaliacaoFisica.NivelFlexoes.Equals("Regular"))
                {
                    rdFRegular.IsChecked = true;
                }
                else if (avaliacaoFisica.NivelFlexoes.Equals("Ruim"))
                {
                    rdFRuim.IsChecked = true;
                }
            }
            if (avaliacaoFisica.NivelAbdominais != null)
            {
                if (avaliacaoFisica.NivelAbdominais.Equals("Bom"))
                {
                    rdABom.IsChecked = true;
                }
                else if (avaliacaoFisica.NivelAbdominais.Equals("Regular"))
                {
                    rdARegular.IsChecked = true;
                }
                else if (avaliacaoFisica.NivelAbdominais.Equals("Ruim"))
                {
                    rdARuim.IsChecked = true;
                }
            }
        }


        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
             erroBuilder = new StringBuilder();
            avaliacaoFisica.DistanciaCooper = ObtemValor(txtBoxDistanciaCooper, "Dist.(m)", avaliacaoFisica.DistanciaCooper, "Distância Cooper");
            
            avaliacaoFisica.TempoFlexao = ObtemValor(txtBoxTempoFlexao, "Tempo(s)", avaliacaoFisica.TempoFlexao, "Tempo Flexão");
            avaliacaoFisica.TempoAbdominal = ObtemValor(txtBoxTempoAbdominal, "Tempo(s)", avaliacaoFisica.TempoAbdominal, "Tempo Abdominal");


            /* try
             {
                 if (!txtBoxDistanciaCooper.Text.Equals("Dist.(m)"))
                     avaliacaoFisica.DistanciaCooper = float.Parse(txtBoxDistanciaCooper.Text.Replace(".", ",").Trim());
             }
             catch (Exception)
             {

                 erroBuilder.AppendLine("Formato inválido para Distância Cooper.");

             }*/
             try
             {
                 if (!txtBoxQtdadeAbdominal.Text.Equals("Repetição"))
                     avaliacaoFisica.QtdadeAbdominais = int.Parse(txtBoxQtdadeAbdominal.Text.Trim());

             }
             catch (Exception)
             {
                 erroBuilder.AppendLine("Formato inválido para Quantidade de Abdominais.");
             }

             try
             {
                 if (!txtBoxQtdadeFlexao.Text.Equals("Repetição"))
                     avaliacaoFisica.QtdadeFlexao = int.Parse(txtBoxQtdadeFlexao.Text.Trim());
             }
             catch (Exception)
             {
                 erroBuilder.AppendLine("Formato inválido para Quantidade de Flexão.");

             }
            /*
            
             try
             {
                 if (!txtBoxTempoFlexao.Text.Equals("Tempo(s)"))
                     avaliacaoFisica.TempoFlexao = float.Parse(txtBoxTempoFlexao.Text.Replace(".", ",").Trim());
             }
             catch (Exception)
             {
                 erroBuilder.AppendLine("Formato inválido para Tempo de Flexão.");

             }
             try
             {
                 if (!txtBoxTempoAbdominal.Text.Equals("Tempo(s)"))
                     avaliacaoFisica.TempoAbdominal = float.Parse(txtBoxTempoAbdominal.Text.Replace(".", ",").Trim());
             }
             catch (Exception)
             {
                 erroBuilder.AppendLine("Formato inválido para Tempo de Abdominal.");

             }
        */



            if (rdFBom.IsChecked == true)
            {
                avaliacaoFisica.NivelFlexoes = "Bom";
            }
            else if (rdFRegular.IsChecked == true)
            {
                avaliacaoFisica.NivelFlexoes = "Regular";
            }
            else if (rdFRuim.IsChecked == true)
            {
                avaliacaoFisica.NivelFlexoes = "Ruim";
            }

            if (rdABom.IsChecked == true)
            {
                avaliacaoFisica.NivelAbdominais = "Bom";
            }
            else if (rdARegular.IsChecked == true)
            {
                avaliacaoFisica.NivelAbdominais = "Regular";
            }
            else if (rdARuim.IsChecked == true)
            {
                avaliacaoFisica.NivelAbdominais = "Ruim";
            }
            if (erroBuilder.Length != 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(erroBuilder.ToString());
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapaFinal", avaliacaoFisica, acao);
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
        private void TxtBoxTempoFlexao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
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
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxQtdadeFlexao);
        }

        private void TxtBoxTempoAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
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
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxQtdadeAbdominal);
        }

        private void TxtBoxDistanciaCooper_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxDistanciaCooper);
        }

        private void TxtBoxDistanciaCooper_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxDistanciaCooper, txtBoxTextoDistancia);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
