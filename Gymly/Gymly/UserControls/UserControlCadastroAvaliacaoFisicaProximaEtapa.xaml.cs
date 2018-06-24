using System;
using System.Text.RegularExpressions;
using Gymly.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;

        private string txtBoxTextoMedidaCM = "cm";
        private string acao;
        private StringBuilder erroBuilder;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica , string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            InitializeComponent();

            if (acao.Equals("EditarAnterior"))
            {
                this.acao = "Cadastrar";
                Edicao();

            }
            else if (acao.Equals("Editar"))
            {
                Edicao();


            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroTorax, txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroQuadril, txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroPernaE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroPernaD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroOmbro, txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaProximalE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaProximalD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaMedialD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaMedialE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaDistalE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCoxaDistalD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroCintura, txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroBracoE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroBracoD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroAnteBracoE, "Esq. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroAnteBracoD, "Dir. " + txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroAbdominal, txtBoxTextoMedidaCM);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxEnvergadura, txtBoxTextoMedidaCM);
            }

        }

        public void Edicao()
        {
            txtBoxPerimetroTorax.Text = avaliacaoFisica.PerimetroTorax.ToString();
            txtBoxPerimetroQuadril.Text = avaliacaoFisica.PerimetroQuadril.ToString();
            txtBoxPerimetroPernaE.Text = avaliacaoFisica.PerimetroPernaEsquerda.ToString();
            txtBoxPerimetroPernaD.Text = avaliacaoFisica.PerimetroPernaDireita.ToString();
            txtBoxPerimetroOmbro.Text = avaliacaoFisica.PerimetroOmbro.ToString();
            txtBoxPerimetroCoxaProximalE.Text = avaliacaoFisica.PerimetroCoxaProximalEsquerda.ToString();
            txtBoxPerimetroCoxaProximalD.Text = avaliacaoFisica.PerimetroCoxaProximalDireita.ToString();
            txtBoxPerimetroCoxaMedialD.Text = avaliacaoFisica.PerimetroCoxaMedialDireita.ToString();
            txtBoxPerimetroCoxaMedialE.Text = avaliacaoFisica.PerimetroCoxaMedialEsquerda.ToString();
            txtBoxPerimetroCoxaDistalE.Text = avaliacaoFisica.PerimetroCoxaDistalEsquerda.ToString();
            txtBoxPerimetroCoxaDistalD.Text = avaliacaoFisica.PerimetroCoxaDistalDireita.ToString();
            txtBoxPerimetroCintura.Text = avaliacaoFisica.PerimetroCintura.ToString();
            txtBoxPerimetroBracoE.Text = avaliacaoFisica.PerimetroBracoEsquerdo.ToString();
            txtBoxPerimetroBracoD.Text = avaliacaoFisica.PerimetroBracoDireito.ToString();
            txtBoxPerimetroAnteBracoE.Text = avaliacaoFisica.PerimetroAntebracoEsquerdo.ToString();
            txtBoxPerimetroAnteBracoD.Text = avaliacaoFisica.PerimetroAntebracoDireito.ToString();
            txtBoxPerimetroAbdominal.Text = avaliacaoFisica.PerimetroAbdominal.ToString();
            txtBoxEnvergadura.Text = avaliacaoFisica.Envergadura.ToString();
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            this.erroBuilder = new StringBuilder();
            avaliacaoFisica.Envergadura = ObtemValor(txtBoxEnvergadura, "cm", avaliacaoFisica.Envergadura, "Envergadura");
            avaliacaoFisica.PerimetroAbdominal = ObtemValor(txtBoxPerimetroAbdominal, "cm", avaliacaoFisica.PerimetroAbdominal, "Perimetro Abdominal");
            avaliacaoFisica.PerimetroAntebracoDireito = ObtemValor(txtBoxPerimetroAnteBracoD, "Dir. cm", avaliacaoFisica.PerimetroAntebracoDireito, "Perimetro Antebraço Direito");
            avaliacaoFisica.PerimetroAntebracoEsquerdo = ObtemValor(txtBoxPerimetroAnteBracoE, "Esq. cm", avaliacaoFisica.PerimetroAntebracoEsquerdo, "Perimetro Antebraço Esquerdo");
            avaliacaoFisica.PerimetroBracoDireito = ObtemValor(txtBoxPerimetroBracoD, "Dir. cm", avaliacaoFisica.PerimetroBracoDireito, "Perimetro Braço Direito");
            avaliacaoFisica.PerimetroBracoEsquerdo = ObtemValor(txtBoxPerimetroBracoE, "Esq. cm", avaliacaoFisica.PerimetroBracoEsquerdo, "Perimetro Braço Esquerdo");
            avaliacaoFisica.PerimetroCintura = ObtemValor(txtBoxPerimetroCintura, "cm", avaliacaoFisica.PerimetroCintura, "Perimetro Cintura");
            avaliacaoFisica.PerimetroCoxaDistalDireita = ObtemValor(txtBoxPerimetroCoxaDistalD, "Dir. cm", avaliacaoFisica.PerimetroCoxaDistalDireita, "Perimetro Coxa Distal Direita");
            avaliacaoFisica.PerimetroCoxaDistalEsquerda = ObtemValor(txtBoxPerimetroCoxaDistalE, "Esq. cm", avaliacaoFisica.PerimetroCoxaDistalEsquerda, "Perimetro Coxa Distal Esquerda");
            avaliacaoFisica.PerimetroCoxaMedialDireita = ObtemValor(txtBoxPerimetroCoxaMedialD, "Dir. cm", avaliacaoFisica.PerimetroCoxaMedialDireita, "Perimetro Coxa Medial Direita");
            avaliacaoFisica.PerimetroCoxaMedialEsquerda = ObtemValor(txtBoxPerimetroCoxaMedialE, "Esq. cm", avaliacaoFisica.PerimetroCoxaMedialEsquerda, "Perimetro Coxa Medial Esquerda");
            avaliacaoFisica.PerimetroCoxaProximalDireita = ObtemValor(txtBoxPerimetroCoxaProximalD, "Dir. cm", avaliacaoFisica.PerimetroCoxaProximalDireita, "Perimetro Coxa Proximal Direita");
            avaliacaoFisica.PerimetroCoxaProximalEsquerda = ObtemValor(txtBoxPerimetroCoxaProximalE, "Esq. cm", avaliacaoFisica.PerimetroCoxaProximalEsquerda, "Perimetro Coxa Proximal Esquerda");
            avaliacaoFisica.PerimetroPernaDireita = ObtemValor(txtBoxPerimetroPernaD, "Dir. cm", avaliacaoFisica.PerimetroPernaDireita, "Perimetro Perna Direita");
            avaliacaoFisica.PerimetroPernaEsquerda = ObtemValor(txtBoxPerimetroPernaE, "Esq. cm", avaliacaoFisica.PerimetroPernaEsquerda, "Perimetro Perna Esquerda");
            avaliacaoFisica.PerimetroQuadril = ObtemValor(txtBoxPerimetroQuadril, "cm", avaliacaoFisica.PerimetroQuadril, "Perimetro Quadril");
            avaliacaoFisica.PerimetroTorax = ObtemValor(txtBoxEnvergadura, "cm", avaliacaoFisica.PerimetroTorax, "Perimetro Tórax");
            


            /*try
            {
                if (!txtBoxEnvergadura.Text.Equals("cm"))
                    avaliacaoFisica.Envergadura = float.Parse(txtBoxEnvergadura.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Envergadura.");
            }
            try
            {
                if (!txtBoxPerimetroAbdominal.Text.Equals("cm"))
                    avaliacaoFisica.PerimetroAbdominal =
                        float.Parse(txtBoxPerimetroAbdominal.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Perimetro Abdominal.");

            }
            try
            {
                if (!txtBoxPerimetroAnteBracoD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroAntebracoDireito =
                        float.Parse(txtBoxPerimetroAnteBracoD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro do Antebraço Direito.");
            }
            try
            {
                if (!txtBoxPerimetroAnteBracoE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroAntebracoEsquerdo =
                        float.Parse(txtBoxPerimetroAnteBracoE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Perimetro do Antebraço Esquerdo.");

            }
            try
            {
                if (!txtBoxPerimetroBracoD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroBracoDireito =
                        float.Parse(txtBoxPerimetroBracoD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Perimetro do Braço Direito.");

            }
            try
            {
                if (!txtBoxPerimetroBracoE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroBracoEsquerdo =
                        float.Parse(txtBoxPerimetroBracoE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Perimetro do Braço Esquerdo.");
            }
            try
            {
                if (!txtBoxPerimetroCintura.Text.Equals("cm"))
                    avaliacaoFisica.PerimetroCintura = float.Parse(txtBoxPerimetroCintura.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Cintura.");

            }
            try
            {
                if (!txtBoxPerimetroCoxaDistalD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroCoxaDistalDireita =
                        float.Parse(txtBoxPerimetroCoxaDistalD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Coxa Distal Direita.");

            }
            try
            {
                if (!txtBoxPerimetroCoxaDistalE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroCoxaDistalEsquerda =
                        float.Parse(txtBoxPerimetroCoxaDistalE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                Xceed.Wpf.Toolkit.MessageBox.Show("Formato inválido para Perimetro da Coxa Distal Esquerda.");

            }
            try
            {
                if (!txtBoxPerimetroCoxaMedialD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroCoxaMedialDireita =
                        float.Parse(txtBoxPerimetroCoxaMedialD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Coxa Medial Direita.");

            }

            try
            {
                if (!txtBoxPerimetroCoxaMedialE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroCoxaMedialEsquerda =
                        float.Parse(txtBoxPerimetroCoxaMedialE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Coxa Medial Esquerda.");
            }
            try
            {
                if (!txtBoxPerimetroCoxaProximalD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroCoxaProximalDireita =
                        float.Parse(txtBoxPerimetroCoxaProximalD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Coxa Proximal Direita.");
            }
            try
            {
                if (!txtBoxPerimetroCoxaProximalE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroCoxaProximalEsquerda =
                        float.Parse(txtBoxPerimetroCoxaProximalE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Coxa Proximal Esquerda.");

            }
            try
            {

            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro do Ombro.");

            }

            try
            {
                if (!txtBoxPerimetroPernaD.Text.Equals("Dir. cm"))
                    avaliacaoFisica.PerimetroPernaDireita =
                        float.Parse(txtBoxPerimetroPernaD.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {

                erroBuilder.AppendLine("Formato inválido para Perimetro da Panturrilha Direita.");
            }
            try
            {
                if (!txtBoxPerimetroPernaE.Text.Equals("Esq. cm"))
                    avaliacaoFisica.PerimetroPernaEsquerda =
                        float.Parse(txtBoxPerimetroPernaE.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro da Panturrilha Esquerda.");

            }
            try
            {
                if (!txtBoxPerimetroQuadril.Text.Equals("cm"))
                    avaliacaoFisica.PerimetroQuadril = float.Parse(txtBoxPerimetroQuadril.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
                erroBuilder.AppendLine("Formato inválido para Perimetro do Quadril.");

            }
            try
            {
                if (!txtBoxPerimetroTorax.Text.Equals("cm"))
                    avaliacaoFisica.PerimetroTorax = float.Parse(txtBoxPerimetroTorax.Text.Replace(".", ",").Trim());
            }
            catch (Exception)
            {
           erroBuilder.AppendLine("Formato inválido para Perimetro do Tórax.");
            }*/
            if (erroBuilder.Length != 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(erroBuilder.ToString());
            }
            else
            {
                if (avaliacaoFisica.TipoDeAvaliacao == "Antropometria")
                {
                    mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Antropometria", avaliacaoFisica,
                        acao);
                }
                else
                {
                    mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia", avaliacaoFisica,
                        acao);
                }


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

        private void TxtBoxPerimetroBracoD_GotFocus(object sender, RoutedEventArgs e)
        {
            if( !acao.Equals("Editar"))
            EditorTxtBox.GotFocus(txtBoxPerimetroBracoD);
        }

        private void TxtBoxPerimetroBracoD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroBracoD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroAnteBracoD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroAnteBracoD);
        }

        private void TxtBoxPerimetroAnteBracoD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroAnteBracoD, "Dir. " + txtBoxTextoMedidaCM);

        }

        private void TxtBoxPerimetroCoxaProximalD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaProximalD);
        }

        private void TxtBoxPerimetroCoxaProximalD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaProximalD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaMedialD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaMedialD);
        }

        private void TxtBoxPerimetroCoxaMedialD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaMedialD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaDistalD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaDistalD);
        }

        private void TxtBoxPerimetroCoxaDistalD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaDistalD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroPernaD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroPernaD);
        }

        private void TxtBoxPerimetroPernaD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroPernaD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroOmbro_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroOmbro);
        }

        private void TxtBoxPerimetroOmbro_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroOmbro, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroTorax_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroTorax);
        }

        private void TxtBoxPerimetroTorax_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroTorax, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCintura_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCintura);
        }

        private void TxtBoxPerimetroCintura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCintura, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroAbdominal);
        }

        private void TxtBoxPerimetroAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroAbdominal, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroQuadril_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroQuadril);
        }

        private void TxtBoxPerimetroQuadril_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroQuadril, txtBoxTextoMedidaCM);
        }

        private void TxtBoxEnvergadura_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxEnvergadura);
        }

        private void TxtBoxEnvergadura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxEnvergadura, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroBracoE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroBracoE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroBracoE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroBracoE);
        }

        private void TxtBoxPerimetroAnteBracoE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroAnteBracoE);
        }

        private void TxtBoxPerimetroAnteBracoE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroAnteBracoE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaProximalE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaProximalE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaProximalE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaProximalE);
        }

        private void TxtBoxPerimetroCoxaMedialE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaMedialE);

        }

        private void TxtBoxPerimetroCoxaMedialE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaMedialE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaDistalE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaDistalE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaDistalE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroCoxaDistalE);
        }

        private void TxtBoxPerimetroPernaE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPerimetroPernaE);
        }

        private void TxtBoxPerimetroPernaE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroPernaE, "Esq. " + txtBoxTextoMedidaCM);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

 
    }
}
