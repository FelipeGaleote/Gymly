using Gymly.BD;
using Gymly.Models;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapaFinal.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapaFinal : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapaFinal(MainWindow mainWindow,
            AvaliacaoFisica avaliacaoFisica, string acao)
        {

            InitializeComponent();
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            if (acao.Equals("Editar"))
            {
                txtBoxObservacao.Text = avaliacaoFisica.Observacao;


            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
            }
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {

           

            string cpf = avaliacaoFisica.CpfAluno.Replace(".","").Replace("-", "");

            int avNumero;
            GerenciadorDeArquivos.AlocaPasta(cpf + "\\Avaliacoes");
            avNumero = GerenciadorDeArquivos.BuscaUltimaAvDoAluno(avaliacaoFisica.CpfAluno) + 2;

            if (!acao.Equals("Editar"))
            {
                
                GerenciadorDeArquivos.AlocaPasta(cpf + "\\Avaliacoes\\" + avNumero);
                GerenciadorDeArquivos.AlocaPasta(cpf + "\\Avaliacoes\\" + avNumero + "\\" + "Frente");
                GerenciadorDeArquivos.AlocaPasta(cpf + "\\Avaliacoes\\" + avNumero + "\\" + "Lado");
                GerenciadorDeArquivos.AlocaPasta(cpf + "\\Avaliacoes\\" + avNumero + "\\" + "Costas");
            }
            string caminhoSalvarFoto;

            if (!avaliacaoFisica.CaminhoImagemFrontal.Equals("")) {
                caminhoSalvarFoto = "Fotos\\" + cpf  + "\\Avaliacoes\\" + ((acao.Equals("Editar"))?(avaliacaoFisica.Id):avNumero) + "\\Frente\\frente" + GerenciadorDeArquivos.GetExtensao(avaliacaoFisica.CaminhoImagemFrontal);
                if (!Path.GetFileNameWithoutExtension(avaliacaoFisica.CaminhoImagemFrontal).EndsWith(Path.GetFileNameWithoutExtension(caminhoSalvarFoto)))
                {
                    GerenciadorDeArquivos.MoveCopiaDeArquivo(avaliacaoFisica.CaminhoImagemFrontal, caminhoSalvarFoto);
                    avaliacaoFisica.CaminhoImagemFrontal = caminhoSalvarFoto;
                }
            }
            if (!avaliacaoFisica.CaminhoImagemLateral.Equals("")) {
                caminhoSalvarFoto = "Fotos\\" + cpf + "\\Avaliacoes\\" + ((acao.Equals("Editar")) ? (avaliacaoFisica.Id) : avNumero) + "\\Lado\\lateral" + GerenciadorDeArquivos.GetExtensao(avaliacaoFisica.CaminhoImagemLateral);
                if (!Path.GetFileNameWithoutExtension(avaliacaoFisica.CaminhoImagemLateral).EndsWith(Path.GetFileNameWithoutExtension(caminhoSalvarFoto)))
                { 
                    GerenciadorDeArquivos.MoveCopiaDeArquivo(avaliacaoFisica.CaminhoImagemLateral, caminhoSalvarFoto);
                    avaliacaoFisica.CaminhoImagemLateral = caminhoSalvarFoto;
                }
            }
            if (!avaliacaoFisica.CaminhoImagemCostas.Equals("")) {
                caminhoSalvarFoto = "Fotos\\" + cpf + "\\Avaliacoes\\" + ((acao.Equals("Editar")) ? (avaliacaoFisica.Id) : avNumero) + "\\Costas\\costas" + GerenciadorDeArquivos.GetExtensao(avaliacaoFisica.CaminhoImagemCostas);
                if (!Path.GetFileNameWithoutExtension(avaliacaoFisica.CaminhoImagemCostas).EndsWith(Path.GetFileNameWithoutExtension(caminhoSalvarFoto)))
                {
                    GerenciadorDeArquivos.MoveCopiaDeArquivo(avaliacaoFisica.CaminhoImagemCostas, caminhoSalvarFoto);
                    avaliacaoFisica.CaminhoImagemCostas = caminhoSalvarFoto;
                }
            }

           
            
            avaliacaoFisica.Observacao = txtBoxObservacao.Text.Trim();
            if (acao.Equals("Editar"))
            {
                BDAvaliacaoFisica.AtualizaAvaliacaoFisica(avaliacaoFisica);
            }
            else
            {
                BDAvaliacaoFisica.InsereAvaliacaoFisica(avaliacaoFisica);
            }
            System.Windows.MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Deseja Salvar?", "Salvar Avaliação Física", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result.ToString().ToUpper() == "YES")
            {
                string local = GerenciadorDeArquivos.BuscaLocalParaSalvarArquivo();
                Relatorio.GerarRelatorioDeAvaliacao(avaliacaoFisica.CpfAluno, local, avaliacaoFisica);
                mainWindow.MudarUserControl("visualizarAvaliacaoFisica", local);
            }
            else
            {
                mainWindow.MudarUserControl("aluno");
            }


            //colocar um messagebox para perguntar se deseja imprimir a avaliação fisica ----  
        }
        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }


    }
}
