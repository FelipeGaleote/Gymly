using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    public class AvaliacaoFisica
    {
        private string cpfAluno; //pegar do datagrid
        private string qtdadeDiasDeTreino;//ok

        //Perimetros
        private float perimetroOmbro; //ok
        private float perimetroTorax; //ok
        private float perimetroBraçoDireito; //ok
        private float perimetroBraçoEsquerdo;//ok
        private float perimetroAntebracoDireito; //ok
        private float perimetroAntebracoEsquerdo;//ok
        private float perimetroCintura;//ok
        private float perimetroAbdominal; //ok
        private float perimetroQuadril;//ok
        private float perimetroCoxaProximalDireita; //ok
        private float perimetroCoxaProximalEsquerda; //ok
        private float perimetroCoxaMedialDireita;//ok
        private float perimetroCoxaMedialEsquerda;//ok
        private float perimetroCoxaDistalDireita;//ok
        private float perimetroCoxaDistalEsquerda;//ok
        private float perimetroPernaDireita;//ok
        private float perimetroPernaEsquerda;//ok
        private float envergadura; //ok

        //Dobras Cutaneas 
        private float dobraCutaneaSubescapular; //ok
        private float dobraCutaneaTriceps;//ok
        private float dobraCutaneaBiceps;//ok
        private float dobraCutaneaTorax;//ok
        private float dobraCutaneaAxilarMedia;//ok
        private float dobraCutaneaSuprailiaca;//ok
        private float dobraCutaneaAbdominal;//ok
        private float dobraCutaneaCoxa;//ok
        private float dobraCutaneaPerna;//ok

        //Básicos
        private float altura;//ok
        private float massa;//ok
        private float pressaoArterialSistolica;//ok
        private float pressaoArterialDiastolica;//ok
        private float frequenciaCardiaca;//ok

        //Capacidade Anaerobica - RAST
        private float potMinima;
        private float potMaxima;
        private List<float> potencias = new List<float>();

        public float PerimetroOmbro { get => perimetroOmbro; set => perimetroOmbro = value; }
        public float PerimetroTorax { get => perimetroTorax; set => perimetroTorax = value; }
        public float PerimetroBraçoDireito { get => perimetroBraçoDireito; set => perimetroBraçoDireito = value; }
        public float PerimetroBraçoEsquerdo { get => perimetroBraçoEsquerdo; set => perimetroBraçoEsquerdo = value; }
        public float PerimetroAntebracoDireito { get => perimetroAntebracoDireito; set => perimetroAntebracoDireito = value; }
        public float PerimetroAntebracoEsquerdo { get => perimetroAntebracoEsquerdo; set => perimetroAntebracoEsquerdo = value; }
        public float PerimetroCintura { get => perimetroCintura; set => perimetroCintura = value; }
        public float PerimetroAbdominal { get => perimetroAbdominal; set => perimetroAbdominal = value; }
        public float PerimetroQuadril { get => perimetroQuadril; set => perimetroQuadril = value; }
        public float PerimetroCoxaProximalDireita { get => perimetroCoxaProximalDireita; set => perimetroCoxaProximalDireita = value; }
        public float PerimetroCoxaProximalEsquerda { get => perimetroCoxaProximalEsquerda; set => perimetroCoxaProximalEsquerda = value; }
        public float PerimetroCoxaMedialDireita { get => perimetroCoxaMedialDireita; set => perimetroCoxaMedialDireita = value; }
        public float PerimetroCoxaMedialEsquerda { get => perimetroCoxaMedialEsquerda; set => perimetroCoxaMedialEsquerda = value; }
        public float PerimetroCoxaDistalDireita { get => perimetroCoxaDistalDireita; set => perimetroCoxaDistalDireita = value; }
        public float PerimetroCoxaDistalEsquerda { get => perimetroCoxaDistalEsquerda; set => perimetroCoxaDistalEsquerda = value; }
        public float PerimetroPernaDireita { get => perimetroPernaDireita; set => perimetroPernaDireita = value; }
        public float PerimetroPernaEsquerda { get => perimetroPernaEsquerda; set => perimetroPernaEsquerda = value; }
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
        public float Envergadura { get => envergadura; set => envergadura = value; }
        public float FrequenciaCardiaca { get => frequenciaCardiaca; set => frequenciaCardiaca = value; }
        public float PotMinima { get => potMinima; set => potMinima = value; }
        public float PotMaxima { get => potMaxima; set => potMaxima = value; }
        public List<float> Potencias { get => potencias; set => potencias = value; }
        public float PressaoArterialSistolica { get => pressaoArterialSistolica; set => pressaoArterialSistolica = value; }
        public float PressaoArterialDiastolica { get => pressaoArterialDiastolica; set => pressaoArterialDiastolica = value; }
        public string CpfAluno { get => cpfAluno; set => cpfAluno = value; }
        public string QtdadeDiasDeTreino { get => qtdadeDiasDeTreino; set => qtdadeDiasDeTreino = value; }

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
