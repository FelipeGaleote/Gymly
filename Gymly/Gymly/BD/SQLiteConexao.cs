using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Gymly.BD
{
    class SQLiteConexao
    {

        private static string nomeBanco = "gymly.db";
        private static string conexao = "Data Source="+nomeBanco;
        private static int IDregistro;
        private SQLiteConnection conn;


        public SQLiteConexao()
        {
            criaTabelas();
        }

        public SQLiteConnection getConexao()
        {
            conn = new SQLiteConnection(conexao);
            conn.Open();
            return conn;
        }

        private void criaTabelas()
        {
            if (!File.Exists(nomeBanco))
            {
                SQLiteConnection.CreateFile(nomeBanco);
                conn = new SQLiteConnection(conexao);
                conn.Open();
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("PRAGMA foreign_keys = ON;");
                SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS ALUNOS ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[NOME] VARCHAR(50),");
                sql.AppendLine("[DATANASC] DATE,");
                sql.AppendLine("[EMAIL] VARCHAR(50),");
                sql.AppendLine("[TELEFONE] VARCHAR(15),");
                sql.AppendLine("[GENERO] VARCHAR(10),");
                sql.AppendLine("[NIVEL] VARCHAR(50),");
                sql.AppendLine("[IDANAMNESE] INTEGER,");
                sql.AppendLine("FOREIGN KEY(IDANAMNESE) REFERENCES ANAMNESE(ID));");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS ANAMNESES ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[ALTURA] DOUBLE);");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}
