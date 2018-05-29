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
            cmd.Parameters.AddWithValue("perimetroOmbro", avaliacaoFisica.PerimetroOmbro);
            cmd.Parameters.AddWithValue("perimetroTorax", avaliacaoFisica.PerimetroTorax);
            cmd.Parameters.AddWithValue("perimetroBraçoE", avaliacaoFisica.PerimetroBraçoEsquerdo);
            cmd.Parameters.AddWithValue("perimetroBraçoD", avaliacaoFisica.PerimetroBraçoDireito);
            cmd.Parameters.AddWithValue("perimetroAntebraçoE", avaliacaoFisica.PerimetroAntebracoEsquerdo);
            cmd.Parameters.AddWithValue("perimetroAntebraçoD", avaliacaoFisica.PerimetroAntebracoDireito);
            cmd.Parameters.AddWithValue("perimetroCintura", avaliacaoFisica.PerimetroCintura);
            cmd.Parameters.AddWithValue("perimetroAbdominal", avaliacaoFisica.PerimetroAbdominal);
            cmd.Parameters.AddWithValue("perimetroQuadril", avaliacaoFisica.PerimetroQuadril);
            cmd.Parameters.AddWithValue("perimetroCoxaProximalE", avaliacaoFisica.PerimetroCoxaProximalEsquerda);
            cmd.Parameters.AddWithValue("perimetroCoxaProximalD", avaliacaoFisica.PerimetroCoxaProximalDireita);
            cmd.Parameters.AddWithValue("perimetroCoxaMedialE", avaliacaoFisica.PerimetroCoxaMedialEsquerda);
            cmd.Parameters.AddWithValue("perimetroCoxaMedialD", avaliacaoFisica.PerimetroCoxaMedialDireita);
            cmd.Parameters.AddWithValue("perimetroDistalE", avaliacaoFisica.PerimetroCoxaDistalEsquerda);
            cmd.Parameters.AddWithValue("perimetroDistalD", avaliacaoFisica.PerimetroCoxaDistalDireita);
            cmd.Parameters.AddWithValue("perimetroPernaE", avaliacaoFisica.PerimetroPernaEsquerda);
            cmd.Parameters.AddWithValue("perimetroPernaD", avaliacaoFisica.PerimetroPernaDireita);
            cmd.Parameters.AddWithValue("dobraCutaneaSubescapular", avaliacaoFisica.DobraCutaneaSubescapular);
            cmd.Parameters.AddWithValue("dobraCutaneaTriceps", avaliacaoFisica.DobraCutaneaTriceps);
            cmd.Parameters.AddWithValue("dobraCutaneaBiceps", avaliacaoFisica.DobraCutaneaBiceps);
            cmd.Parameters.AddWithValue("dobraCutaneaTorax", avaliacaoFisica.DobraCutaneaTorax);
            cmd.Parameters.AddWithValue("dobraCutaneaAxilarMedia", avaliacaoFisica.DobraCutaneaAxilarMedia);
            cmd.Parameters.AddWithValue("dobraCutaneauprailiaca", avaliacaoFisica.DobraCutaneaSuprailiaca);
            cmd.Parameters.AddWithValue("dobraCutaneaAbdominal", avaliacaoFisica.DobraCutaneaAbdominal);
            cmd.Parameters.AddWithValue("dobraCutaneaCoxa", avaliacaoFisica.DobraCutaneaCoxa);
            cmd.Parameters.AddWithValue("dobraCutaneaPerna", avaliacaoFisica.DobraCutaneaPerna);
            cmd.Parameters.AddWithValue("altura", avaliacaoFisica.Altura);
            cmd.Parameters.AddWithValue("massa", avaliacaoFisica.Massa);
            cmd.Parameters.AddWithValue("envergadura", avaliacaoFisica.Envergadura);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
