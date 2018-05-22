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
        private float perimetroOmbro;
        private float perimetroTorax;
        private float perimetroBraço;
        private float perimetroAntebraco;
        private float perimetroCintura;
        private float perimetroAbdominal;
        private float perimetroQuadril;
        private float perimetroCoxaProximal;
        private float perimetroCoxaMedial;
        private float perimetroDistal;
        private float perimetroPerna;
        
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
        private float envergadura;

        //Capacidade Anaerobica - RAST
        private float potMinima;
        private float potMaxima;
        private List<float> potencias = new List<float>();

        public float PerimetroOmbro
        {
            get
            {
                return perimetroOmbro;
            }

            set
            {
                perimetroOmbro = value;
            }
        }

        public float PerimetroTorax
        {
            get
            {
                return perimetroTorax;
            }

            set
            {
                perimetroTorax = value;
            }
        }

        public float PerimetroBraço
        {
            get
            {
                return perimetroBraço;
            }

            set
            {
                perimetroBraço = value;
            }
        }

        public float PerimetroAntebraco
        {
            get
            {
                return perimetroAntebraco;
            }

            set
            {
                perimetroAntebraco = value;
            }
        }

        public float PerimetroCintura
        {
            get
            {
                return perimetroCintura;
            }

            set
            {
                perimetroCintura = value;
            }
        }

        public float PerimetroAbdominal
        {
            get
            {
                return perimetroAbdominal;
            }

            set
            {
                perimetroAbdominal = value;
            }
        }

        public float PerimetroQuadril
        {
            get
            {
                return perimetroQuadril;
            }

            set
            {
                perimetroQuadril = value;
            }
        }

        public float PerimetroCoxaProximal
        {
            get
            {
                return perimetroCoxaProximal;
            }

            set
            {
                perimetroCoxaProximal = value;
            }
        }

        public float PerimetroCoxaMedial
        {
            get
            {
                return perimetroCoxaMedial;
            }

            set
            {
                perimetroCoxaMedial = value;
            }
        }

        public float PerimetroDistal
        {
            get
            {
                return perimetroDistal;
            }

            set
            {
                perimetroDistal = value;
            }
        }

        public float PerimetroPerna
        {
            get
            {
                return perimetroPerna;
            }

            set
            {
                perimetroPerna = value;
            }
        }

        public float DobraCutaneaSubescapular
        {
            get
            {
                return dobraCutaneaSubescapular;
            }

            set
            {
                dobraCutaneaSubescapular = value;
            }
        }

        public float DobraCutaneaTriceps
        {
            get
            {
                return dobraCutaneaTriceps;
            }

            set
            {
                dobraCutaneaTriceps = value;
            }
        }

        public float DobraCutaneaBiceps
        {
            get
            {
                return dobraCutaneaBiceps;
            }

            set
            {
                dobraCutaneaBiceps = value;
            }
        }

        public float DobraCutaneaTorax
        {
            get
            {
                return dobraCutaneaTorax;
            }

            set
            {
                dobraCutaneaTorax = value;
            }
        }

        public float DobraCutaneaAxilarMedia
        {
            get
            {
                return dobraCutaneaAxilarMedia;
            }

            set
            {
                dobraCutaneaAxilarMedia = value;
            }
        }

        public float DobraCutaneaSuprailiaca
        {
            get
            {
                return dobraCutaneaSuprailiaca;
            }

            set
            {
                dobraCutaneaSuprailiaca = value;
            }
        }

        public float DobraCutaneaAbdominal
        {
            get
            {
                return dobraCutaneaAbdominal;
            }

            set
            {
                dobraCutaneaAbdominal = value;
            }
        }

        public float DobraCutaneaCoxa
        {
            get
            {
                return dobraCutaneaCoxa;
            }

            set
            {
                dobraCutaneaCoxa = value;
            }
        }

        public float DobraCutaneaPerna
        {
            get
            {
                return dobraCutaneaPerna;
            }

            set
            {
                dobraCutaneaPerna = value;
            }
        }

        public float Altura
        {
            get
            {
                return altura;
            }

            set
            {
                altura = value;
            }
        }

        public float Massa
        {
            get
            {
                return massa;
            }

            set
            {
                massa = value;
            }
        }

        public float Envergadura
        {
            get
            {
                return envergadura;
            }

            set
            {
                envergadura = value;
            }
        }

        public float PotMinima
        {
            get
            {
                return potMinima;
            }

            set
            {
                potMinima = value;
            }
        }

        public float PotMaxima
        {
            get
            {
                return potMaxima;
            }

            set
            {
                potMaxima = value;
            }
        }

        public List<float> Potencias
        {
            get
            {
                return potencias;
            }

            set
            {
                potencias = value;
            }
        }

        public float CalculoImc(float massa, float altura) {
            return (massa / (altura * altura));
        }
        //Percentual de Gordural usando Dobras cutaneas 
        public double CalculaPercentualDeGordura(Aluno aluno) {

            double d;
            float somaDobras;

            if(aluno.Sexo == 'F'){
               somaDobras = (DobraCutaneaAxilarMedia + DobraCutaneaSuprailiaca + DobraCutaneaCoxa + DobraCutaneaPerna);
               d = 1.1954713-0.07513507*Math.Log10(somaDobras)-0.00041072 * Aluno.CalculaIdade(aluno.DataNasc);
            }
            else
            {
                somaDobras = (DobraCutaneaSubescapular+DobraCutaneaTriceps+DobraCutaneaSuprailiaca + DobraCutaneaPerna);
                d = 1.10726863-0.00081201*(somaDobras)+0.00000212*(somaDobras*somaDobras)-0.00041761* Aluno.CalculaIdade(aluno.DataNasc);

            }
            return ((4.95/d) - 4.5) * 100;
        }

        public double CalculaMassaMagra(Aluno aluno) {
            return Massa-CalculaMassaGorda(aluno);
        }
        public double CalculaMassaGorda(Aluno aluno) {
            return Math.Round(Massa * (CalculaPercentualDeGordura(aluno) / 100));
        }
        public float CalculaPotenciaMedia(List<float> potencias)
        {
            float media = 0;
            foreach (float p in potencias)
            {
                media = media + p;
            }
            return (media / potencias.Count);
        }

        public float CalculaIndiceFadiga(float potMax, float potMin) {
            return (((potMax-potMin)*100)/potMax);
        }
        public float CalculaVelocidade(int tempo) {
            return (35 / tempo);
        }
        public float CalculaForca(float massa, float aceleracao) {
            return (massa*aceleracao);
        }
        public float CalcularAceleracao(float velocidade, int tempo) {
            return (velocidade/tempo);
        }
        public float CalcularPotencia(float forca, float velocidade) {
            return (forca*velocidade);
        }
        public double CalculaVO2Max(float velocidade) //Teste 2000 m
        {
            return (3.6*3.5*velocidade);
        }
    }
}
