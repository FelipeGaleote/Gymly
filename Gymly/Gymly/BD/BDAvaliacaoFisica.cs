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
        public static void InsereAluno(AvaliacaoFisica avaliacaoFisica)
        {
            SQLiteConexao conexao = new SQLiteConexao();
            SQLiteConnection conn = conexao.GetConexao();

            string sql = "INSERT INTO AvaliacaoFisica(perimetroOmbro,perimetroTorax,perimetroBraço,perimetroAntebraco"+
                "perimetroCintura,perimetroAbdominal,perimetroQuadril,perimetroCoxaProximal,perimetroCoxaMedial,perimetroDistal"+ 
                "perimetroPerna,dobraCutaneaSubescapular,dobraCutaneaTriceps,dobraCutaneaBiceps,dobraCutaneaTorax,dobraCutaneaAxilarMedia" +
                "dobraCutaneaSuprailiaca,dobraCutaneaAbdominal,dobraCutaneaCoxa,dobraCutaneaPerna,altura,massa,envergadura"+
                "potMinima,potMaxima)VALUES(@perimetroOmbro,@perimetroTorax,@perimetroBraço,@perimetroAntebraco,@perimetroCintura"+
                "@perimetroAbdominal,@perimetroQuadril,@perimetroCoxaProximal,@perimetroCoxaMedial,@perimetroDistal,@perimetroPerna"+
                "@dobraCutaneaSubescapular,@dobraCutaneaTriceps,@dobraCutaneaBiceps,@dobraCutaneaTorax,@dobraCutaneaAxilarMedia" +
                "@dobraCutaneaSuprailiaca,@dobraCutaneaAbdominal,@dobraCutaneaCoxa,@dobraCutaneaPerna,@altura,@massa,@envergadura"+
                "@potMinima,@potMaxima)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("perimetroOmbro", avaliacaoFisica.PerimetroOmbro);
            cmd.Parameters.AddWithValue("perimetroTorax", avaliacaoFisica.PerimetroTorax);
            cmd.Parameters.AddWithValue("perimetroBraço", avaliacaoFisica.PerimetroBraço);
            cmd.Parameters.AddWithValue("perimetroAntebraço", avaliacaoFisica.PerimetroAntebraco);
            cmd.Parameters.AddWithValue("perimetroCintura", avaliacaoFisica.PerimetroCintura);
            cmd.Parameters.AddWithValue("perimetroAbdominal", avaliacaoFisica.PerimetroAbdominal);
            cmd.Parameters.AddWithValue("perimetroQuadril", avaliacaoFisica.PerimetroQuadril);
            cmd.Parameters.AddWithValue("perimetroCoxaProximal", avaliacaoFisica.PerimetroCoxaProximal);
            cmd.Parameters.AddWithValue("perimetroCoxaMedial", avaliacaoFisica.PerimetroCoxaMedial);
            cmd.Parameters.AddWithValue("perimetroDistal", avaliacaoFisica.PerimetroDistal);
            cmd.Parameters.AddWithValue("perimetroPerna", avaliacaoFisica.PerimetroPerna);
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
            cmd.Parameters.AddWithValue("potMinima", avaliacaoFisica.PotMinima);
            cmd.Parameters.AddWithValue("potMaxima", avaliacaoFisica.PotMaxima);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
