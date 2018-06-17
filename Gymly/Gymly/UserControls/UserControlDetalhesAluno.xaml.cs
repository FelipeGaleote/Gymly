using Gymly.BD;
using Gymly.Models;
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
            aluno = new Aluno();
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
               // Xceed.Wpf.Toolkit.MessageBox.Show(aluno.CaminhoFotoDoRosto);
               // if (aluno.CaminhoFotoDoRosto != String.Empty)
               // {

               //     imageFotoDeRosto.Source = GerenciadorDeArquivos.AdicionaImagem(aluno.CaminhoFotoDoRosto);
              //  }
              //  else
               // {
                //    imageFotoDeRosto.Source = GerenciadorDeArquivos.AdicionaImagem("Image\\sem_foto.png");
               // }
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
            AvaliacaoFisica av = new AvaliacaoFisica();
            mainWindow.MudarUserControl("selecionarTipoAvalicaoFisica", av);
        }

        private void editarAluno_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("editarAluno", aluno);
        }

        private void btnListaAvaliacaoFisicas_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("listarAvaliacoes",aluno.Cpf);
        }
    }
}
