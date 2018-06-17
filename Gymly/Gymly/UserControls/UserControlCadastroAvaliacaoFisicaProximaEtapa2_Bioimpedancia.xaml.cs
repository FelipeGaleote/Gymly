using Gymly.Models;
using System.Windows.Controls;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        public UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica,string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
        }
    }
}
