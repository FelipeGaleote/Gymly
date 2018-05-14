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
        public static void insereAnamnese(Anamnese anamnese, string cpfAluno)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.getConexao();
            string sql = "INSERT INTO Anamneses("+
                "id, cpf_aluno,historico_problema_cardiaco,historico_dores_peito,historico_desmaios_ou_vertigem,historico_pressao_alta,historico_problema_osseo," +
                "idoso_nao_acostumado,doenca_cardiaca_coronariana,doenca_cardiaca_reumatica,doenca_cardiaca_congenita,batimentos_cardiacos_irregulares,problema_valvulas_cardiacas,murmurios_cardiacos," +
                "ataque_cardiaco,derrame_cerebral,epilepsia,diabetes,hipertensao,cancer,dor_costas,dor_articulacao,dor_pulmonar," +"gestante,fumante,bebida_alcoolica," +
                "perder_peso,melhorar_flexibilidade,diminuir_vicios,reduzir_dores,melhorar_nutricao,melhorar_aptidao,melhorar_muscular,reduzir_estresse, sentir_melhor, hipertrofia, observacao) " +
                "VALUES(NULL, @cpf_aluno,@historico_problema_cardiaco,@historico_dores_peito,@historico_desmaios_ou_vertigem,@historico_pressao_alta,@historico_problema_osseo," +
                "@idoso_nao_acostumado,@doenca_cardiaca_coronariana,@doenca_cardiaca_reumatica,@doenca_cardiaca_congenita,@batimentos_cardiacos_irregulares," +
                "@problema_valvulas_cardiacas,@murmurios_cardiacos,@ataque_cardiaco,@derrame_cerebral,@epilepsia,@diabetes,@hipertensao,@cancer,@dor_costas,@dor_articulacao,@dor_pulmonar," +
                "@gestante,@fumante,@bebida_alcoolica,@perder_peso,@melhorar_flexibilidade,@diminuir_vicios," +
                "@reduzir_dores,@melhorar_nutricao,@melhorar_aptidao,@melhorar_muscular,@reduzir_estresse,@sentir_melhor, @hipertrofia, @observacao);";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf_Aluno", cpfAluno);
            cmd.Parameters.AddWithValue("@historico_problema_cardiaco", anamnese.Historico_problema_cardiaco);
            cmd.Parameters.AddWithValue("@historico_dores_peito", anamnese.Historico_dores_peito);
            cmd.Parameters.AddWithValue("@historico_desmaios_ou_vertigem", anamnese.Historico_desmaios_ou_vertigem);
            cmd.Parameters.AddWithValue("@historico_pressao_alta" , anamnese.Historico_pressao_alta);
            cmd.Parameters.AddWithValue("@historico_problema_osseo", anamnese.Historico_problema_osseo);
            cmd.Parameters.AddWithValue("@idoso_nao_acostumado", anamnese.Idoso_nao_acostumado);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_coronariana", anamnese.Doenca_cardiaca_coronariana);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_reumatica", anamnese.Doenca_cardiaca_reumatica);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_congenita", anamnese.Doenca_cardiaca_congenita);
            cmd.Parameters.AddWithValue("@batimentos_cardiacos_irregulares", anamnese.Batimentos_cardiacos_irregulares);
            cmd.Parameters.AddWithValue("@problema_valvulas_cardiacas", anamnese.Problema_valvulas_cardiacas);
            cmd.Parameters.AddWithValue("@murmurios_cardiacos", anamnese.Murmurios_cardiacos);
            cmd.Parameters.AddWithValue("@ataque_cardiaco", anamnese.Ataque_cardiaco);
            cmd.Parameters.AddWithValue("@derrame_cerebral", anamnese.Derrame_cerebral);
            cmd.Parameters.AddWithValue("@epilepsia", anamnese.Epilepsia);
            cmd.Parameters.AddWithValue("@diabetes", anamnese.Diabetes);
            cmd.Parameters.AddWithValue("@hipertensao", anamnese.Hipertensao);
            cmd.Parameters.AddWithValue("@cancer", anamnese.Cancer); 
            cmd.Parameters.AddWithValue("@dor_costas", anamnese.Dor_costas); 
            cmd.Parameters.AddWithValue("@dor_articulacao", anamnese.Dor_articulacao);
            cmd.Parameters.AddWithValue("@dor_pulmonar", anamnese.Dor_pulmonar);
            cmd.Parameters.AddWithValue("@gestante", anamnese.Gestante);
            cmd.Parameters.AddWithValue("@fumante", anamnese.Fumante);
            cmd.Parameters.AddWithValue("@bebida_alcoolica", anamnese.Bebida_alcoolica);
            cmd.Parameters.AddWithValue("@perder_peso", anamnese.Perder_peso);
            cmd.Parameters.AddWithValue("@melhorar_flexibilidade", anamnese.Melhorar_flexibilidade);
            cmd.Parameters.AddWithValue("@diminuir_vicios", anamnese.Diminuir_vicios);
            cmd.Parameters.AddWithValue("@reduzir_dores", anamnese.Reduzir_dores);
            cmd.Parameters.AddWithValue("@melhorar_nutricao", anamnese.Melhorar_nutricao);
            cmd.Parameters.AddWithValue("@melhorar_aptidao", anamnese.Melhorar_aptidao);
            cmd.Parameters.AddWithValue("@melhorar_muscular", anamnese.Melhorar_muscular);
            cmd.Parameters.AddWithValue("@reduzir_estresse", anamnese.Reduzir_estresse);
            cmd.Parameters.AddWithValue("@sentir_melhor", anamnese.Sentir_melhor);
            cmd.Parameters.AddWithValue("@hipertrofia", anamnese.Hipertrofia);
            cmd.Parameters.AddWithValue("@observacao", anamnese.Observacao);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
