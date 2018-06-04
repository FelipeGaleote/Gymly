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
            this.aluno = new Aluno();
            InitializeComponent();
            preencherInformacoes(cpf);
            configurarBotoes(cpf);
        }

        private void preencherInformacoes(string cpf)
        {
            Aluno aluno = new Aluno();
            aluno = BDAluno.selecionaAlunoPorCpf(cpf);
            if (aluno != null)
            {
                txtBlockNome.Text = aluno.Nome;
                txtBlockCpf.Text = aluno.Cpf;
                txtBlockEmail.Text = aluno.Email;
                txtBlockTelefone.Text = aluno.Telefone;
                txtBlockNivel.Text = aluno.Nivel;
                txtBlockSexo.Text = aluno.Sexo.ToString().Equals("F")? "Feminino" : "Masculino";
                this.aluno = aluno;
            }
        }
        private void configurarBotoes(string cpf)
        {
            Anamnese anamnese = BDAnamnese.selecionaAnamnesePeloCpf(cpf);
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

        private void btnCadastrarAnamnese_Click(object sender, RoutedEventArgs e)
        {
            if(this.aluno.Anamnese == null)
            {
                Anamnese an = new Anamnese();
                an.CpfAluno = this.aluno.Cpf;
                mainWindow.MudarUserControl("cadastroAnamnese", an);
            }
            else
            {
                //O aluno deve ser direcionado para uma tela de edição da anamnese
            }
        }
    }
}
