using Gymly.Models;
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

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlTipoAnamnese.xam
    /// </summary>
    public partial class UserControlTipoAvaliacaoFisica : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica av;
        public UserControlTipoAvaliacaoFisica()
        {
            InitializeComponent();
        }
        public UserControlTipoAvaliacaoFisica(MainWindow mainWindow, AvaliacaoFisica av )
        {
            this.mainWindow = mainWindow;
            this.av = av;
            InitializeComponent();
        }

        private void Antropometrica_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica
            {
                TipoDeAvaliacao = "Antropometria"
            };
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", avaliacaoFisica);
        }

        private void Bioimpedancia_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica
            {
                TipoDeAvaliacao = "Bioimpedancia"
            };
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", avaliacaoFisica);
        }
    }
}
