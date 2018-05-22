using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    public class Anamnese {
        private int id;
        private string cpfAluno; //Capturar da seleção no datagrid
        private bool historicoProblemaCardiaco;
        private bool historicoDoresPeito;
        private bool historicoDesmaiosOuVertigem;
        private bool historicoPressaoAlta;
        private bool historicoProblemaOsseo;
        private bool idosoNaoAcostumado;
        private bool doencaCardiacaCoronariana;
        private bool doencaCardiacaReumatica;
        private bool doencaCardiacaCongenita;
        private bool batimentosCardiacosIrregulares;
        private bool problemaValvulasCardiacas;
        private bool murmuriosCardiacos;
        private bool ataqueCardiaco;
        private bool derrameCerebral;
        private bool epilepsia;
        private bool diabetes;
        private bool hipertensao;
        private bool cancer;
        private bool dorCostas;
        private bool dorArticulacao;
        private bool dorPulmonar;
        private bool gestante;
        private bool fumante;
        private bool bebidaAlcoolica;
        private bool perderPeso;
        private bool melhorarFlexibilidade;
        private bool diminuirVicios;
        private bool reduzirDores;
        private bool melhorarNutricao;
        private bool melhorarAptidao;
        private bool melhorarMuscular;
        private bool reduzirEstresse;
        private bool sentirMelhor;
        private bool hipertrofia;
        private string observacao;

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

        public bool HistoricoProblemaCardiaco
        {
            get
            {
                return historicoProblemaCardiaco;
            }

            set
            {
                historicoProblemaCardiaco = value;
            }
        }

        public bool HistoricoDoresPeito
        {
            get
            {
                return historicoDoresPeito;
            }

            set
            {
                historicoDoresPeito = value;
            }
        }

        public bool HistoricoDesmaiosOuVertigem
        {
            get
            {
                return historicoDesmaiosOuVertigem;
            }

            set
            {
                historicoDesmaiosOuVertigem = value;
            }
        }

        public bool HistoricoPressaoAlta
        {
            get
            {
                return historicoPressaoAlta;
            }

            set
            {
                historicoPressaoAlta = value;
            }
        }

        public bool HistoricoProblemaOsseo
        {
            get
            {
                return historicoProblemaOsseo;
            }

            set
            {
                historicoProblemaOsseo = value;
            }
        }

        public bool IdosoNaoAcostumado
        {
            get
            {
                return idosoNaoAcostumado;
            }

            set
            {
                idosoNaoAcostumado = value;
            }
        }

        public bool DoencaCardiacaCoronariana
        {
            get
            {
                return doencaCardiacaCoronariana;
            }

            set
            {
                doencaCardiacaCoronariana = value;
            }
        }

        public bool DoencaCardiacaReumatica
        {
            get
            {
                return doencaCardiacaReumatica;
            }

            set
            {
                doencaCardiacaReumatica = value;
            }
        }

        public bool DoencaCardiacaCongenita
        {
            get
            {
                return doencaCardiacaCongenita;
            }

            set
            {
                doencaCardiacaCongenita = value;
            }
        }

        public bool BatimentosCardiacosIrregulares
        {
            get
            {
                return batimentosCardiacosIrregulares;
            }

            set
            {
                batimentosCardiacosIrregulares = value;
            }
        }

        public bool ProblemaValvulasCardiacas
        {
            get
            {
                return problemaValvulasCardiacas;
            }

            set
            {
                problemaValvulasCardiacas = value;
            }
        }

        public bool MurmuriosCardiacos
        {
            get
            {
                return murmuriosCardiacos;
            }

            set
            {
                murmuriosCardiacos = value;
            }
        }

        public bool AtaqueCardiaco
        {
            get
            {
                return ataqueCardiaco;
            }

            set
            {
                ataqueCardiaco = value;
            }
        }

        public bool DerrameCerebral
        {
            get
            {
                return derrameCerebral;
            }

            set
            {
                derrameCerebral = value;
            }
        }

        public bool Epilepsia
        {
            get
            {
                return epilepsia;
            }

            set
            {
                epilepsia = value;
            }
        }

        public bool Diabetes
        {
            get
            {
                return diabetes;
            }

            set
            {
                diabetes = value;
            }
        }

        public bool Hipertensao
        {
            get
            {
                return hipertensao;
            }

            set
            {
                hipertensao = value;
            }
        }

        public bool Cancer
        {
            get
            {
                return cancer;
            }

            set
            {
                cancer = value;
            }
        }

        public bool DorCostas
        {
            get
            {
                return dorCostas;
            }

            set
            {
                dorCostas = value;
            }
        }

        public bool DorArticulacao
        {
            get
            {
                return dorArticulacao;
            }

            set
            {
                dorArticulacao = value;
            }
        }

        public bool DorPulmonar
        {
            get
            {
                return dorPulmonar;
            }

            set
            {
                dorPulmonar = value;
            }
        }

        public bool Gestante
        {
            get
            {
                return gestante;
            }

            set
            {
                gestante = value;
            }
        }

        public bool Fumante
        {
            get
            {
                return fumante;
            }

            set
            {
                fumante = value;
            }
        }

        public bool BebidaAlcoolica
        {
            get
            {
                return bebidaAlcoolica;
            }

            set
            {
                bebidaAlcoolica = value;
            }
        }

        public bool PerderPeso
        {
            get
            {
                return perderPeso;
            }

            set
            {
                perderPeso = value;
            }
        }

        public bool MelhorarFlexibilidade
        {
            get
            {
                return melhorarFlexibilidade;
            }

            set
            {
                melhorarFlexibilidade = value;
            }
        }

        public bool DiminuirVicios
        {
            get
            {
                return diminuirVicios;
            }

            set
            {
                diminuirVicios = value;
            }
        }

        public bool ReduzirDores
        {
            get
            {
                return reduzirDores;
            }

            set
            {
                reduzirDores = value;
            }
        }

        public bool MelhorarNutricao
        {
            get
            {
                return melhorarNutricao;
            }

            set
            {
                melhorarNutricao = value;
            }
        }

        public bool MelhorarAptidao
        {
            get
            {
                return melhorarAptidao;
            }

            set
            {
                melhorarAptidao = value;
            }
        }

        public bool MelhorarMuscular
        {
            get
            {
                return melhorarMuscular;
            }

            set
            {
                melhorarMuscular = value;
            }
        }

        public bool ReduzirEstresse
        {
            get
            {
                return reduzirEstresse;
            }

            set
            {
                reduzirEstresse = value;
            }
        }

        public bool SentirMelhor
        {
            get
            {
                return sentirMelhor;
            }

            set
            {
                sentirMelhor = value;
            }
        }

        public bool Hipertrofia
        {
            get
            {
                return hipertrofia;
            }

            set
            {
                hipertrofia = value;
            }
        }

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }
    }
}
