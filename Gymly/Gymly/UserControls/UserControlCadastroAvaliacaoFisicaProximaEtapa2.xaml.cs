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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa2.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa2 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa2(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.DobraCutaneaAbdominal = float.Parse(txtBoxDobraCutaneaAbdominal.Text);
            avaliacaoFisica.DobraCutaneaAxilarMedia = float.Parse(txtBoxDobraCutaneaAxilarMedia.Text);
            avaliacaoFisica.DobraCutaneaBiceps = float.Parse(txtBoxDobraCutaneaBiceps.Text);
            avaliacaoFisica.DobraCutaneaCoxa = float.Parse(txtBoxDobraCutaneaCoxa.Text);
            avaliacaoFisica.DobraCutaneaPerna = float.Parse(txtBoxDobraCutaneaPerna.Text);
            avaliacaoFisica.DobraCutaneaSubescapular = float.Parse(txtBoxDobraCutaneaSubescapular.Text);
            avaliacaoFisica.DobraCutaneaSuprailiaca = float.Parse(txtBoxDobraCutaneaSuprailiaca.Text);
            avaliacaoFisica.DobraCutaneaTorax = float.Parse(txtBoxDobraCutaneaTorax.Text);
            avaliacaoFisica.DobraCutaneaTriceps = float.Parse(txtBoxDobraCutaneaTriceps.Text);

            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa3", avaliacaoFisica);
        }
    }
}
