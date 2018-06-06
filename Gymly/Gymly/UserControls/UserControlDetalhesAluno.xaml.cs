using Gymly.BD;
using Gymly.Models;
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

using Xceed.Wpf.Toolkit;
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
                btnCadastrarAnamnese.Content = "Cadastrar anamnese";
            }
        }

        private void BtnCadastrarAnamnese_Click(object sender, RoutedEventArgs e)
        {
            if(this.aluno.Anamnese == null)
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
        }

        private void BtnCadastrarAvaliacaoFisica_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica av = new AvaliacaoFisica();
            mainWindow.MudarUserControl("selecionarTipoAvalicaoFisica", av);
        }
    }
}
