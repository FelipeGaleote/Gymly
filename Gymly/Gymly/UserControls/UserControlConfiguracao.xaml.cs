using Gymly.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlConfiguracao.xam
    /// </summary>
    public partial class UserControlConfiguracao : UserControl
    {
        private MainWindow mainWindow;
        private string caminhoLogoSalvar = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString())+ "\\Fotos\\Academia\\Logo\\logo"+ GerenciadorDeArquivos.GetExtensao("Fotos\\Academia\\Logo\\logo");

        public UserControlConfiguracao(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            
        }

        private void AdicionarLogo_Click(object sender, RoutedEventArgs e)
        {
            string caminhoLogo;
            caminhoLogo = GerenciadorDeArquivos.ProcuraImagem();
            if (caminhoLogo != String.Empty)
            {
                GerenciadorDeArquivos.AlocaPasta("Academia\\", "Logo");
                caminhoLogoSalvar = "Fotos\\Academia\\Logo\\logo" + GerenciadorDeArquivos.GetExtensao(caminhoLogo);
                GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoLogo, caminhoLogoSalvar);
                txtBoxcaminhoFoto.Text = caminhoLogoSalvar;
                Xceed.Wpf.Toolkit.MessageBox.Show("Logo adicionado com sucesso", "Logo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void EmitirRelatorioAluno_Click(object sender, RoutedEventArgs e)
        {
            string local = GerenciadorDeArquivos.BuscaLocalParaSalvarArquivo();

            if (!local.Equals(""))
            {
                Relatorio.GeraRelatorioAlunos(local);
            }
        }
    }
}
