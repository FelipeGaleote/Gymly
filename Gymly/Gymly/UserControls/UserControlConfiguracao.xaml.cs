using Gymly.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
            if (caminhoLogo != String.Empty)
            {
                GerenciadorDeArquivos.AlocaPasta("Academia");
                GerenciadorDeArquivos.AlocaPasta("Academia\\", "Logo");
                caminhoLogoSalvar = "Fotos\\Academia\\Logo\\logo" + GerenciadorDeArquivos.GetExtensao(caminhoLogo);
                if (File.Exists(caminhoLogoSalvar))
                {
                    GerenciadorDeArquivos.DeletaArquivo(GerenciadorDeArquivos.GetCaminho(caminhoLogoSalvar));
                    System.Windows.MessageBox.Show("Deletou");
                }
                GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoLogo, caminhoLogoSalvar);
                txtBoxcaminhoFoto.Text = caminhoLogoSalvar;
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
