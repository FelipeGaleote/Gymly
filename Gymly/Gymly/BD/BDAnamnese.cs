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
            string sql = "INSERT INTO Anamneses(" +
                     "id, cpf_aluno,historico_problema_cardiaco,historico_dores_peito,historico_desmaios_ou_vertigem,historico_pressao_alta,historico_problema_osseo," +
                     "idoso_nao_acostumado,doenca_cardiaca_coronariana,doenca_cardiaca_reumatica,doenca_cardiaca_congenita,batimentos_cardiacos_irregulares,problema_valvulas_cardiacas,murmurios_cardiacos," +
                     "ataque_cardiaco,derrame_cerebral,epilepsia,diabetes,hipertensao,cancer,dor_costas,dor_articulacao,dor_pulmonar," + "gestante,fumante,bebida_alcoolica," +
                     "perder_peso,melhorar_flexibilidade,diminuir_vicios,reduzir_dores,melhorar_nutricao,melhorar_aptidao,melhorar_muscular,reduzir_estresse, sentir_melhor, hipertrofia, observacao) " +
                     "VALUES(NULL, @cpf_aluno,@historico_problema_cardiaco,@historico_dores_peito,@historico_desmaios_ou_vertigem,@historico_pressao_alta,@historico_problema_osseo," +
                     "@idoso_nao_acostumado,@doenca_cardiaca_coronariana,@doenca_cardiaca_reumatica,@doenca_cardiaca_congenita,@batimentos_cardiacos_irregulares," +
                     "@problema_valvulas_cardiacas,@murmurios_cardiacos,@ataque_cardiaco,@derrame_cerebral,@epilepsia,@diabetes,@hipertensao,@cancer,@dor_costas,@dor_articulacao,@dor_pulmonar," +
                     "@gestante,@fumante,@bebida_alcoolica,@perder_peso,@melhorar_flexibilidade,@diminuir_vicios," +
                     "@reduzir_dores,@melhorar_nutricao,@melhorar_aptidao,@melhorar_muscular,@reduzir_estresse,@sentir_melhor, @hipertrofia, @observacao);";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf_Aluno", cpfAluno);
            cmd.Parameters.AddWithValue("@Historico_problem_cardiaco", anamnese.HistoricoProblemaCardiaco);
            cmd.Parameters.AddWithValue("@historico_dores_peito", anamnese.HistoricoDoresPeito);
            cmd.Parameters.AddWithValue("@historico_desmaios_ou_vertigem", anamnese.HistoricoDesmaiosOuVertigem);
            cmd.Parameters.AddWithValue("@historico_pressao_alta" , anamnese.HistoricoPressaoAlta);
            cmd.Parameters.AddWithValue("@historico_problema_osseo", anamnese.HistoricoProblemaOsseo);
            cmd.Parameters.AddWithValue("@idoso_nao_acostumado", anamnese.IdosoNaoAcostumado);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_coronariana", anamnese.DoencaCardiacaCoronariana);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_reumatica", anamnese.DoencaCardiacaReumatica);
            cmd.Parameters.AddWithValue("@doenca_cardiaca_congenita", anamnese.DoencaCardiacaCongenita);
            cmd.Parameters.AddWithValue("@batimentos_cardiacos_irregulares", anamnese.BatimentosCardiacosIrregulares);
            cmd.Parameters.AddWithValue("@problema_valvulas_cardiacas", anamnese.ProblemaValvulasCardiacas);
            cmd.Parameters.AddWithValue("@murmurios_cardiacos", anamnese.MurmuriosCardiacos);
            cmd.Parameters.AddWithValue("@ataque_cardiaco", anamnese.AtaqueCardiaco);
            cmd.Parameters.AddWithValue("@derrame_cerebral", anamnese.DerrameCerebral);
            cmd.Parameters.AddWithValue("@epilepsia", anamnese.Epilepsia);
            cmd.Parameters.AddWithValue("@diabetes", anamnese.Diabetes);
            cmd.Parameters.AddWithValue("@hipertensao", anamnese.Hipertensao);
            cmd.Parameters.AddWithValue("@cancer", anamnese.Cancer); 
            cmd.Parameters.AddWithValue("@dor_costas", anamnese.DorCostas); 
            cmd.Parameters.AddWithValue("@dor_articulacao", anamnese.DorArticulacao);
            cmd.Parameters.AddWithValue("@dor_pulmonar", anamnese.DorPulmonar);
            cmd.Parameters.AddWithValue("@gestante", anamnese.Gestante);
            cmd.Parameters.AddWithValue("@fumante", anamnese.Fumante);
            cmd.Parameters.AddWithValue("@bebida_alcoolica", anamnese.BebidaAlcoolica);
            cmd.Parameters.AddWithValue("@perder_peso", anamnese.PerderPeso);
            cmd.Parameters.AddWithValue("@melhorar_flexibilidade", anamnese.MelhorarFlexibilidade);
            cmd.Parameters.AddWithValue("@diminuir_vicios", anamnese.DiminuirVicios);
            cmd.Parameters.AddWithValue("@reduzir_dores", anamnese.ReduzirDores);
            cmd.Parameters.AddWithValue("@melhorar_nutricao", anamnese.MelhorarNutricao);
            cmd.Parameters.AddWithValue("@melhorar_aptidao", anamnese.MelhorarAptidao);
            cmd.Parameters.AddWithValue("@melhorar_muscular", anamnese.MelhorarMuscular);
            cmd.Parameters.AddWithValue("@reduzir_estresse", anamnese.ReduzirEstresse);
            cmd.Parameters.AddWithValue("@sentir_melhor", anamnese.SentirMelhor);
            cmd.Parameters.AddWithValue("@hipertrofia", anamnese.Hipertrofia);
            cmd.Parameters.AddWithValue("@observacao", anamnese.Observacao);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
