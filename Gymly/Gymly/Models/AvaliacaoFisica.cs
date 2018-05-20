using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    class AvaliacaoFisica
    {
        //Perimetros
        private float primetroOmbro;
        private float primetroTorax;
        private float primetroBraço;
        private float primetroAntebraco;
        private float primetroCintura;
        private float primetroAbdominal;
        private float primetroQuadril;
        private float primetroCoxaProximal;
        private float primetroCoxaMedial;
        private float primetroDistal;
        private float primetroPerna;
        
        //Dobras Cutaneas 
        private float dobraCutaneaSubescapular;
        private float dobraCutaneaTriceps;
        private float dobraCutaneaBiceps;
        private float dobraCutaneaTorax;
        private float dobraCutaneaAxilarMedia;
        private float dobraCutaneaSuprailiaca;
        private float dobraCutaneaAbdominal;
        private float dobraCutaneaCoxa;
        private float dobraCutaneaPerna;

        //Básicos
        private float altura;
        private float massa;

        public float DobraCutaneaSubescapular { get => dobraCutaneaSubescapular; set => dobraCutaneaSubescapular = value; }
        public float DobraCutaneaTriceps { get => dobraCutaneaTriceps; set => dobraCutaneaTriceps = value; }
        public float DobraCutaneaBiceps { get => dobraCutaneaBiceps; set => dobraCutaneaBiceps = value; }
        public float DobraCutaneaTorax { get => dobraCutaneaTorax; set => dobraCutaneaTorax = value; }
        public float DobraCutaneaAxilarMedia { get => dobraCutaneaAxilarMedia; set => dobraCutaneaAxilarMedia = value; }
        public float DobraCutaneaSuprailiaca { get => dobraCutaneaSuprailiaca; set => dobraCutaneaSuprailiaca = value; }
        public float DobraCutaneaAbdominal { get => dobraCutaneaAbdominal; set => dobraCutaneaAbdominal = value; }
        public float DobraCutaneaCoxa { get => dobraCutaneaCoxa; set => dobraCutaneaCoxa = value; }
        public float DobraCutaneaPerna { get => dobraCutaneaPerna; set => dobraCutaneaPerna = value; }
        public float Altura { get => altura; set => altura = value; }
        public float Massa { get => massa; set => massa = value; }
        public float PrimetroOmbro { get => primetroOmbro; set => primetroOmbro = value; }
        public float PrimetroTorax { get => primetroTorax; set => primetroTorax = value; }
        public float PrimetroBraço { get => primetroBraço; set => primetroBraço = value; }
        public float PrimetroAntebraco { get => primetroAntebraco; set => primetroAntebraco = value; }
        public float PrimetroCintura { get => primetroCintura; set => primetroCintura = value; }
        public float PrimetroAbdominal { get => primetroAbdominal; set => primetroAbdominal = value; }
        public float PrimetroQuadril { get => primetroQuadril; set => primetroQuadril = value; }
        public float PrimetroCoxaProximal { get => primetroCoxaProximal; set => primetroCoxaProximal = value; }
        public float PrimetroCoxaMedial { get => primetroCoxaMedial; set => primetroCoxaMedial = value; }
        public float PrimetroDistal { get => primetroDistal; set => primetroDistal = value; }
        public float PrimetroPerna { get => primetroPerna; set => primetroPerna = value; }

        public float imc(float massa, float altura) {
            return (massa / (altura * altura));
        }
        public double PercentualDeGordura(Aluno aluno) {

            double d;
            float somaDobras;

            if(aluno.Sexo == 'F'){
               somaDobras = (DobraCutaneaAxilarMedia + DobraCutaneaSuprailiaca + DobraCutaneaCoxa + DobraCutaneaPerna);
               d = 1.1954713-0.07513507*Math.Log10(somaDobras)-0.00041072 * Aluno.calculaIdade(aluno.DataNasc);
            }
            else
            {
                somaDobras = (DobraCutaneaSubescapular+DobraCutaneaTriceps+DobraCutaneaSuprailiaca + DobraCutaneaPerna);
                d = 1.10726863-0.00081201*(somaDobras)+0.00000212*(somaDobras*somaDobras)-0.00041761* Aluno.calculaIdade(aluno.DataNasc);

            }
            return ((4.95/d) - 4.5) * 100;
        }

        public double CalculaMassaMagra(Aluno aluno) {
            return Massa-CalculaMassaGorda(aluno);
        }
        public double CalculaMassaGorda(Aluno aluno) {
            return Math.Round(massa * (PercentualDeGordura(aluno) / 100));
        }

    }
}
