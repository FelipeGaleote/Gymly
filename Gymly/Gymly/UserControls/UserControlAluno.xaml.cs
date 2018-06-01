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
using Gymly.BD;
using Gymly.Models;
using Gymly.UserControls;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
using Xceed.Wpf.DataGrid;

namespace Gymly.UserControls
{

    public partial class UserControlAluno : UserControl, INotifyPropertyChanged
    {
        private const string nomeTabela = "Aluno";
        private string txtBoxTextoConsultaAluno = "Consultar Alunos";
        private MainWindow mainWindow;

        public UserControlAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            DataContext = this;
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxConsultaAluno, txtBoxTextoConsultaAluno);
            PreencheDataGridAluno();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void TxtBoxConsultaAluno_GotFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.GotFocus(txtBoxConsultaAluno);
        }

        private void TxtBoxConsultaAluno_LostFocus(object sender, RoutedEventArgs e)
        {
            
            EditorTxtBox.LostFocus(txtBoxConsultaAluno, txtBoxTextoConsultaAluno);
        }

        private void BtnCadastraAluno_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MudarUserControl("cadastroAluno");

            /*BDAluno.insereAluno();
            List<Aluno> alunos = BDAluno.consultaAluno();
            foreach(Aluno a in alunos)
                Console.WriteLine(a.Nome +" "+ a.Email);*/

        }

        private void BtnCadastraOuEditaAnamnese_Click(object sender, RoutedEventArgs e)
        {
            //Tentar capturar o cpf do aluno selecionado no datagrid
            Anamnese anamnese = new Anamnese();
           // {
           //     CpfAluno = dataGridAluno.Columns[0].ToString()
           // };
           // MessageBox.Show(anamnese.CpfAluno);
            mainWindow.MudarUserControl("cadastroAnamnese", anamnese);
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtBoxConsultaAluno.Text == String.Empty) && !(txtBoxConsultaAluno.Text == txtBoxTextoConsultaAluno))
            {
                PreencheDataGridAluno(txtBoxConsultaAluno.Text);
            }
            else
            {
                PreencheDataGridAluno();
            }
            btnEditarAnamnese.Content = "Cadastrar anamnese";
        }

        private void PreencheDataGridAluno(string nome)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT cpf, nome, email, datanasc  FROM Alunos WHERE nome like '%" + txtBoxConsultaAluno.Text + "%'";
            SQLiteCommand command = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable("Alunos");

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void PreencheDataGridAluno()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT cpf, nome, email, datanasc FROM Alunos;";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Alunos");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAluno.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void BtnCadastrarAvaliacaoFisica_Click(object sender, RoutedEventArgs e)
        {
            
            //Capturar o cpf do aluno selecionado no datagrid
            //avaliacaoFisica.CpfAluno = ;
            btnCadastrarAvaliacaoFisica.IsEnabled = false;
            btnCadastrarAvaliacaoFisica.Visibility = Visibility.Collapsed;
            btnCadastrarAvaliacaoFisicaAntropometrica.IsEnabled = true;
            btnCadastrarAvaliacaoFisicaAntropometrica.Visibility = Visibility.Visible;
            btnCadastrarAvaliacaoFisicaBioimpedancia.IsEnabled = true;
            btnCadastrarAvaliacaoFisicaBioimpedancia.Visibility = Visibility.Visible; 
            
        }

        private void BtnCadastrarAvaliacaoFisicaAntropometrica_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica
            {
                TipoDeAvaliacao = "Antropometria"
            };
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", avaliacaoFisica);
        }

        private void BtnCadastrarAvaliacaoFisicaBioimpedancia_Click(object sender, RoutedEventArgs e)
        {
            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica
            {
                TipoDeAvaliacao = "Bioimpedancia"
            };
            mainWindow.MudarUserControl("cadastroAvaliacaoFisica", avaliacaoFisica);
        }

        private void txtBoxConsultaAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(txtBoxConsultaAluno.Text == String.Empty) && !(txtBoxConsultaAluno.Text == txtBoxTextoConsultaAluno))
            {
                btnEditarAnamnese.Content = "Cadastrar anamnese";
                PreencheDataGridAluno(txtBoxConsultaAluno.Text);
            } else
            {
                PreencheDataGridAluno();
            }
        }

        private void dataGridAluno_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView) dataGridAluno.SelectedItem;
            string cpf = dataRow.Row.ItemArray[0].ToString();
            mainWindow.MudarUserControl("detalhesAluno",cpf);
        }

        private void dataGridAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEditarAnamnese.Content = "Editar anamnese";
        }
    }
}