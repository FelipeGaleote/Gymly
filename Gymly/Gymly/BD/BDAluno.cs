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

        public static void insereAluno(Aluno aluno)
        {
            SQLiteConexao conexao = new SQLiteConexao();  
            SQLiteConnection conn = conexao.getConexao(); 

            string sql = "INSERT INTO Alunos(cpf,nome,datanasc,email,telefone,genero,nivel) VALUES(@cpf,@nome,@datanasc,@email,@telefone,@genero,@nivel)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("CPF",aluno.Cpf);
            cmd.Parameters.AddWithValue("nome", aluno.Nome);
            cmd.Parameters.AddWithValue("datanasc", aluno.DataNasc);
            cmd.Parameters.AddWithValue("email", aluno.Email);
            cmd.Parameters.AddWithValue("telefone", aluno.Telefone);
            cmd.Parameters.AddWithValue("genero", aluno.Sexo);
            cmd.Parameters.AddWithValue("nivel", aluno.Nivel);
            cmd.ExecuteNonQuery(); 
            conn.Close();  
        }

        public static List<Aluno> consultaAluno()
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM ALUNOS;", conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            List<Aluno> lista = new List<Aluno>();
            while (dr.Read())
            {
                Aluno aluno = new Aluno();
                aluno.Cpf = dr["CPF"].ToString();
                aluno.Nome = dr["NOME"].ToString();
                aluno.Email = dr["EMAIL"].ToString();
                lista.Add(aluno);
            }
            return lista;
        }
    }
}
