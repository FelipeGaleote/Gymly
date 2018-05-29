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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;

        private string txtBoxTextoMedidaCM = "cm";

        public UserControlCadastroAvaliacaoFisicaProximaEtapa(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroTorax, txtBoxTextoMedidaCM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroQuadril, txtBoxTextoMedidaCM);
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPerimetroPernaE, "Esq. "+txtBoxTextoMedidaCM);
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

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Envergadura =  float.Parse(txtBoxEnvergadura.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroAbdominal = float.Parse(txtBoxPerimetroAbdominal.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroAntebracoDireito = float.Parse(txtBoxPerimetroAnteBracoD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroAntebracoEsquerdo = float.Parse(txtBoxPerimetroAnteBracoE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroBraçoDireito = float.Parse(txtBoxPerimetroBracoD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroBraçoEsquerdo = float.Parse(txtBoxPerimetroBracoE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCintura = float.Parse(txtBoxPerimetroCintura.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaDistalDireita = float.Parse(txtBoxPerimetroCoxaDistalD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaDistalEsquerda = float.Parse(txtBoxPerimetroCoxaDistalE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaMedialDireita = float.Parse(txtBoxPerimetroCoxaMedialD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaMedialEsquerda = float.Parse(txtBoxPerimetroCoxaMedialE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaProximalDireita = float.Parse(txtBoxPerimetroCoxaProximalD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroCoxaProximalEsquerda = float.Parse(txtBoxPerimetroCoxaProximalE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroOmbro = float.Parse(txtBoxPerimetroOmbro.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroPernaDireita = float.Parse(txtBoxPerimetroPernaD.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroPernaEsquerda = float.Parse(txtBoxPerimetroPernaE.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroQuadril = float.Parse(txtBoxPerimetroQuadril.Text.Replace(",", ".").Trim());
            avaliacaoFisica.PerimetroTorax = float.Parse(txtBoxPerimetroTorax.Text.Replace(",", ".").Trim());
            if (avaliacaoFisica.TipoDeAvaliacao == "Antropometria") {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Antropometria", avaliacaoFisica);
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia", avaliacaoFisica);
            }
        }

        private void TxtBoxPerimetroBracoD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroBracoD);
        }

        private void TxtBoxPerimetroBracoD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroBracoD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroAnteBracoD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroAnteBracoD);
        }

        private void TxtBoxPerimetroAnteBracoD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroAnteBracoD, "Dir. " + txtBoxTextoMedidaCM);

        }

        private void TxtBoxPerimetroCoxaProximalD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroCoxaProximalD);
        }

        private void TxtBoxPerimetroCoxaProximalD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaProximalD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaMedialD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroCoxaMedialD);
        }

        private void TxtBoxPerimetroCoxaMedialD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaMedialD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCoxaDistalD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroCoxaDistalD);
        }

        private void TxtBoxPerimetroCoxaDistalD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCoxaDistalD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroPernaD_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroPernaD);
        }

        private void TxtBoxPerimetroPernaD_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroPernaD, "Dir. " + txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroOmbro_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroOmbro);
        }

        private void TxtBoxPerimetroOmbro_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroOmbro, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroTorax_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroTorax);
        }

        private void TxtBoxPerimetroTorax_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroTorax, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroCintura_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroCintura);
        }

        private void TxtBoxPerimetroCintura_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroCintura, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroAbdominal_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroAbdominal);
        }

        private void TxtBoxPerimetroAbdominal_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroAbdominal, txtBoxTextoMedidaCM);
        }

        private void TxtBoxPerimetroQuadril_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroQuadril);
        }

        private void TxtBoxPerimetroQuadril_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroQuadril, txtBoxTextoMedidaCM);
        }

        private void TxtBoxEnvergadura_GotFocus(object sender, RoutedEventArgs e)
        {
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
            EditorTxtBox.GotFocus(txtBoxPerimetroBracoE);
        }

        private void TxtBoxPerimetroAnteBracoE_GotFocus(object sender, RoutedEventArgs e)
        {
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
            EditorTxtBox.GotFocus(txtBoxPerimetroCoxaProximalE);
        }

        private void TxtBoxPerimetroCoxaMedialE_GotFocus(object sender, RoutedEventArgs e)
        {
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
            EditorTxtBox.GotFocus(txtBoxPerimetroCoxaDistalE);
        }

        private void TxtBoxPerimetroPernaE_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxPerimetroPernaE);
        }

        private void TxtBoxPerimetroPernaE_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPerimetroPernaE, "Esq. " + txtBoxTextoMedidaCM);
        }
    }
}
