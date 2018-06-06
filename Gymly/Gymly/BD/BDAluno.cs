using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Gymly.Models;
using System.Windows;

namespace Gymly.BD
{
    class BDAluno
    {                       

        public static void InsereAluno(Aluno aluno)
        {
            SQLiteConexao conexao = new SQLiteConexao();  
            SQLiteConnection conn = conexao.GetConexao(); 

            string sql = "INSERT INTO Alunos(cpf,nome,datanasc,email,telefone,sexo,nivel, foto_de_rosto) VALUES(@cpf,@nome,@datanasc,@email,@telefone,@sexo,@nivel, @foto_de_rosto);";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CPF",aluno.Cpf);
            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@datanasc", aluno.DataNasc);
            cmd.Parameters.AddWithValue("@email", aluno.Email);
            cmd.Parameters.AddWithValue("@telefone", aluno.Telefone);
            cmd.Parameters.AddWithValue("@sexo", aluno.Sexo);
            cmd.Parameters.AddWithValue("@nivel", aluno.Nivel);
            cmd.Parameters.AddWithValue("@foto_de_rosto", aluno.CaminhoFotoDoRosto);
            cmd.ExecuteNonQuery(); 
            conn.Close();  
        }
        public static Aluno SelecionaAlunoPorCpf(string cpf)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT * FROM alunos where cpf like '" + cpf + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Aluno aluno = new Aluno();
            try
            {
                aluno.Nome = reader["nome"].ToString();
                aluno.Cpf = reader["cpf"].ToString();
                aluno.Email = reader["email"].ToString();
                aluno.Nivel = reader["nivel"].ToString();
                aluno.Telefone = reader["telefone"].ToString();
                aluno.DataNasc = DateTime.Parse(reader["datanasc"].ToString());
                aluno.Sexo = reader["sexo"].ToString();
                aluno.CaminhoFotoDoRosto = reader["foto_de_rosto"].ToString();
            }
            catch
            {

            }
            reader.Close();
            conn.Close();
            return aluno;
        }
        public static List<string> SelecionaCpfsDosAlunos() {
            List<string> cpfs = new List<string>();
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT cpf FROM alunos;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cpfs.Add(reader.GetString(0));
            }
            reader.Close();
            return cpfs;
        }
        
    }
}
