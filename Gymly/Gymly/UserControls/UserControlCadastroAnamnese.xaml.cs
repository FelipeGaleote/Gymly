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
using Gymly.BD;
using Gymly.Models;
using Gymly.UserControls;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCadastroAnamnese.xaml
    /// </summary>
    public partial class UserControlCadastroAnamnese : UserControl
    {

        private MainWindow mainWindow;

        public UserControlCadastroAnamnese(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void btnEtapa2_Click(object sender, RoutedEventArgs e)
        {
            Anamnese anamnese = new Anamnese();
            anamnese.HistoricoProblemaCardiaco = checkBoxProblemaCardiaco.IsChecked.Value;
            anamnese.HistoricoDoresPeito = checkBoxDoresNoPeito.IsChecked.Value;
            anamnese.HistoricoDesmaiosOuVertigem = checkBoxDesmaia.IsChecked.Value;
            anamnese.HistoricoPressaoAlta = checkBoxPressaoAlta.IsChecked.Value;
            anamnese.HistoricoProblemaOsseo = checkBoxProblemaOsseo.IsChecked.Value;
            anamnese.IdosoNaoAcostumado = checkBoxIdosoNaoAcostumado.IsChecked.Value;

            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapa", anamnese);
        }



    }
}
