using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymly.Models;
using System.Data.SQLite;

namespace Gymly.BD
{
    class BDAnamnese
    {
        
        public void insereAnamnese(Anamnese anamnese)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO ANAMNESES VALUES(NULL, 1.74);");
            sql.AppendLine("INSERT INTO ANAMNESES VALUES(NULL, 1.42);");
            sql.AppendLine("INSERT INTO ANAMNESES VALUES(NULL, 1.75);");
            SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            sql.Clear();
        }
    }
}
