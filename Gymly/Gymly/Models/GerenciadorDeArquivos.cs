using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;

namespace Gymly.Models
{
    class GerenciadorDeArquivos
    {

        public static void DeletaArquivo(string caminho)
        {
            File.Delete(caminho);
        }

        public static int BuscaUltimaAvDoAluno(string cpf_aluno)
        {
            cpf_aluno = cpf_aluno.Replace(".", "").Replace("-", "");

            string[] listAv = Directory.GetDirectories(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Fotos\\" + cpf_aluno + "\\Avaliacoes");
            return (listAv.Length > 0) ?listAv.Length - 1:-1;
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
            
            

            string pasta = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString())+"\\" + Path.GetDirectoryName(caminhoDestino);
            string[] arquivos = Directory.GetFiles(pasta, "*.*", SearchOption.AllDirectories).ToArray();
            
            if (arquivos.Length > 0) {
                foreach (string a in arquivos) {
                    System.IO.File.OpenWrite(a).Close();
                    File.Delete(a);
                }
               
            }
           
            File.Copy(caminhoOrigem, caminhoDestino, true);
         
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
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(caminho);
            bitmap.EndInit();
            return bitmap;
          
        }

        public static BitmapImage BuscaImagem(string caminhoRelativo)
        {
           

            return new BitmapImage(new Uri(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\" + caminhoRelativo));
        }

        public static string BuscaLocalParaSalvarArquivo() {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF File|*.pdf",
                Title = "Salvar Relatório"
            };
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }

        public static string ConvertePdfParaXps(string caminhoPdf)
        {
            string caminhoXps = caminhoPdf.Replace(".pdf", ".xps");
            
            Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
            doc.LoadFromFile(caminhoPdf);
            doc.SaveToFile(caminhoXps, FileFormat.XPS);
            return caminhoXps;
        }
        public static FixedDocumentSequence AdicionaDocumentoParaVisualizacao(string caminhoPdf)
        {
            XpsDocument xpsDocument = new XpsDocument((ConvertePdfParaXps(caminhoPdf)), FileAccess.Read);
            FixedDocumentSequence fds = xpsDocument.GetFixedDocumentSequence();
            return fds;
        }

    }

}
