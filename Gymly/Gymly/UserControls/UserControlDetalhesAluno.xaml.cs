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
        public UserControlDetalhesAluno()
        {
            InitializeComponent();
        }
        public UserControlDetalhesAluno(string cpf)
        {
            InitializeComponent();
            preencherInformacoes(cpf);
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
                txtBlockSexo.Text = aluno.Sexo.ToString();
            }
        }
    }
}
