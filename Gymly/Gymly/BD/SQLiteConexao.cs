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
                sql.AppendLine("CREATE TABLE IF NOT EXISTS ALUNOS ([CPF] VARCHAR(16) PRIMARY KEY,");
                sql.AppendLine("[NOME] VARCHAR(50),");
                sql.AppendLine("[DATANASC] DATE,");
                sql.AppendLine("[EMAIL] VARCHAR(50),");
                sql.AppendLine("[TELEFONE] VARCHAR(15),");
                sql.AppendLine("[GENERO] VARCHAR(10),");
                sql.AppendLine("[NIVEL] VARCHAR(50));");
                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();



                sql.AppendLine("CREATE TABLE IF NOT EXISTS ANAMNESES ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[ID] INT");
                sql.AppendLine("[CPF_ALUNO] VARCHAR(16),");
                sql.AppendLine("[HISTORICO_PROBLEMA_CARDIACO] INT,");
                sql.AppendLine("[HISTORICO_DORES_PEITO] INT,");
                sql.AppendLine("[HISTORICO_DESMAIOS_OU_VERTIGEM] INT,");
                sql.AppendLine("[HISTORICO_PRESSAO_ALTA] INT,");
                sql.AppendLine("[HISTORICO_PROBLEMA_OSSEO] INT,");
                sql.AppendLine("[RAZAO_FISICA] INT,");
                sql.AppendLine("[IDOSO_REGULAR] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_CORONARIANA] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_REUMATICA] INT,");
                sql.AppendLine("[DOENCA_CARDIACA_CONGENITA] INT,");
                sql.AppendLine("[BAIMENTOS_CARDIACOS_IRREGULARES] INT,");
                sql.AppendLine("[PROBLEMA_VALVULAS_CARDIACAS] INT,");
                sql.AppendLine("[MURMURIOS_CARDIACOS] INT,");
                sql.AppendLine("[ATAQUE_CARDIACO] INT,");
                sql.AppendLine("[DERRAME_CEREBRAL] INT,");
                sql.AppendLine("[EPILEPSIA] INT,");
                sql.AppendLine("[DIABETES] INT,");
                sql.AppendLine("[HIPERTENSAO] INT,");
                sql.AppendLine("[CANCER] INT,");
                //AINDA NÃO FORAM IMPLEMENTADOS NA TELA
                sql.AppendLine("[DOR_COSTAS] INT,");
                sql.AppendLine("[DOR_ARTICULACAO] INT,");
                sql.AppendLine("[DOR_PULMONAR] INT,");
                sql.AppendLine("[PROBLEMA_RECENTE_PARENTE] INT,");
                sql.AppendLine("[RESTRICAO_FISICA] INT,");
                sql.AppendLine("[GESTANTE] INT,");
                sql.AppendLine("[FUMANTE] INT,");
                sql.AppendLine("[BEBIDA_ALCOOLICA] INT,");
                sql.AppendLine("[TODOS_GRUPOS_ALIMENTARES] INT,");
                sql.AppendLine("[ALTA_GORDURA_SATURADA] INT,");
                sql.AppendLine("[PERDER_PESO] INT,");
                sql.AppendLine("[MELHORAR_FLEXIBILIDADE] INT,");
                sql.AppendLine("[PARAR_FUMAR] INT,");
                sql.AppendLine("[REDUZIR_DORES_COSTAS] INT,");
                sql.AppendLine("[MELHORAR_NUTRICAO] INT,");
                sql.AppendLine("[MELHORAR_APTIDAO] INT,");
                sql.AppendLine("[MELHORAR_MUSCULAR] INT,");
                sql.AppendLine("[REDUZIR_ESTRESSE] INT,");
                sql.AppendLine("[DIMINUIR_COLESTEROL] INT,");
                sql.AppendLine("[SENTIR_MELHOR] INT,");


                sql.AppendLine("FOREIGN KEY(CPF_ALUNO) REFERENCES ALUNO(CPF));");


                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();
                sql.Clear();

                
                sql.AppendLine("CREATE TABLE IF NOT EXISTS AVALIACAO FISICA ([ID] INTEGER PRIMARY KEY AUTOINCREMENT,");
                sql.AppendLine("[ID] INT,");
                sql.AppendLine("[CPF_ALUNO] VARCHAR(16),");
                sql.AppendLine("[DATA] DATE,");
                sql.AppendLine("[IDADE] INT,");
                sql.AppendLine("[PESO] FLOAT,");
                sql.AppendLine("[ALTURA] FLOAT,");
                sql.AppendLine("[TAXA_MUSCULO] FLOAT,");
                sql.AppendLine("[TAXA_GORDURA] FLOAT,");
                sql.AppendLine("[TAXA_AGUA] FLOAT,");
                sql.AppendLine("[FREQUENCIA_CARDIACA] INT,");
                sql.AppendLine("[PRESSAO_ARTERIAL] VARCHAR(7),");
                sql.AppendLine("[BRACO_DIREITO] FLOAT,");
                sql.AppendLine("[BRACO_ESQUERDO] FLOAT,");
                sql.AppendLine("[ANTEBRACO_DIREITO] FLOAT,");
                sql.AppendLine("[ANTEBRACO_ESQUERDO] FLOAT,");
                sql.AppendLine("[TORAX] FLOAT,");
                sql.AppendLine("[CINTURA] FLOAT,");
                sql.AppendLine("[ABDOME] FLOAT,");
                sql.AppendLine("[QUADRIL] FLOAT,");
                sql.AppendLine("[COXA_DIREITA] FLOAT,");
                sql.AppendLine("[COXA_ESQUERDA] FLOAT,");
                sql.AppendLine("[PANTURRILHA_DIREITA] FLOAT,");
                sql.AppendLine("[PANTURRILHA_ESQUERDA] FLOAT,");
                sql.AppendLine("[FLEXAO] INT,");
                sql.AppendLine("[ABDOMINAL] INT,");

                sql.AppendLine("FOREIGN KEY(CPF_ALUNO) REFERENCES ALUNOS(CPF));");

                cmd = new SQLiteCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();



                conn.Close();
            }
        }

    }
}
