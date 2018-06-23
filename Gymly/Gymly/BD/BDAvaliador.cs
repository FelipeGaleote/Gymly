using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.BD
{
    class BDAvaliador
    {
        public static void InsereAvaliador(String nome)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "INSERT INTO Avaliadores(nome) VALUES(@nome);";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", nome);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static DataTable SelecionaAvaliadores()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string query = "SELECT nome AS 'Nome do avaliador' FROM Avaliadores;";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            DataTable dt = new DataTable("Avaliadores");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public static void DeletaAvaliador(String nome)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "DELETE FROM AVALIADORES WHERE nome = @nome";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", nome);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
