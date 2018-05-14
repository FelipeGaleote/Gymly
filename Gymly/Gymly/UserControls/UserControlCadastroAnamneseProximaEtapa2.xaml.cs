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
        }

        private void btnEtapa4_Click(object sender, RoutedEventArgs e)
        {
            anamnese.Dor_costas = checkBoxDorNasCostas.IsChecked.Value;
            anamnese.Dor_articulacao = checkBoxDorNasArticulacoes.IsChecked.Value;
            anamnese.Dor_pulmonar = checkBoxDoencaPulmonar.IsChecked.Value;
            anamnese.Gestante = checkBoxGravida.IsChecked.Value;
            anamnese.Fumante = checkBoxFuma.IsChecked.Value;
            anamnese.Bebida_alcoolica = checkBoxBebidaAlcoolica.IsChecked.Value;

            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapa3", anamnese);
        }
    }
}
