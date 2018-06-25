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
    /// Interação lógica para UserControlVisualizaAvaliacaoFisica.xam
    /// </summary>
    public partial class UserControlVisualizaAvaliacaoFisica : UserControl
    {
        MainWindow mainWindow;
        private string caminho;
        public UserControlVisualizaAvaliacaoFisica(MainWindow mainWindow,string caminhoPdf)
        {
            caminho = caminhoPdf;
            this.mainWindow = mainWindow;
            InitializeComponent();
            docView.Document = GerenciadorDeArquivos.AdicionaDocumentoParaVisualizacao(caminhoPdf);
            
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.OpenWrite(caminho).Close();
            caminho = caminho.Replace(".pdf", "Xps.xps");
            //System.IO.File.OpenWrite(caminho).Close();

            GerenciadorDeArquivos.DeletaArquivo(caminho);

            mainWindow.MudarUserControl("aluno");
        }
    }
}
