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
        private string tipoDeAvaliacao; //ok   --Pegar pelo botao-- bio. ou adip.
        private string observacao; 

        //Imagens
        private string caminhoImagemFrontal;
        private string observacaoImagemFrontal;
        private string caminhoImagemLateral;
        private string observacaoImagemLateral;
        private string caminhoImagemCostas;
        private string observacaoImagemCostas;

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
        private string flexibilidade; //ok

        //Teste Abdominal

        //Teste Flexão

        

        //Capacidade Anaerobica - RAST
        private float potMinima;
        private float potMaxima;
        private List<float> potencias = new List<float>();

        public string CpfAluno
        {
            get
            {
                return cpfAluno;
            }

            set
            {
                cpfAluno = value;
            }
        }

        public string QtdadeDiasDeTreino
        {
            get
            {
                return qtdadeDiasDeTreino;
            }

            set
            {
                qtdadeDiasDeTreino = value;
            }
        }

        public string TipoDeAvaliacao
        {
            get
            {
                return tipoDeAvaliacao;
            }

            set
            {
                tipoDeAvaliacao = value;
            }
        }

        public string CaminhoImagemFrontal
        {
            get
            {
                return caminhoImagemFrontal;
            }

            set
            {
                caminhoImagemFrontal = value;
            }
        }

        public string ObservacaoImagemFrontal
        {
            get
            {
                return observacaoImagemFrontal;
            }

            set
            {
                observacaoImagemFrontal = value;
            }
        }

        public string CaminhoImagemLateral
        {
            get
            {
                return caminhoImagemLateral;
            }

            set
            {
                caminhoImagemLateral = value;
            }
        }

        public string ObservacaoImagemLateral
        {
            get
            {
                return observacaoImagemLateral;
            }

            set
            {
                observacaoImagemLateral = value;
            }
        }

        public string CaminhoImagemCostas
        {
            get
            {
                return caminhoImagemCostas;
            }

            set
            {
                caminhoImagemCostas = value;
            }
        }

        public string ObservacaoImagemCostas
        {
            get
            {
                return observacaoImagemCostas;
            }

            set
            {
                observacaoImagemCostas = value;
            }
        }

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

        public float PerimetroBraçoDireito
        {
            get
            {
                return perimetroBraçoDireito;
            }

            set
            {
                perimetroBraçoDireito = value;
            }
        }

        public float PerimetroBraçoEsquerdo
        {
            get
            {
                return perimetroBraçoEsquerdo;
            }

            set
            {
                perimetroBraçoEsquerdo = value;
            }
        }

        public float PerimetroAntebracoDireito
        {
            get
            {
                return perimetroAntebracoDireito;
            }

            set
            {
                perimetroAntebracoDireito = value;
            }
        }

        public float PerimetroAntebracoEsquerdo
        {
            get
            {
                return perimetroAntebracoEsquerdo;
            }

            set
            {
                perimetroAntebracoEsquerdo = value;
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

        public float PerimetroCoxaProximalDireita
        {
            get
            {
                return perimetroCoxaProximalDireita;
            }

            set
            {
                perimetroCoxaProximalDireita = value;
            }
        }

        public float PerimetroCoxaProximalEsquerda
        {
            get
            {
                return perimetroCoxaProximalEsquerda;
            }

            set
            {
                perimetroCoxaProximalEsquerda = value;
            }
        }

        public float PerimetroCoxaMedialDireita
        {
            get
            {
                return perimetroCoxaMedialDireita;
            }

            set
            {
                perimetroCoxaMedialDireita = value;
            }
        }

        public float PerimetroCoxaMedialEsquerda
        {
            get
            {
                return perimetroCoxaMedialEsquerda;
            }

            set
            {
                perimetroCoxaMedialEsquerda = value;
            }
        }

        public float PerimetroCoxaDistalDireita
        {
            get
            {
                return perimetroCoxaDistalDireita;
            }

            set
            {
                perimetroCoxaDistalDireita = value;
            }
        }

        public float PerimetroCoxaDistalEsquerda
        {
            get
            {
                return perimetroCoxaDistalEsquerda;
            }

            set
            {
                perimetroCoxaDistalEsquerda = value;
            }
        }

        public float PerimetroPernaDireita
        {
            get
            {
                return perimetroPernaDireita;
            }

            set
            {
                perimetroPernaDireita = value;
            }
        }

        public float PerimetroPernaEsquerda
        {
            get
            {
                return perimetroPernaEsquerda;
            }

            set
            {
                perimetroPernaEsquerda = value;
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

        public float PressaoArterialSistolica
        {
            get
            {
                return pressaoArterialSistolica;
            }

            set
            {
                pressaoArterialSistolica = value;
            }
        }

        public float PressaoArterialDiastolica
        {
            get
            {
                return pressaoArterialDiastolica;
            }

            set
            {
                pressaoArterialDiastolica = value;
            }
        }

        public float FrequenciaCardiaca
        {
            get
            {
                return frequenciaCardiaca;
            }

            set
            {
                frequenciaCardiaca = value;
            }
        }

        public string Flexibilidade
        {
            get
            {
                return flexibilidade;
            }

            set
            {
                flexibilidade = value;
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

        public string Observacao { get => observacao; set => observacao = value; }

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
