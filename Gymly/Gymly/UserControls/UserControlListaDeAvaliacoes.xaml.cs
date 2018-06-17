using Gymly.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
    /// Interação lógica para UserControlListaDeAvaliacoes.xam
    /// </summary>
    public partial class UserControlListaDeAvaliacoes : UserControl
    {
        private MainWindow mainWindow;
        private string CpfAluno;
        public UserControlListaDeAvaliacoes(MainWindow mainWindow,String cpf)
        {
            this.mainWindow = mainWindow;
            this.CpfAluno = cpf;
            InitializeComponent();
            PreencheDataGridAV("bunda");
        }

        private void PreencheDataGridAV(string nome)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT id, STRFTIME('%d/%m/%Y',data) as 'data' FROM AvaliacaoFisica";
            SQLiteCommand command = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable("AvaliacaoFisica");

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(dt);
            dataGridAV.ItemsSource = dt.DefaultView;
            conn.Close();
        }
    }
}
