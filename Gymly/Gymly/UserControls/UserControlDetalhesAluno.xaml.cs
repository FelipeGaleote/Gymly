using Gymly.BD;
using Gymly.Models;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlDetalhesAluno.xam
    /// </summary>
    public partial class UserControlDetalhesAluno : UserControl
    {
        private MainWindow mainWindow;
        private Aluno aluno;
        public UserControlDetalhesAluno()
        {
            InitializeComponent();


        }
        public UserControlDetalhesAluno(string cpf, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            PreencherInformacoes(cpf);
            ConfigurarBotoes(cpf);          
        }

        private void PreencherInformacoes(string cpf)
        {
            Aluno aluno = new Aluno();
            aluno = BDAluno.SelecionaAlunoPorCpf(cpf);
            if (aluno != null)
            {
                txtBlockNome.Text = aluno.Nome;
                txtBlockCpf.Text = aluno.Cpf;
                txtBlockEmail.Text = aluno.Email;
                txtBlockTelefone.Text = aluno.Telefone;
                txtBlockNivel.Text = aluno.Nivel;
                txtBlockSexo.Text = aluno.Sexo.ToString().Equals("F")? "Feminino" : "Masculino";
                if (!aluno.CaminhoFotoDoRosto.Equals(""))
                {

                    imageFotoDeRosto.Source = GerenciadorDeArquivos.BuscaImagem(aluno.CaminhoFotoDoRosto);
                }
                  
                this.aluno = aluno;
            }

        }
        private void ConfigurarBotoes(string cpf)
        {
            Anamnese anamnese = BDAnamnese.SelecionaAnamnesePeloCpf(cpf);
            if (anamnese.CpfAluno != null)
            {
                btnCadastrarAnamnese.Content = "Editar anamnese";
                this.aluno.Anamnese = anamnese;
            }
            else
            {
                Anamnese an = new Anamnese
                {
                    CpfAluno = this.aluno.Cpf
                };
                this.aluno.Anamnese = an;
                btnCadastrarAnamnese.Content = "Cadastrar anamnese";
            }
        }

        private void BtnCadastrarAnamnese_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("cadastroAnamnese", this.aluno.Anamnese);
            /*if (this.aluno.Anamnese == null)
            {
                Anamnese an = new Anamnese
                {
                    CpfAluno = this.aluno.Cpf
                };
                mainWindow.MudarUserControl("cadastroAnamnese", an);
            }
            else
            {
                //O aluno deve ser direcionado para uma tela de edição da anamnese
            }
            */
        }

        private void BtnCadastrarAvaliacaoFisica_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica av = new AvaliacaoFisica
            {
                CpfAluno = aluno.Cpf
            };
            mainWindow.MudarUserControl("selecionarTipoAvalicaoFisica", av,"Cadastrar");
        }

        private void EditarAluno_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("editarAluno", aluno);
        }

        private void BtnListaAvaliacaoFisicas_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("listarAvaliacoes",aluno.Cpf);
        }

        private void ExcluirAluno_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Tem certeza que deseja excluir o aluno " 
                + aluno.Nome + " do banco de dados?", "Confirmação" , MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString().ToUpper() == "YES")
            {
                if (BDAluno.DeletaAluno(aluno.Cpf))
                    Xceed.Wpf.Toolkit.MessageBox.Show("Aluno excluido com sucesso!");
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("Não foi possível deletar o aluno!");
                mainWindow.MudarUserControl("aluno");
            }
            
        }
    }
}
