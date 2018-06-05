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
    /// Interação lógica para UserControlConfiguracao.xam
    /// </summary>
    public partial class UserControlConfiguracao : UserControl
    {
        private MainWindow mainWindow;
        private string caminhoLogo;
        private string caminhoLogoSalvar;
        public UserControlConfiguracao(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void AdicionarLogo_Click(object sender, RoutedEventArgs e)
        {
            caminhoLogo = GerenciadorDeArquivos.ProcuraImagem();
            GerenciadorDeArquivos.AlocaPasta("Config");
            GerenciadorDeArquivos.AlocaPasta("Config", "Logo");
            caminhoLogoSalvar = "Fotos\\Config\\Logo\\logo" + GerenciadorDeArquivos.GetExtensao(caminhoLogo);
            GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoLogo, caminhoLogoSalvar);
        }

        private void EmitirRelatorioAluno_Click(object sender, RoutedEventArgs e)
        {
            
            Relatorio.GeraRelatorioAlunos(GerenciadorDeArquivos.BuscaLocalParaSalvarArquivo());
        }
    }
}
