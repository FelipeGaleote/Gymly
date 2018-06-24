using Gymly.Models;
using System.Windows;
using System.Windows.Controls;
using Gymly.BD;
using Xceed.Wpf.Toolkit;

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
            PreencheAvaliadores();
        }

        private void PreencheAvaliadores()
        {
            comboBoxNomeAvaliador.ItemsSource = BDAvaliador.SelecionaAvaliadores();
        }
        
        private void Antropometrica_Click(object sender, RoutedEventArgs e)
        {

            if (!comboBoxNomeAvaliador.SelectionBoxItem.ToString().Equals(""))
            {
               
                av.Avaliador = comboBoxNomeAvaliador.SelectionBoxItem.ToString();
                av.TipoDeAvaliacao = "Antropometria";
                mainWindow.MudarUserControl("cadastroAvaliacaoFisica", av, "CADASTRAR");
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Selecione um avaliador", "Avaliador", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        
        private void Bioimpedancia_Click(object sender, RoutedEventArgs e)
        {
            if (!comboBoxNomeAvaliador.SelectionBoxItem.ToString().Equals(""))
            {
                
                av.Avaliador = comboBoxNomeAvaliador.SelectionBoxItem.ToString();
                av.TipoDeAvaliacao = "Bioimpedancia";
                mainWindow.MudarUserControl("cadastroAvaliacaoFisica", av, "CADASTRAR");
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Selecione um avaliador", "Avaliador", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        
        
    }
}
