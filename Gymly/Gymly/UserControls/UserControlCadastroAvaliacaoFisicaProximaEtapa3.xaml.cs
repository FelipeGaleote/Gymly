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
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa3.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa3 : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa3(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
        }

        private void BtnAddFotoDeRosto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
