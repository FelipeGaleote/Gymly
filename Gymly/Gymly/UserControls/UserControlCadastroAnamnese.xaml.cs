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
        private Anamnese anamnese;
        public UserControlCadastroAnamnese(MainWindow mainWindow, Anamnese anamnese)
        {
            this.anamnese = anamnese;
            InitializeComponent();
            this.mainWindow = mainWindow;

            checkBoxProblemaCardiaco.IsChecked = anamnese.HistoricoProblemaCardiaco;
            checkBoxDoresNoPeito.IsChecked = anamnese.HistoricoDoresPeito;
            checkBoxDesmaia.IsChecked = anamnese.HistoricoDesmaiosOuVertigem;
            checkBoxPressaoAlta.IsChecked = anamnese.HistoricoPressaoAlta;
            checkBoxProblemaOsseo.IsChecked = anamnese.HistoricoProblemaOsseo;
            checkBoxIdosoNaoAcostumado.IsChecked = anamnese.IdosoNaoAcostumado;
        }

        private void BtnEtapa2_Click(object sender, RoutedEventArgs e)
        {
            anamnese.HistoricoProblemaCardiaco = checkBoxProblemaCardiaco.IsChecked.Value;
            anamnese.HistoricoDoresPeito = checkBoxDoresNoPeito.IsChecked.Value;
            anamnese.HistoricoDesmaiosOuVertigem = checkBoxDesmaia.IsChecked.Value;
            anamnese.HistoricoPressaoAlta = checkBoxPressaoAlta.IsChecked.Value;
            anamnese.HistoricoProblemaOsseo = checkBoxProblemaOsseo.IsChecked.Value;
            anamnese.IdosoNaoAcostumado = checkBoxIdosoNaoAcostumado.IsChecked.Value;

            mainWindow.MudarUserControl("cadastroAnamneseProximaEtapa", anamnese);
        }



    }
}
