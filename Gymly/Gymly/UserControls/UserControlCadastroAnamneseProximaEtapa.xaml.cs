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
    /// Interaction logic for UserControlCadastroAnamneseProximaEtapa.xaml
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapa : UserControl
    {
        private MainWindow mainWindow;
        private Anamnese anamnese;
        public UserControlCadastroAnamneseProximaEtapa(MainWindow mainWindow, Anamnese anamnese)
        {
            this.mainWindow = mainWindow;
            this.anamnese = anamnese;
            InitializeComponent();
            checkBoxDoencaCardiacaCoronariana.IsChecked = anamnese.DoencaCardiacaCoronariana;
            checkBoxDoencaCardiacaReumatica.IsChecked = anamnese.DoencaCardiacaReumatica;
            checkBoxDoencaCardiacaCongenita.IsChecked = anamnese.DoencaCardiacaCongenita;
            checkBoxBatimentimentoIrregular.IsChecked = anamnese.BatimentosCardiacosIrregulares;
            checkBoxProblemaValvulasCard.IsChecked = anamnese.ProblemaValvulasCardiacas;
            checkBoxMurmuriosCard.IsChecked = anamnese.MurmuriosCardiacos;
            checkBoxAtaqueCardiaco.IsChecked = anamnese.AtaqueCardiaco;
            checkBoxDerrameCerebral.IsChecked = anamnese.DerrameCerebral;
            checkBoxEpilepsia.IsChecked = anamnese.Epilepsia;
            checkBoxDiabetes.IsChecked = anamnese.Diabetes;
            checkBoxHipertensao.IsChecked = anamnese.Hipertensao;
            checkBoxCancer.IsChecked = anamnese.Cancer;
        }

        private void BtnEtapa3_Click(object sender, RoutedEventArgs e)
        {
            anamnese.DoencaCardiacaCoronariana = checkBoxDoencaCardiacaCoronariana.IsChecked.Value;
            anamnese.DoencaCardiacaReumatica = checkBoxDoencaCardiacaReumatica.IsChecked.Value;
            anamnese.DoencaCardiacaCongenita = checkBoxDoencaCardiacaCongenita.IsChecked.Value;
            anamnese.BatimentosCardiacosIrregulares = checkBoxBatimentimentoIrregular.IsChecked.Value;
            anamnese.ProblemaValvulasCardiacas = checkBoxProblemaValvulasCard.IsChecked.Value;
            anamnese.MurmuriosCardiacos = checkBoxMurmuriosCard.IsChecked.Value;
            anamnese.AtaqueCardiaco = checkBoxAtaqueCardiaco.IsChecked.Value;
            anamnese.DerrameCerebral = checkBoxDerrameCerebral.IsChecked.Value;
            anamnese.Epilepsia = checkBoxEpilepsia.IsChecked.Value;
            anamnese.Diabetes = checkBoxDiabetes.IsChecked.Value;
            anamnese.Hipertensao = checkBoxHipertensao.IsChecked.Value;
            anamnese.Cancer = checkBoxCancer.IsChecked.Value;

            mainWindow.MudarUserControl("cadastroAnamneseProximaEtapa2", anamnese);
        }
    }
}
