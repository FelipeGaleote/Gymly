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
            anamnese.Historico_problema_cardiaco = checkBoxProblemaCardiaco.IsChecked.Value;
            anamnese.Historico_dores_peito = checkBoxDoresNoPeito.IsChecked.Value;
            anamnese.Historico_desmaios_ou_vertigem = checkBoxDesmaia.IsChecked.Value;
            anamnese.Historico_pressao_alta = checkBoxPressaoAlta.IsChecked.Value;
            anamnese.Historico_problema_osseo = checkBoxProblemaOsseo.IsChecked.Value;
            anamnese.Idoso_nao_acostumado = checkBoxIdosoNaoAcostumado.IsChecked.Value;

            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapa", anamnese);
        }



    }
}
