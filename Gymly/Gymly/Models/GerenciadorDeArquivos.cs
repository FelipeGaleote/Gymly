using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Gymly.Models
{
    class GerenciadorDeArquivos
    {

        public static void DeletaArquivo(string caminho)
        {
            File.Delete(caminho);
        }

        public static void AlocaDiretorioPrincipal(string nome)
        {
            if (!File.Exists(nome))
            {
                Directory.CreateDirectory(nome);

            }
        }
        public static void AlocaPasta(string nomePasta)
        {
            if (!File.Exists("Fotos\\" + nomePasta))
            {
                Directory.CreateDirectory("Fotos\\" + nomePasta);

            }
        }
        public static void AlocaPasta(string pastaIntermediaria, string nomeDaPastaNova)
        {
            if (!File.Exists("Fotos\\" + pastaIntermediaria + "\\" + nomeDaPastaNova))
            {
                Directory.CreateDirectory("Fotos\\" + pastaIntermediaria + "\\" + nomeDaPastaNova);
            }
        }
        public static void MoveCopiaDeArquivo(string caminhoOrigem, string caminhoDestino)
        {
            File.Copy(caminhoOrigem, caminhoDestino);
        }
        public static string ProcuraImagem()
        {
            string nomeFoto=string.Empty;
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png |All Files (*.*)|*.*",
                RestoreDirectory = true,
                Multiselect = false
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nomeFoto = dlg.FileName;
              
            }
            return nomeFoto;
        }
        public static string GetExtensao(string caminho) {

            return Path.GetExtension(caminho);
        }
        public static string GetCaminho(string nome)
        {
            return Path.GetFileName(nome);
        }
        public static BitmapImage AdicionaImagem(string caminho) {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(caminho);
            bitmap.EndInit();
            return bitmap;
        }
        public static string BuscaLocalParaSalvarArquivo() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF File|*.pdf";
            saveFileDialog.Title = "Salvar Relatório";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }
    }
}
