﻿using System;
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
using System.Data;
using System.Data.SQLite;
using Gymly.BD;

namespace Gymly.UserControls
{
 
    public partial class UserControlAvaliacaoFisica : UserControl, INotifyPropertyChanged
    {
        private MainWindow mainWindow;
        private string txtBoxTextoConsultaAluno = "Consultar Alunos";
        public UserControlAvaliacaoFisica(MainWindow mainWindow)
        {
            
            this.mainWindow = mainWindow;
            InitializeComponent();
            DataContext = this;
            preencheDataGridAluno();
            txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
            txtBoxConsultaAluno.Foreground = Brushes.Gray;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void btnCadastraAvaliacaoFisica_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mudarUserControl("cadastroAvaliacaoFisica");
        }
        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtBoxConsultaAluno.Text == String.Empty) && !(txtBoxConsultaAluno.Text == txtBoxTextoConsultaAluno))
            {
                SQLiteConexao conexao = new SQLiteConexao();
                SQLiteConnection conn = conexao.getConexao();
                string query = "SELECT cpf, nome, email FROM Alunos where nome like '%" + txtBoxConsultaAluno.Text + "%'";

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
            else
            {
                preencheDataGridAluno();
            }
        }
        private void preencheDataGridAluno()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            string query = "SELECT cpf, nome, email FROM Alunos;";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Alunos");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            adapter.Update(dt);
            conn.Close();
        }
        private void txtBoxConsultaAluno_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxConsultaAluno.Clear();
            txtBoxConsultaAluno.Foreground = Brushes.Black;
        }

        private void txtBoxConsultaAluno_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxConsultaAluno.Text == String.Empty)
            {
                txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
                txtBoxConsultaAluno.Foreground = Brushes.Gray;
            }
        }
    }
}
