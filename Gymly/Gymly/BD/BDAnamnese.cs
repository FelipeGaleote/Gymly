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
        public static void InsereAnamnese(Anamnese anamnese, string cpfAluno)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();
            string sql = "INSERT INTO Anamneses(" +
                     "cpf_aluno,historico_problema_cardiaco,historico_dores_peito,historico_desmaios_ou_vertigem,historico_pressao_alta,historico_problema_osseo," +
                     "idoso_nao_acostumado,doenca_cardiaca_coronariana,doenca_cardiaca_reumatica,doenca_cardiaca_congenita,batimentos_cardiacos_irregulares,problema_valvulas_cardiacas,murmurios_cardiacos," +
                     "ataque_cardiaco,derrame_cerebral,epilepsia,diabetes,hipertensao,cancer,dor_costas,dor_articulacao,dor_pulmonar," + "gestante,fumante,bebida_alcoolica," +
                     "perder_peso,melhorar_flexibilidade,diminuir_vicios,reduzir_dores,melhorar_nutricao,melhorar_aptidao,melhorar_muscular,reduzir_estresse, sentir_melhor, hipertrofia, observacao) " +
                     "VALUES(@cpf_aluno,@historico_problema_cardiaco,@historico_dores_peito,@historico_desmaios_ou_vertigem,@historico_pressao_alta,@historico_problema_osseo," +
                     "@idoso_nao_acostumado,@doenca_cardiaca_coronariana,@doenca_cardiaca_reumatica,@doenca_cardiaca_congenita,@batimentos_cardiacos_irregulares," +
                     "@problema_valvulas_cardiacas,@murmurios_cardiacos,@ataque_cardiaco,@derrame_cerebral,@epilepsia,@diabetes,@hipertensao,@cancer,@dor_costas,@dor_articulacao,@dor_pulmonar," +
                     "@gestante,@fumante,@bebida_alcoolica,@perder_peso,@melhorar_flexibilidade,@diminuir_vicios," +
                     "@reduzir_dores,@melhorar_nutricao,@melhorar_aptidao,@melhorar_muscular,@reduzir_estresse,@sentir_melhor, @hipertrofia, @observacao);";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf_Aluno", cpfAluno);
            cmd.Parameters.AddWithValue("@historico_problema_cardiaco", anamnese.HistoricoProblemaCardiaco);
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

        internal static void AtualizaAnamnese(Anamnese anamnese)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "UPDATE Anamneses SET " +
                         "historico_problema_cardiaco = @historico_problema_cardiaco," +
                         "historico_dores_peito = @historico_dores_peito," +
                         "historico_desmaios_ou_vertigem = @historico_desmaios_ou_vertigem," +
                         "historico_pressao_alta = @historico_pressao_alta, " +
                         "historico_problema_osseo = @historico_problema_osseo, " +
                         "idoso_nao_acostumado = @idoso_nao_acostumado," +
                         "doenca_cardiaca_coronariana = @doenca_cardiaca_coronariana," +
                         "doenca_cardiaca_reumatica = @doenca_cardiaca_reumatica," +
                         "doenca_cardiaca_congenita = @doenca_cardiaca_congenita," +
                         "batimentos_cardiacos_irregulares = @batimentos_cardiacos_irregulares," +
                         "problema_valvulas_cardiacas = @problema_valvulas_cardiacas," +
                         "murmurios_cardiacos = @murmurios_cardiacos," +
                     "ataque_cardiaco = @ataque_cardiaco," +
                         "derrame_cerebral= @derrame_cerebral," +
                         "epilepsia = @epilepsia," +
                         "diabetes =@diabetes," +
                         "hipertensao = @hipertensao" +
                         ",cancer = @cancer," +
                         "dor_costas = @dor_costas," +
                         "dor_articulacao = @dor_articulacao," +
                         "dor_pulmonar = @dor_pulmonar,"
                         + "gestante = @gestante," +
                         "fumante = @fumante,bebida_alcoolica = @bebida_alcoolica," +
                     "perder_peso= @perder_peso ," +
                         "melhorar_flexibilidade = @melhorar_flexibilidade," +
                         "diminuir_vicios = @diminuir_vicios," +
                         "reduzir_dores = @reduzir_dores," +
                         "melhorar_nutricao = @melhorar_nutricao," +
                         "melhorar_aptidao = @melhorar_aptidao," +
                         "melhorar_muscular = @melhorar_muscular," +
                         "reduzir_estresse = @reduzir_estresse, " +
                         "sentir_melhor = @sentir_melhor, " +
                         "hipertrofia = @hipertrofia, " +
                         "observacao = @observacao " +
                         "where cpf_aluno = @cpf_aluno;";


            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf_aluno", anamnese.CpfAluno);
            cmd.Parameters.AddWithValue("@historico_problema_cardiaco", anamnese.HistoricoProblemaCardiaco);
            cmd.Parameters.AddWithValue("@historico_dores_peito", anamnese.HistoricoDoresPeito);
            cmd.Parameters.AddWithValue("@historico_desmaios_ou_vertigem", anamnese.HistoricoDesmaiosOuVertigem);
            cmd.Parameters.AddWithValue("@historico_pressao_alta", anamnese.HistoricoPressaoAlta);
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

        public static Anamnese SelecionaAnamnesePeloCpf(String cpf)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT * FROM anamneses where cpf_aluno like '" + cpf + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            //cmd.Parameters.AddWithValue("cpf_aluno", cpf);
            SQLiteDataReader reader =  cmd.ExecuteReader();
            reader.Read();

            Anamnese anamnese = new Anamnese();
            try
            {
                anamnese.CpfAluno = reader["cpf_aluno"].ToString();
                anamnese.HistoricoProblemaCardiaco = Convert.ToBoolean(reader["historico_problema_cardiaco"]);
                anamnese.HistoricoDoresPeito = Convert.ToBoolean(reader["historico_dores_peito"]);
                anamnese.HistoricoDesmaiosOuVertigem = Convert.ToBoolean(reader["historico_desmaios_ou_vertigem"]);
                anamnese.HistoricoPressaoAlta = Convert.ToBoolean(reader["historico_pressao_alta"]);
                anamnese.HistoricoProblemaOsseo = Convert.ToBoolean(reader["historico_problema_osseo"]);
                anamnese.IdosoNaoAcostumado = Convert.ToBoolean(reader["idoso_nao_acostumado"]);
                anamnese.DoencaCardiacaCoronariana = Convert.ToBoolean(reader["doenca_cardiaca_coronariana"]);
                anamnese.DoencaCardiacaReumatica = Convert.ToBoolean(reader["doenca_cardiaca_reumatica"]);
                anamnese.DoencaCardiacaCongenita = Convert.ToBoolean(reader["doenca_cardiaca_congenita"]);
                anamnese.BatimentosCardiacosIrregulares = Convert.ToBoolean(reader["batimentos_cardiacos_irregulares"]);
                anamnese.ProblemaValvulasCardiacas = Convert.ToBoolean(reader["problema_valvulas_cardiacas"]);
                anamnese.MurmuriosCardiacos = Convert.ToBoolean(reader["murmurios_cardiacos"]);
                anamnese.AtaqueCardiaco = Convert.ToBoolean(reader["ataque_cardiaco"]);
                anamnese.DerrameCerebral = Convert.ToBoolean(reader["derrame_cerebral"]);
                anamnese.Epilepsia = Convert.ToBoolean(reader["epilepsia"]);
                anamnese.Diabetes = Convert.ToBoolean(reader["diabetes"]);
                anamnese.Hipertensao = Convert.ToBoolean(reader["hipertensao"]);
                anamnese.Cancer = Convert.ToBoolean(reader["cancer"]);
                anamnese.DorCostas = Convert.ToBoolean(reader["dor_costas"]);
                anamnese.DorArticulacao = Convert.ToBoolean(reader["dor_articulacao"]);
                anamnese.DorPulmonar = Convert.ToBoolean(reader["dor_pulmonar"]);
                anamnese.Gestante = Convert.ToBoolean(reader["gestante"]);
                anamnese.Fumante = Convert.ToBoolean(reader["fumante"]);
                anamnese.BebidaAlcoolica = Convert.ToBoolean(reader["bebida_alcoolica"]);
                anamnese.PerderPeso = Convert.ToBoolean(reader["perder_peso"]);
                anamnese.MelhorarFlexibilidade = Convert.ToBoolean(reader["melhorar_flexibilidade"]);
                anamnese.DiminuirVicios = Convert.ToBoolean(reader["diminuir_vicios"]);
                anamnese.ReduzirDores = Convert.ToBoolean(reader["ReduzirDores"]);
                anamnese.MelhorarNutricao = Convert.ToBoolean(reader["melhorar_nutricao"]);
                anamnese.MelhorarAptidao = Convert.ToBoolean(reader["melhorar_aptidao"]);
                anamnese.MelhorarMuscular = Convert.ToBoolean(reader["melhorar_muscular"]);
                anamnese.ReduzirEstresse = Convert.ToBoolean(reader["reduzir_estresse"]);

                anamnese.SentirMelhor = Convert.ToBoolean(reader["sentir_melhor"]);
                anamnese.Hipertrofia = Convert.ToBoolean(reader["hipertrofia"]);

                anamnese.Observacao = reader["observacao"].ToString();
                

            }
            catch
            {

            }
            finally
            {
                reader.Close();
                conn.Close();
            }
           
            return anamnese;
        }
    }
}
