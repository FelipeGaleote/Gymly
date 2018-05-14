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
        }

        private void btnEtapa5_Click(object sender, RoutedEventArgs e)
        {
            anamnese.Perder_peso = checkBoxPerderPeso.IsChecked.Value;
            anamnese.Melhorar_flexibilidade = checkBoxMelhorarFlexibilidade.IsChecked.Value;
            anamnese.Melhorar_aptidao = checkBoxAptidaoCardiovascular.IsChecked.Value;
            anamnese.Melhorar_muscular = checkBoxCondicaoMuscular.IsChecked.Value;
            anamnese.Sentir_melhor = checkBoxSentirMelhor.IsChecked.Value;
            anamnese.Reduzir_dores = checkBoxReduzirDores.IsChecked.Value;
            anamnese.Reduzir_estresse = checkBoxReduzirEstresse.IsChecked.Value;
            anamnese.Hipertrofia = checkBoxHipertrofia.IsChecked.Value;
            anamnese.Melhorar_nutricao = checkBoxMelhorarNutricao.IsChecked.Value;
            anamnese.Diminuir_vicios = checkBoxDiminuirVicios.IsChecked.Value;

            mainWindow.mudarUserControl("cadastroAnamneseProximaEtapaFinal", anamnese);
        }
    }
}
