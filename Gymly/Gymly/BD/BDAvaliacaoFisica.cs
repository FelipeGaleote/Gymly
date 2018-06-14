using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymly.Models;
using System.Data.SQLite;
namespace Gymly.BD
{
    class BDAvaliacaoFisica
    {
        public static void InsereAvaliacaoFisica(AvaliacaoFisica avaliacaoFisica)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "INSERT INTO AvaliacaoFisica(perimetroOmbro,perimetroTorax,perimetroBraçoE,perimetroBraçoD,perimetroAntebraçoE,perimetroAntebraçoD" +
                "perimetroCintura,perimetroAbdominal,perimetroQuadril,perimetroCoxaProximalE,perimetroCoxaProximalD,perimetroCoxaMedialE,perimetroCoxaMedialD,perimetroDistalE, perimetroDistalD" +
                "perimetroPernaE, perimetroPernaD,dobraCutaneaSubescapular,dobraCutaneaTriceps,dobraCutaneaBiceps,dobraCutaneaTorax,dobraCutaneaAxilarMedia" +
                "dobraCutaneaSuprailiaca,dobraCutaneaAbdominal,dobraCutaneaCoxa,dobraCutaneaPerna,altura,massa,envergadura"+
                "potMinima,potMaxima)VALUES(@perimetroOmbro,@perimetroTorax,@perimetroBraçoE,@perimetroBraçoD,@perimetroAntebraçoE,@perimetroAntebraçoD,@perimetroCintura" +
                "@perimetroAbdominal,@perimetroQuadril,@perimetroCoxaProximalE,@perimetroCoxaProximalD,@perimetroCoxaMedialE,@perimetroCoxaMedialD,@perimetroDistalE, @perimetroDistalD,@perimetroPernaE, @perimetroPernaD" +
                "@dobraCutaneaSubescapular,@dobraCutaneaTriceps,@dobraCutaneaBiceps,@dobraCutaneaTorax,@dobraCutaneaAxilarMedia" +
                "@dobraCutaneaSuprailiaca,@dobraCutaneaAbdominal,@dobraCutaneaCoxa,@dobraCutaneaPerna,@altura,@massa,@envergadura"+
                "@potMinima,@potMaxima)";



            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@perimetroOmbro", avaliacaoFisica.PerimetroOmbro);
            cmd.Parameters.AddWithValue("@perimetroTorax", avaliacaoFisica.PerimetroTorax);
            cmd.Parameters.AddWithValue("@perimetroBraçoE", avaliacaoFisica.PerimetroBraçoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroBraçoD", avaliacaoFisica.PerimetroBraçoDireito);
            cmd.Parameters.AddWithValue("@perimetroAntebraçoE", avaliacaoFisica.PerimetroAntebracoEsquerdo);
            cmd.Parameters.AddWithValue("@perimetroAntebraçoD", avaliacaoFisica.PerimetroAntebracoDireito);
            cmd.Parameters.AddWithValue("@perimetroCintura", avaliacaoFisica.PerimetroCintura);
            cmd.Parameters.AddWithValue("@perimetroAbdominal", avaliacaoFisica.PerimetroAbdominal);
            cmd.Parameters.AddWithValue("@perimetroQuadril", avaliacaoFisica.PerimetroQuadril);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalE", avaliacaoFisica.PerimetroCoxaProximalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaProximalD", avaliacaoFisica.PerimetroCoxaProximalDireita);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialE", avaliacaoFisica.PerimetroCoxaMedialEsquerda);
            cmd.Parameters.AddWithValue("@perimetroCoxaMedialD", avaliacaoFisica.PerimetroCoxaMedialDireita);
            cmd.Parameters.AddWithValue("@perimetroDistalE", avaliacaoFisica.PerimetroCoxaDistalEsquerda);
            cmd.Parameters.AddWithValue("@perimetroDistalD", avaliacaoFisica.PerimetroCoxaDistalDireita);
            cmd.Parameters.AddWithValue("@perimetroPernaE", avaliacaoFisica.PerimetroPernaEsquerda);
            cmd.Parameters.AddWithValue("@perimetroPernaD", avaliacaoFisica.PerimetroPernaDireita);
            cmd.Parameters.AddWithValue("@dobraCutaneaSubescapular", avaliacaoFisica.DobraCutaneaSubescapular);
            cmd.Parameters.AddWithValue("@dobraCutaneaTriceps", avaliacaoFisica.DobraCutaneaTriceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaBiceps", avaliacaoFisica.DobraCutaneaBiceps);
            cmd.Parameters.AddWithValue("@dobraCutaneaTorax", avaliacaoFisica.DobraCutaneaTorax);
            cmd.Parameters.AddWithValue("@dobraCutaneaAxilarMedia", avaliacaoFisica.DobraCutaneaAxilarMedia);
            cmd.Parameters.AddWithValue("@dobraCutaneaSuprailiaca", avaliacaoFisica.DobraCutaneaSuprailiaca);
            cmd.Parameters.AddWithValue("@dobraCutaneaAbdominal", avaliacaoFisica.DobraCutaneaAbdominal);
            cmd.Parameters.AddWithValue("@dobraCutaneaCoxa", avaliacaoFisica.DobraCutaneaCoxa);
            cmd.Parameters.AddWithValue("@dobraCutaneaPerna", avaliacaoFisica.DobraCutaneaPerna);
            cmd.Parameters.AddWithValue("@altura", avaliacaoFisica.Altura);
            cmd.Parameters.AddWithValue("@massa", avaliacaoFisica.Massa);
            cmd.Parameters.AddWithValue("@envergadura", avaliacaoFisica.Envergadura);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<string> SelecionaIdAvaliacoesFisicasDoAluno(string cpf)
        {
            List<string> idAvFisicas = new List<string>();
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "SELECT id FROM AvaliacaoFisica WHERE cpf_aluno LIKE '"+cpf+"';";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                idAvFisicas.Add(reader.GetString(0));
            }
            reader.Close();
            return idAvFisicas;
        }
        /*
        public static Aluno SelecionaAvaliacaoFisicaPorId(int id, string tipo)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = (tipo=="Antropometrica")? "SELECT af.*, a.* FROM AvaliacaoFisica af JOIN AF_Antropometrica a ON af.id = a.id_af WHERE af.id = "+id : "SELECT af.*, b.* FROM AvaliacaoFisica af JOIN AF_Bioimpedancia b ON af.id = b.id_af WHERE af.id = " + id;

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica();
            try
            {
                avaliacaoFisica.Data = reader["DATA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMFRONTAL"].ToString();
                avaliacaoFisica.ObservacaoImagemFrontal = reader["OBSERVACAOIMAGEMFRONTAL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMLATERAL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["OBSERVACAOIMAGEMLATERAL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["CAMINHOIMAGEMCOSTAS"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["OBSERVACAOIMAGEMCOSTAS"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROOMBRO"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROTORAX"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROBRACODIREITO"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROBRACOESQUERDO"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCINTURA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROABDOMINAL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROQUADRIL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAPROXIMALDIREITA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAPROXIMALESQUERDA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAMEDIALDIREITA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXAMEDIALESQUERDA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROCOXADISTALESQUERDA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROPERNADIREITA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PERIMETROPERNAESQUERDA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["ENVERGADURA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["ALTURA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["MASSA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PRESSAOARTERIALSISTOLICA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["PRESSAOARTERIALDIASTOLICA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["FREQUENCIACARDIACA"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["TEMPOABDOMINAL"].ToString();
                avaliacaoFisica.CaminhoImagemFrontal = reader["TEMPOFLEXAO"].ToString();
            }
            catch
            {

            }
            reader.Close();
            conn.Close();
            return aluno;
        }
        */

    }
}
