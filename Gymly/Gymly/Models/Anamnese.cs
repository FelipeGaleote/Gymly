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

        public int Id { get => id; set => id = value; }
        public string CpfAluno { get => cpfAluno; set => cpfAluno = value; }
        public bool HistoricoProblemaCardiaco { get => historicoProblemaCardiaco; set => historicoProblemaCardiaco = value; }
        public bool HistoricoDoresPeito { get => historicoDoresPeito; set => historicoDoresPeito = value; }
        public bool HistoricoDesmaiosOuVertigem { get => historicoDesmaiosOuVertigem; set => historicoDesmaiosOuVertigem = value; }
        public bool HistoricoPressaoAlta { get => historicoPressaoAlta; set => historicoPressaoAlta = value; }
        public bool HistoricoProblemaOsseo { get => historicoProblemaOsseo; set => historicoProblemaOsseo = value; }
        public bool DoencaCardiacaCoronariana { get => doencaCardiacaCoronariana; set => doencaCardiacaCoronariana = value; }
        public bool DoencaCardiacaReumatica { get => doencaCardiacaReumatica; set => doencaCardiacaReumatica = value; }
        public bool DoencaCardiacaCongenita { get => doencaCardiacaCongenita; set => doencaCardiacaCongenita = value; }
        public bool BatimentosCardiacosIrregulares { get => batimentosCardiacosIrregulares; set => batimentosCardiacosIrregulares = value; }
        public bool ProblemaValvulasCardiacas { get => problemaValvulasCardiacas; set => problemaValvulasCardiacas = value; }
        public bool MurmuriosCardiacos { get => murmuriosCardiacos; set => murmuriosCardiacos = value; }
        public bool AtaqueCardiaco { get => ataqueCardiaco; set => ataqueCardiaco = value; }
        public bool DerrameCerebral { get => derrameCerebral; set => derrameCerebral = value; }
        public bool Epilepsia { get => epilepsia; set => epilepsia = value; }
        public bool Diabetes { get => diabetes; set => diabetes = value; }
        public bool Hipertensao { get => hipertensao; set => hipertensao = value; }
        public bool Cancer { get => cancer; set => cancer = value; }
        public bool DorCostas { get => dorCostas; set => dorCostas = value; }
        public bool DorArticulacao { get => dorArticulacao; set => dorArticulacao = value; }
        public bool DorPulmonar { get => dorPulmonar; set => dorPulmonar = value; }
        public bool Gestante { get => gestante; set => gestante = value; }
        public bool Fumante { get => fumante; set => fumante = value; }
        public bool BebidaAlcoolica { get => bebidaAlcoolica; set => bebidaAlcoolica = value; }
        public bool PerderPeso { get => perderPeso; set => perderPeso = value; }
        public bool MelhorarFlexibilidade { get => melhorarFlexibilidade; set => melhorarFlexibilidade = value; }
        public bool DiminuirVicios { get => diminuirVicios; set => diminuirVicios = value; }
        public bool ReduzirDores { get => reduzirDores; set => reduzirDores = value; }
        public bool MelhorarNutricao { get => melhorarNutricao; set => melhorarNutricao = value; }
        public bool MelhorarAptidao { get => melhorarAptidao; set => melhorarAptidao = value; }
        public bool MelhorarMuscular { get => melhorarMuscular; set => melhorarMuscular = value; }
        public bool ReduzirEstresse { get => reduzirEstresse; set => reduzirEstresse = value; }
        public bool SentirMelhor { get => sentirMelhor; set => sentirMelhor = value; }
        public bool Hipertrofia { get => hipertrofia; set => hipertrofia = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public bool IdosoNaoAcostumado { get => idosoNaoAcostumado; set => idosoNaoAcostumado = value; }
    }
}
