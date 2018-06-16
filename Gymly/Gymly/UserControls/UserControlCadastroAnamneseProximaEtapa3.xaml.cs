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
    /// Interação lógica para UserControlCadastroAnamneseProximaEtapa3.xam
    /// </summary>
    public partial class UserControlCadastroAnamneseProximaEtapa3 : UserControl
    {
        private Anamnese anamnese;
        private MainWindow mainWindow;
        public UserControlCadastroAnamneseProximaEtapa3(MainWindow mainWindow, Anamnese anamnese)
        {
            this.anamnese = anamnese;
            this.mainWindow = mainWindow;
            InitializeComponent();
            checkBoxPerderPeso.IsChecked = anamnese.PerderPeso;
            checkBoxMelhorarFlexibilidade.IsChecked = anamnese.MelhorarFlexibilidade;
            checkBoxAptidaoCardiovascular.IsChecked = anamnese.MelhorarAptidao;
            checkBoxCondicaoMuscular.IsChecked = anamnese.MelhorarMuscular;
            checkBoxSentirMelhor.IsChecked = anamnese.SentirMelhor;
            checkBoxReduzirDores.IsChecked = anamnese.ReduzirDores;
            checkBoxReduzirEstresse.IsChecked = anamnese.ReduzirEstresse;
            checkBoxHipertrofia.IsChecked = anamnese.Hipertrofia;
            checkBoxMelhorarNutricao.IsChecked = anamnese.MelhorarNutricao;
            checkBoxDiminuirVicios.IsChecked = anamnese.DiminuirVicios;
        }

        private void BtnEtapa5_Click(object sender, RoutedEventArgs e)
        {
            anamnese.PerderPeso = checkBoxPerderPeso.IsChecked.Value;
            anamnese.MelhorarFlexibilidade = checkBoxMelhorarFlexibilidade.IsChecked.Value;
            anamnese.MelhorarAptidao = checkBoxAptidaoCardiovascular.IsChecked.Value;
            anamnese.MelhorarMuscular = checkBoxCondicaoMuscular.IsChecked.Value;
            anamnese.SentirMelhor = checkBoxSentirMelhor.IsChecked.Value;
            anamnese.ReduzirDores = checkBoxReduzirDores.IsChecked.Value;
            anamnese.ReduzirEstresse = checkBoxReduzirEstresse.IsChecked.Value;
            anamnese.Hipertrofia = checkBoxHipertrofia.IsChecked.Value;
            anamnese.MelhorarNutricao = checkBoxMelhorarNutricao.IsChecked.Value;
            anamnese.DiminuirVicios = checkBoxDiminuirVicios.IsChecked.Value;

            mainWindow.MudarUserControl("cadastroAnamneseProximaEtapaFinal", anamnese);
        }
    }
}
