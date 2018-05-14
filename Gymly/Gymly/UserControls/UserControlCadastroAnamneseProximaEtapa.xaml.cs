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
        }

        private void btnEtapa3_Click(object sender, RoutedEventArgs e)
        {
            anamnese.Doenca_cardiaca_coronariana = checkBoxDoencaCardiacaCoronariana.IsChecked.Value;
            anamnese.Doenca_cardiaca_reumatica = checkBoxDoencaCardiacaReumatica.IsChecked.Value;
            anamnese.Doenca_cardiaca_congenita = checkBoxDoencaCardiacaCongenita.IsChecked.Value;
            anamnese.Batimentos_cardiacos_irregulares = checkBoxBatimentimentoIrregular.IsChecked.Value;
            anamnese.Problema_valvulas_cardiacas = checkBoxProblemaValvulasCard.IsChecked.Value;
            anamnese.Murmurios_cardiacos = checkBoxMurmuriosCard.IsChecked.Value;
            anamnese.Ataque_cardiaco = checkBoxAtaqueCardiaco.IsChecked.Value;
            anamnese.Derrame_cerebral = checkBoxDerrameCerebral.IsChecked.Value;
            anamnese.Epilepsia = checkBoxEpilepsia.IsChecked.Value;
            anamnese.Diabetes = checkBoxDiabetes.IsChecked.Value;
            anamnese.Hipertensao = checkBoxHipertensao.IsChecked.Value;
            anamnese.Cancer = checkBoxCancer.IsChecked.Value;

            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapa2", anamnese);
        }
    }
}
