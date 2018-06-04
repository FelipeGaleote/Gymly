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

            string sql = "INSERT INTO Alunos(cpf,nome,datanasc,email,telefone,sexo,nivel, foto_de_rosto) VALUES(@cpf,@nome,@datanasc,@email,@telefone,@sexo,@nivel, @foto_de_rosto)";

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

        
    }
}
