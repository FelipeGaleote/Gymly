using Gymly.Models;
using System.Windows;
using System.Windows.Controls;

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
            av.TipoDeAvaliacao = "Antropometria";
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", av,"CADASTRAR");
        }

        private void Bioimpedancia_Click(object sender, RoutedEventArgs e)
        {
            av.TipoDeAvaliacao = "Bioimpedancia";
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", av,"CADASTRAR");
        }
    }
}
