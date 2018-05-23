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

        public UserControlCadastroAvaliacaoFisicaProximaEtapa(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;

            InitializeComponent();
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.Envergadura =  float.Parse(txtBoxEnvergadura.Text);
            avaliacaoFisica.PerimetroAbdominal = float.Parse(txtBoxPerimetroAbdominal.Text);
            avaliacaoFisica.PerimetroAntebracoDireito = float.Parse(txtBoxPerimetroAnteBracoD.Text);
            avaliacaoFisica.PerimetroAntebracoEsquerdo = float.Parse(txtBoxPerimetroAnteBracoE.Text);
            avaliacaoFisica.PerimetroBraçoDireito = float.Parse(txtBoxPerimetroBracoD.Text);
            avaliacaoFisica.PerimetroBraçoEsquerdo = float.Parse(txtBoxPerimetroBracoE.Text);
            avaliacaoFisica.PerimetroCintura = float.Parse(txtBoxPerimetroCintura.Text);
            avaliacaoFisica.PerimetroCoxaDistalDireita = float.Parse(txtBoxPerimetroCoxaDistalD.Text);
            avaliacaoFisica.PerimetroCoxaDistalEsquerda = float.Parse(txtBoxPerimetroCoxaDistalE.Text);
            avaliacaoFisica.PerimetroCoxaMedialDireita = float.Parse(txtBoxPerimetroCoxaMedialD.Text);
            avaliacaoFisica.PerimetroCoxaMedialEsquerda = float.Parse(txtBoxPerimetroCoxaMedialE.Text);
            avaliacaoFisica.PerimetroCoxaProximalDireita = float.Parse(txtBoxPerimetroCoxaProximalD.Text);
            avaliacaoFisica.PerimetroCoxaProximalEsquerda = float.Parse(txtBoxPerimetroCoxaProximalE.Text);
            avaliacaoFisica.PerimetroOmbro = float.Parse(txtBoxPerimetroOmbro.Text);
            avaliacaoFisica.PerimetroPernaDireita = float.Parse(txtBoxPerimetroPernaD.Text);
            avaliacaoFisica.PerimetroPernaEsquerda = float.Parse(txtBoxPerimetroPernaE.Text);
            avaliacaoFisica.PerimetroQuadril = float.Parse(txtBoxPerimetroQuadril.Text);
            avaliacaoFisica.PerimetroTorax = float.Parse(txtBoxPerimetroTorax.Text);
            if (avaliacaoFisica.TipoDeAvaliacao == "Antropometria") {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Antropometria", avaliacaoFisica);
            }
            else
            {
                mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia", avaliacaoFisica);
            }
        }
    }
}
