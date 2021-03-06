﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    public class AvaliacaoFisica
    {

        //campos novos - bioImpedancia
        private float porcentagemAguaCorpo;
        private float porcentagemAguaMusculo;
        private float taxaMetabolicaBasal;
        private float porcentagemGorduraCorporal;



        //Tabela Avaliação fisica
        private int id;
        private string cpfAluno; //pegar do datagrid
        private string avaliador;
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
        private string nivelFlexoes;
        private string nivelAbdominais;

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


        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }



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
        public string NivelFlexoes
        {
            get { return nivelFlexoes; }
            set { nivelFlexoes = value; }
        }
        public string NivelAbdominais
        {
            get { return nivelAbdominais; }
            set { nivelAbdominais = value; }
        }
        
        public string Avaliador
        {
            get { return avaliador; }
            set { avaliador = value; }
        }

        public float PorcentagemAguaCorpo
        {
            get
            {
                return porcentagemAguaCorpo;
            }

            set
            {
                porcentagemAguaCorpo = value;
            }
        }

        public float PorcentagemAguaMusculo
        {
            get
            {
                return porcentagemAguaMusculo;
            }

            set
            {
                porcentagemAguaMusculo = value;
            }
        }

        public float TaxaMetabolicaBasal
        {
            get
            {
                return taxaMetabolicaBasal;
            }

            set
            {
                taxaMetabolicaBasal = value;
            }
        }

        public float PorcentagemGorduraCorporal
        {
            get
            {
                return porcentagemGorduraCorporal;
            }

            set
            {
                porcentagemGorduraCorporal = value;
            }
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
            return Math.Round(Massa * (PorcentagemGorduraCorporal/100));
        }
        public double CalculaVo2Max(double distancia)
        {
            return ((distancia-504.9) / 44.73);
        }
       
        public string VerificaNivelCapacidadeAerobica(double distancia, string sexo, int idade)
        {
            string nivel = String.Empty;

            if (sexo.Equals("M"))
            {
                if((idade <= 19 && distancia <2090)||(idade>=20 && idade<=29 && distancia<1960)||
                    (idade >= 30 && idade <= 39 && distancia < 1900)|| (idade >= 40 && idade <= 49 && distancia < 1830)
                    || (idade >= 50 && idade <= 59 && distancia < 1660) || idade>= 60 && distancia<1400)
                {
                    nivel = "Muito Fraca";
                }
                else
                {
                    if ((idade <= 19 && distancia < 2200) || (idade >= 20 && idade <= 29 && distancia < 2110) ||
                    (idade >= 30 && idade <= 39 && distancia < 2090) || (idade >= 40 && idade <= 49 && distancia < 1990)
                    || (idade >= 50 && idade <= 59 && distancia < 1870) || idade >= 60 && distancia < 1640)
                    {
                        nivel = "Fraca";
                    }
                    else
                    {
                        if ((idade <= 19 && distancia < 2510) || (idade >= 20 && idade <= 29 && distancia < 2400) ||
                        (idade >= 30 && idade <= 39 && distancia < 2400) || (idade >= 40 && idade <= 49 && distancia < 2240)
                        || (idade >= 50 && idade <= 59 && distancia < 2090) || idade >= 60 && distancia < 1930)
                        {
                            nivel = "Média";
                        }
                        else
                        {
                            if ((idade <= 19 && distancia < 2770) || (idade >= 20 && idade <= 29 && distancia < 2640) ||
                            (idade >= 30 && idade <= 39 && distancia < 2510) || (idade >= 40 && idade <= 49 && distancia < 2460)
                            || (idade >= 50 && idade <= 59 && distancia < 2320) || idade >= 60 && distancia < 2120)
                            {
                                nivel = "Boa";
                            }
                            else
                            {
                                if ((idade <= 19 && distancia < 3000) || (idade >= 20 && idade <= 29 && distancia < 2830) ||
                                (idade >= 30 && idade <= 39 && distancia < 2720) || (idade >= 40 && idade <= 49 && distancia < 2660)
                                || (idade >= 50 && idade <= 59 && distancia < 2540) || idade >= 60 && distancia < 2490)
                                {
                                    nivel = "Excelente";
                                }
                                else
                                {
                                    if ((idade <= 19 && distancia > 3000) || (idade >= 20 && idade <= 29 && distancia > 2830) ||
                                    (idade >= 30 && idade <= 39 && distancia > 2720) || (idade >= 40 && idade <= 49 && distancia > 2660)
                                    || (idade >= 50 && idade <= 59 && distancia > 2540) || idade >= 60 && distancia > 2490)
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
                if ((idade <= 19 && distancia < 1610) || (idade >= 20 && idade <= 29 && distancia < 1550) ||
                    (idade >= 30 && idade <= 39 && distancia < 1510) || (idade >= 40 && idade <= 49 && distancia < 1420)
                    || (idade >= 50 && idade <= 59 && distancia < 1350) || idade >= 60 && distancia < 1260)
                {
                    nivel = "Muito Fraca";
                }
                else
                {
                    if ((idade <= 19 && distancia < 1900) || (idade >= 20 && idade <= 29 && distancia < 1790) ||
                    (idade >= 30 && idade <= 39 && distancia < 1690) || (idade >= 40 && idade <= 49 && distancia < 1580)
                    || (idade >= 50 && idade <= 59 && distancia < 1500) || idade >= 60 && distancia < 1390)
                    {
                        nivel = "Fraca";
                    }
                    else
                    {
                        if ((idade <= 19 && distancia < 2080) || (idade >= 20 && idade <= 29 && distancia < 1970) ||
                        (idade >= 30 && idade <= 39 && distancia < 1960) || (idade >= 40 && idade <= 49 && distancia < 1790)
                        || (idade >= 50 && idade <= 59 && distancia < 1690) || idade >= 60 && distancia < 1590)
                        {
                            nivel = "Média";
                        }
                        else
                        {
                            if ((idade <= 19 && distancia < 2300) || (idade >= 20 && idade <= 29 && distancia < 2160) ||
                            (idade >= 30 && idade <= 39 && distancia < 2080) || (idade >= 40 && idade <= 49 && distancia < 2000)
                            || (idade >= 50 && idade <= 59 && distancia < 1900) || idade >= 60 && distancia < 1750)
                            {
                                nivel = "Boa";
                            }
                            else
                            {
                                if ((idade <= 19 && distancia < 2310) || (idade >= 20 && idade <= 29 && distancia < 2330) ||
                                (idade >= 30 && idade <= 39 && distancia < 2240) || (idade >= 40 && idade <= 49 && distancia < 2160)
                                || (idade >= 50 && idade <= 59 && distancia < 2090) || idade >= 60 && distancia < 1900)
                                {
                                    nivel = "Excelente";
                                }
                                else
                                {
                                    if ((idade <= 19 && distancia > 2430) || (idade >= 20 && idade <= 29 && distancia > 2330) ||
                                    (idade >= 30 && idade <= 39 && distancia > 2240) || (idade >= 40 && idade <= 49 && distancia > 2160)
                                    || (idade >= 50 && idade <= 59 && distancia > 2090) || idade >= 60 && distancia > 1900)
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

        public double CalculaTaxaMetabolicaBasal(Aluno aluno)
        {
            double taxa;
            if (aluno.Sexo.Equals("M"))
            {
                taxa = 66 + (13.7 * this.Massa) + (5 * this.Altura) - (6.8 * aluno.CalculaIdade());
            }
            else
            {
                taxa = 665 + (9.6 * this.Massa) + (1.8 * this.Altura) - (4.7 * aluno.CalculaIdade());
            }
            return taxa;
        }

        public double CalculaPesoRecomendado()
        {
            return (24.9 * (((Altura)/100) * ((Altura)/100)));
        }
        public float CalculaRCQ()
        {
            return this.PerimetroCintura / this.PerimetroQuadril;
        }
        public string ClassificacaoRCQ(float rcq, Aluno aluno)
        {
            string classificacao =  String.Empty;
            int idade = aluno.CalculaIdade();
          

            if (aluno.Sexo.Equals("M"))
            {
                if(idade < 30)
                {
                    if (rcq <0.83)
                    {
                        classificacao = "Baixo";
                    }
                    else if (rcq < 0.89)
                    {
                        classificacao = "Moderado";
                    }
                    else if (rcq < 0.95)
                    {
                        classificacao = "Alto";
                    }
                    else
                    {
                        classificacao = "Muito Alto";
                    }
                }
                else if (idade < 40)
                {
                    if (rcq < 0.84)
                    {
                        classificacao = "Baixo";
                    }
                    else if (rcq < 0.92)
                    {
                        classificacao = "Moderado";
                    }
                    else if (rcq < 0.97)
                    {
                        classificacao = "Alto";
                    }
                    else
                    {
                        classificacao = "Muito Alto";
                    }
                }
                else if (idade < 50)
                {
                    if (rcq < 0.88)
                    {
                        classificacao = "Baixo";
                    }
                    else if (rcq < 0.96)
                    {
                        classificacao = "Moderado";
                    }
                    else if (rcq < 1.00)
                    {
                        classificacao = "Alto";
                    }
                    else
                    {
                        classificacao = "Muito Alto";
                    }
                }
                else if (idade <60)
                {
                    if (rcq < 0.91)
                    {
                        classificacao = "Baixo";
                    }
                    else if (rcq < 0.99)
                    {
                        classificacao = "Moderado";
                    }
                    else if (rcq < 1.04)
                    {
                        classificacao = "Alto";
                    }
                    else
                    {
                        classificacao = "Muito Alto";
                    }
                }
                else
                {
                    if (rcq < 0.91)
                    {
                        classificacao = "Baixo";
                    }
                    else if (rcq < 0.99)
                    {
                        classificacao = "Moderado";
                    }
                    else if (rcq < 1.04)
                    {
                        classificacao = "Alto";
                    }
                    else
                    {
                        classificacao = "Muito Alto";
                    }
                }
            }

            return classificacao;
        }
    }
}
