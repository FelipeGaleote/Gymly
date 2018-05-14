using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Gymly.BD;
using Gymly.Models;
using Gymly.UserControls;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;

namespace Gymly.UserControls
{

    public partial class UserControlAluno : UserControl, INotifyPropertyChanged
    {
        private const string nomeTabela = "Aluno";
        private string txtBoxTextoConsultaAluno = "Consultar Alunos";
        private MainWindow mainWindow;

        public UserControlAluno(MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;
            txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
            txtBoxConsultaAluno.Foreground = Brushes.Gray;
            this.mainWindow = mainWindow;
            preencheDataGridAluno();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void txtBoxConsultaAluno_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxConsultaAluno.Clear();
            txtBoxConsultaAluno.Foreground = Brushes.Black;
        }

        private void txtBoxConsultaAluno_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtBoxConsultaAluno.Text == String.Empty)
            {
                txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
                txtBoxConsultaAluno.Foreground = Brushes.Gray;
            }
        }

        private void btnCadastraAluno_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mudarUserControl("cadastroAluno");

            /*BDAluno.insereAluno();
            List<Aluno> alunos = BDAluno.consultaAluno();
            foreach(Aluno a in alunos)
                Console.WriteLine(a.Nome +" "+ a.Email);*/

        }

        private void btnEditarAnamnese_Click(object sender, RoutedEventArgs e)
        {
           mainWindow.mudarUserControl("cadastroAnamnese");
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            string query = "SELECT cpf, nome FROM Alunos where nome like '%" + txtBoxConsultaAluno.Text + "%'";

            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Alunos");

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            adapter.Update(dt);
            conn.Close();
            //Aluno.listaAlunos();
        }

        private void preencheDataGridAluno()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            string query = "SELECT cpf, nome FROM Alunos;";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Alunos");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            adapter.Update(dt);
            conn.Close();
        }
        
    }
}