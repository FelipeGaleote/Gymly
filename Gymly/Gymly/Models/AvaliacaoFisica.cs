using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    public class AvaliacaoFisica
    {
        //Tabela Avaliação fisica
        private string cpfAluno; //pegar do datagrid
        private DateTime data;
        private string qtdadeDiasDeTreino;
        private string tipoDeAvaliacao; 
        private string observacao; 
        private string caminhoImagemFrontal;
        private string observacaoImagemFrontal;
        private string caminhoImagemLateral;
        private string observacaoImagemLateral;
        private string caminhoImagemCostas;
        private string observacaoImagemCostas;
        private float perimetroOmbro; 
        private float perimetroTorax; 
        private float perimetroBracoDireito; 
        private float perimetroBracoEsquerdo;
        private float perimetroAntebracoDireito; 
        private float perimetroAntebracoEsquerdo;
        private float perimetroCintura;
        private float perimetroAbdominal; 
        private float perimetroQuadril;
        private float perimetroCoxaProximalDireita; 
        private float perimetroCoxaProximalEsquerda; 
        private float perimetroCoxaMedialDireita;
        private float perimetroCoxaMedialEsquerda;
        private float perimetroCoxaDistalDireita;
        private float perimetroCoxaDistalEsquerda;
        private float perimetroPernaDireita;
        private float perimetroPernaEsquerda;
        private float envergadura;
        private float altura;
        private float massa;
        private float pressaoArterialSistolica;
        private float pressaoArterialDiastolica;
        private float frequenciaCardiaca;
        private string flexibilidade;
        private int qtdadeAbdominais;
        private float tempoAbdominal;
        private int qtdadeFlexao;
        private float tempoFlexao;
        private float distanciaCooper;

        //Tabela Antropomerica
        private float dobraCutaneaSubescapular; 
        private float dobraCutaneaTriceps;
        private float dobraCutaneaBiceps;
        private float dobraCutaneaTorax;
        private float dobraCutaneaAxilarMedia;
        private float dobraCutaneaSuprailiaca;
        private float dobraCutaneaAbdominal;
        private float dobraCutaneaCoxa;
        private float dobraCutaneaPerna;

        //Bioimpedancia ainda n fiz, mas são poucos campos.Contudo as outras duas tabelas estão completas!

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

        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
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

        public float PerimetroBracoDireito
        {
            get
            {
                return perimetroBracoDireito;
            }

            set
            {
                perimetroBracoDireito = value;
            }
        }

        public float PerimetroBracoEsquerdo
        {
            get
            {
                return perimetroBracoEsquerdo;
            }

            set
            {
                perimetroBracoEsquerdo = value;
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

        public string Observacao {
            get { return observacao; }
            set { observacao = value; }
        }


        public int QtdadeAbdominais
        {
            get { return qtdadeAbdominais; }
            set { qtdadeAbdominais = value; }
        }
        public float TempoAbdominal
        {
            get { return tempoAbdominal; }
            set { tempoAbdominal = value; }
        }
        public int QtdadeFlexao
        {
            get { return qtdadeFlexao; }
            set { qtdadeFlexao = value; }
        }
        public float TempoFlexao
        {
            get { return tempoFlexao; }
            set { tempoFlexao = value; }
        }
        public float DistanciaCooper
        {
            get { return distanciaCooper; }
            set { distanciaCooper = value; }
        }

        public float CalculoImc(float massa, float altura) {
            return (massa / (altura * altura));
        }
        //Percentual de Gordural usando Dobras cutaneas 
        public double CalculaPercentualDeGordura(Aluno aluno) {

            double d;
            float somaDobras;

            if(aluno.Sexo.Equals("F")){
               somaDobras = (DobraCutaneaAxilarMedia + DobraCutaneaSuprailiaca + DobraCutaneaCoxa + DobraCutaneaPerna);
               d = 1.1954713-0.07513507*Math.Log10(somaDobras)-0.00041072 * aluno.CalculaIdade();
            }
            else
            {
                somaDobras = (DobraCutaneaSubescapular+DobraCutaneaTriceps+DobraCutaneaSuprailiaca + DobraCutaneaPerna);
                d = 1.10726863-0.00081201*(somaDobras)+0.00000212*(somaDobras*somaDobras)-0.00041761* aluno.CalculaIdade();

            }
            return ((4.95/d) - 4.5) * 100;
        }

        public double CalculaMassaMagra(Aluno aluno) {
            return Massa-CalculaMassaGorda(aluno);
        }
        public double CalculaMassaGorda(Aluno aluno) {
            return Math.Round(Massa * (CalculaPercentualDeGordura(aluno) / 100));
        }
        public double CalculaVo2Max(double distancia)
        {
            return ((distancia-504.9) / 44.73);
        }
       
        public string VerificaNivelCapacidadeAerobica(double vo2, string sexo, int idade)
        {
            string nivel = String.Empty;

            if (sexo.Equals("M"))
            {
                if((idade <= 19 && vo2 <2090)||(idade>=20 && idade<=29 && vo2<1960)||
                    (idade >= 30 && idade <= 39 && vo2 < 1900)|| (idade >= 40 && idade <= 49 && vo2 < 1830)
                    || (idade >= 50 && idade <= 59 && vo2 < 1660) || idade>= 60 && vo2<1400)
                {
                    nivel = "Muito Fraca";
                }
                else
                {
                    if ((idade <= 19 && vo2 < 2200) || (idade >= 20 && idade <= 29 && vo2 < 2110) ||
                    (idade >= 30 && idade <= 39 && vo2 < 2090) || (idade >= 40 && idade <= 49 && vo2 < 1990)
                    || (idade >= 50 && idade <= 59 && vo2 < 1870) || idade >= 60 && vo2 < 1640)
                    {
                        nivel = "Fraca";
                    }
                    else
                    {
                        if ((idade <= 19 && vo2 < 2510) || (idade >= 20 && idade <= 29 && vo2 < 2400) ||
                        (idade >= 30 && idade <= 39 && vo2 < 2400) || (idade >= 40 && idade <= 49 && vo2 < 2240)
                        || (idade >= 50 && idade <= 59 && vo2 < 2090) || idade >= 60 && vo2 < 1930)
                        {
                            nivel = "Média";
                        }
                        else
                        {
                            if ((idade <= 19 && vo2 < 2770) || (idade >= 20 && idade <= 29 && vo2 < 2640) ||
                            (idade >= 30 && idade <= 39 && vo2 < 2510) || (idade >= 40 && idade <= 49 && vo2 < 2460)
                            || (idade >= 50 && idade <= 59 && vo2 < 2320) || idade >= 60 && vo2 < 2120)
                            {
                                nivel = "Boa";
                            }
                            else
                            {
                                if ((idade <= 19 && vo2 < 3000) || (idade >= 20 && idade <= 29 && vo2 < 2830) ||
                                (idade >= 30 && idade <= 39 && vo2 < 2720) || (idade >= 40 && idade <= 49 && vo2 < 2660)
                                || (idade >= 50 && idade <= 59 && vo2 < 2540) || idade >= 60 && vo2 < 2490)
                                {
                                    nivel = "Excelente";
                                }
                                else
                                {
                                    if ((idade <= 19 && vo2 > 3000) || (idade >= 20 && idade <= 29 && vo2 > 2830) ||
                                    (idade >= 30 && idade <= 39 && vo2 > 2720) || (idade >= 40 && idade <= 49 && vo2 > 2660)
                                    || (idade >= 50 && idade <= 59 && vo2 > 2540) || idade >= 60 && vo2 > 2490)
                                    {
                                        nivel = "Superior";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if ((idade <= 19 && vo2 < 1610) || (idade >= 20 && idade <= 29 && vo2 < 1550) ||
                    (idade >= 30 && idade <= 39 && vo2 < 1510) || (idade >= 40 && idade <= 49 && vo2 < 1420)
                    || (idade >= 50 && idade <= 59 && vo2 < 1350) || idade >= 60 && vo2 < 1260)
                {
                    nivel = "Muito Fraca";
                }
                else
                {
                    if ((idade <= 19 && vo2 < 1900) || (idade >= 20 && idade <= 29 && vo2 < 1790) ||
                    (idade >= 30 && idade <= 39 && vo2 < 1690) || (idade >= 40 && idade <= 49 && vo2 < 1580)
                    || (idade >= 50 && idade <= 59 && vo2 < 1500) || idade >= 60 && vo2 < 1390)
                    {
                        nivel = "Fraca";
                    }
                    else
                    {
                        if ((idade <= 19 && vo2 < 2080) || (idade >= 20 && idade <= 29 && vo2 < 1970) ||
                        (idade >= 30 && idade <= 39 && vo2 < 1960) || (idade >= 40 && idade <= 49 && vo2 < 1790)
                        || (idade >= 50 && idade <= 59 && vo2 < 1690) || idade >= 60 && vo2 < 1590)
                        {
                            nivel = "Média";
                        }
                        else
                        {
                            if ((idade <= 19 && vo2 < 2300) || (idade >= 20 && idade <= 29 && vo2 < 2160) ||
                            (idade >= 30 && idade <= 39 && vo2 < 2080) || (idade >= 40 && idade <= 49 && vo2 < 2000)
                            || (idade >= 50 && idade <= 59 && vo2 < 1900) || idade >= 60 && vo2 < 1750)
                            {
                                nivel = "Boa";
                            }
                            else
                            {
                                if ((idade <= 19 && vo2 < 2310) || (idade >= 20 && idade <= 29 && vo2 < 2330) ||
                                (idade >= 30 && idade <= 39 && vo2 < 2240) || (idade >= 40 && idade <= 49 && vo2 < 2160)
                                || (idade >= 50 && idade <= 59 && vo2 < 2090) || idade >= 60 && vo2 < 1900)
                                {
                                    nivel = "Excelente";
                                }
                                else
                                {
                                    if ((idade <= 19 && vo2 > 2430) || (idade >= 20 && idade <= 29 && vo2 > 2330) ||
                                    (idade >= 30 && idade <= 39 && vo2 > 2240) || (idade >= 40 && idade <= 49 && vo2 > 2160)
                                    || (idade >= 50 && idade <= 59 && vo2 > 2090) || idade >= 60 && vo2 > 1900)
                                    {
                                        nivel = "Superior";
                                    }
                                }
                            }
                        }
                    }
                }
            }


            return nivel;
        }


        public string ClassificacaoIMC(float imc) {

            string classificacao = String.Empty;

            if (imc <16)
            {
                classificacao = "Magreza Grau III";
            }
            else
            {
                if (imc <= 16.9)
                {
                    classificacao = "Magreza Grau II";
                }
                else
                {
                    if (imc <= 18.4)
                    {
                        classificacao = "Magreza Grau I";
                    }
                    else
                    {
                        if (imc <= 24.9)
                        {
                            classificacao = "Eutrofia";
                        }
                        else
                        {
                            if (imc <= 29.9)
                            {
                                classificacao = "Pré-obesidade";
                            }
                            else
                            {
                                if (imc <= 34.9)
                                {
                                    classificacao = "Obesidade I";
                                }
                                else
                                {
                                    if (imc <= 39.9)
                                    {
                                        classificacao = "Obesidade II";
                                    }
                                    else
                                    {
                                        if (imc > 40)
                                        {
                                            classificacao = "Obesidade III";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return classificacao;
        }

    }
}
