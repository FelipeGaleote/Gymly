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
        
        public void insereAnamnese()
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
        public void insereAnamnese(Anamnese anamnese, int idaluno)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            string sql = "INSERT INTO Anamnese(historico_problema_cardiaco,historico_dores_peito,historico_desmaios_ou_vertigem,historico_pressao_alta,historico_problema_osseo,razao_fisica," +
                "idoso_regular,doenca_cardiaca_coronariana,doenca_cardiaca_reumatica,doenca_cardiaca_congenita,batimentos_cardiacos_irregulares,problema_valvulas_cardiacas,murmurios_cardiacos," +
                "ataque_cardiaco,derrame_cerebral,epilepsia,diabetes,hipertensao,cancer,dor_articulacao,dor_pulmonar," +"problema_recente_parente,restricao_fisica,gestante,fumante,bebida_alcoolica," +
               "todos_grupos_alimentares,alta_gordura_saturada,perder_peso,parar_fumar,reduzir_dores_costas,melhorar_nutricao,melhorar_aptidao,melhorar_muscular,reduzir_estresse,diminuir_colesterol," + "sentir_melhor) " +
                "VALUES(@historico_problema_cardiaco,@historico_dores_peito,@historico_desmaios_ou_vertigem,@historico_pressao_alta,@historico_problema_osseo," +
                "@razao_fisica,@idoso_regular,@doenca_cardiaca_coronariana,@doenca_cardiaca_reumatica,@doenca_cardiaca_congenita,@batimentos_cardiacos_irregulares," +
                "@problema_valvulas_cardiacas,@murmurios_cardiacos,@ataque_cardiaco,@derrame_cerebral,@epilepsia,@diabetes,@hipertensao,@cancer,@dor_articulacao,@dor_pulmonar," +
                "@problema_recente_parente,@restricao_fisica,@gestante,@fumante,@bebida_alcoolica,@todos_grupos_alimentares,@alta_gordura_saturada,@perder_peso,@parar_fumar," +
                "@reduzir_dores_costas,@melhorar_nutricao,@melhorar_aptidao,@melhorar_muscular,@reduzir_estresse,@diminuir_colesterol,@sentir_melhor)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("idaluno", idaluno);
            cmd.Parameters.AddWithValue("historico_problema_cardiaco", anamnese.Historico_problema_cardiaco);
            cmd.Parameters.AddWithValue("historico_dores_peito", anamnese.Historico_dores_peito);
            cmd.Parameters.AddWithValue("historico_desmaios_ou_vertigem", anamnese.Historico_desmaios_ou_vertigem);
            cmd.Parameters.AddWithValue("historico_pressao_alta" , anamnese.Historico_pressao_alta);
            cmd.Parameters.AddWithValue("historico_problema_osseo", anamnese.Historico_problema_osseo);
            cmd.Parameters.AddWithValue("razao_fisica", anamnese.Razao_fisica);
            cmd.Parameters.AddWithValue("idoso_regular", anamnese.Idoso_regular);
            cmd.Parameters.AddWithValue("doenca_cardiaca_coronariana", anamnese.Doenca_cardiaca_coronariana);
            cmd.Parameters.AddWithValue("doenca_cardiaca_reumatica", anamnese.Doenca_cardiaca_reumatica);
            cmd.Parameters.AddWithValue("doenca_cardiaca_congenita", anamnese.Doenca_cardiaca_congenita);
            cmd.Parameters.AddWithValue("batimentos_cardiacos_irregulares", anamnese.Batimentos_cardiacos_irregulares);
            cmd.Parameters.AddWithValue(" problema_valvulas_cardiacas", anamnese.Problema_valvulas_cardiacas);
            cmd.Parameters.AddWithValue("murmurios_cardiacos", anamnese.Murmurios_cardiacos);
            cmd.Parameters.AddWithValue("ataque_cardiaco", anamnese.Ataque_cardiaco);
            cmd.Parameters.AddWithValue("derrame_cerebral", anamnese.Derrame_cerebral);
            cmd.Parameters.AddWithValue("epilepsia", anamnese.Epilepsia);
            cmd.Parameters.AddWithValue("diabetes", anamnese.Diabetes);
            cmd.Parameters.AddWithValue("hipertensao", anamnese.Hipertensao);
            cmd.Parameters.AddWithValue("cancer", anamnese.Cancer);
            cmd.Parameters.AddWithValue("dor_articulacao", anamnese.Dor_articulacao);
            cmd.Parameters.AddWithValue("dor_pulmonar", anamnese.Dor_pulmonar);
            cmd.Parameters.AddWithValue("problema_recente_parente", anamnese.Problema_recente_parente);
            cmd.Parameters.AddWithValue("restricao_fisica", anamnese.Restricao_fisica);
            cmd.Parameters.AddWithValue("gestante", anamnese.Gestante);
            cmd.Parameters.AddWithValue("fumante", anamnese.Fumante);
            cmd.Parameters.AddWithValue("bebida_alcoolica", anamnese.Bebida_alcoolica);
            cmd.Parameters.AddWithValue("todos_grupos_alimentares", anamnese.Todos_grupos_alimentares);
            cmd.Parameters.AddWithValue("alta_gordura_saturada", anamnese.Alta_gordura_saturada);
            cmd.Parameters.AddWithValue("perder_peso", anamnese.Perder_peso);
            cmd.Parameters.AddWithValue("parar_fumar", anamnese.Parar_fumar);
            cmd.Parameters.AddWithValue("reduzir_dores_costas", anamnese.Reduzir_dores_costas);
            cmd.Parameters.AddWithValue("melhorar_nutricao", anamnese.Melhorar_nutricao);
            cmd.Parameters.AddWithValue("melhorar_aptidao", anamnese.Melhorar_aptidao);
            cmd.Parameters.AddWithValue("melhorar_muscular", anamnese.Melhorar_muscular);
            cmd.Parameters.AddWithValue("reduzir_estresse", anamnese.Reduzir_estresse);
            cmd.Parameters.AddWithValue("diminuir_colesterol", anamnese.Diminuir_colesterol);
            cmd.Parameters.AddWithValue("sentir_melhor", anamnese.Sentir_melhor);

            
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
