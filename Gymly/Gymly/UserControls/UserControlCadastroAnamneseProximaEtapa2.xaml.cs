using Gymly.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAnamneseProximaEtapa2.xam
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapa2 : UserControl
    {
        private Anamnese anamnese; 
        private MainWindow mainWindow;
        public UserControlCadastroAnamneseProximaEtapa2(MainWindow mainWindow, Anamnese anamnese)
        {
            this.anamnese = anamnese;
            this.mainWindow = mainWindow;
            InitializeComponent();
            checkBoxDorNasCostas.IsChecked = anamnese.DorCostas;
            checkBoxDorNasArticulacoes.IsChecked = anamnese.DorArticulacao;
            checkBoxDoencaPulmonar.IsChecked = anamnese.DorPulmonar;
            checkBoxGravida.IsChecked = anamnese.Gestante;
            checkBoxFuma.IsChecked = anamnese.Fumante;
            checkBoxBebidaAlcoolica.IsChecked = anamnese.BebidaAlcoolica;
        }

        private void BtnEtapa4_Click(object sender, RoutedEventArgs e)
        {
            anamnese.DorCostas = checkBoxDorNasCostas.IsChecked.Value;
            anamnese.DorArticulacao = checkBoxDorNasArticulacoes.IsChecked.Value;
            anamnese.DorPulmonar = checkBoxDoencaPulmonar.IsChecked.Value;
            anamnese.Gestante = checkBoxGravida.IsChecked.Value;
            anamnese.Fumante = checkBoxFuma.IsChecked.Value;
            anamnese.BebidaAlcoolica = checkBoxBebidaAlcoolica.IsChecked.Value;

            mainWindow.MudarUserControl("cadastroAnamneseProximaEtapa3", anamnese);
        }
    }
}
