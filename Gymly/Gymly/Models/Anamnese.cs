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
        private bool HistoricoProblemaCardiaco;
        private bool HistoricoDoresPeito;
        private bool HistoricoDesmaiosOuVertigem;
        private bool HistoricoPressaoAlta;
        private bool HistoricoProblemaOsseo;
        private bool IdosoNaoAcostumado;
        private bool DoencaCardiacaCoronariana;
        private bool DoencaCardiacaReumatica;
        private bool DoencaCardiacaCongenita;
        private bool BatimentosCardiacosIrregulares;
        private bool ProblemaValvulasCardiacas;
        private bool MurmuriosCardiacos;
        private bool AtaqueCardiaco;
        private bool DerrameCerebral;
        private bool Epilepsia;
        private bool Diabetes;
        private bool Hipertensao;
        private bool Cancer;
        private bool DorCostas;
        private bool DorArticulacao;
        private bool DorPulmonar;
        private bool gestante;
        private bool Fumante;
        private bool BebidaAlcoolica;
        private bool PerderPeso;
        private bool MelhorarFlexibilidade;
        private bool DiminuirVicios;
        private bool ReduzirDores;
        private bool MelhorarNutricao;
        private bool MelhorarAptidao;
        private bool MelhorarMuscular;
        private bool ReduzirEstresse;
        private bool SentirMelhor;
        private bool hipertrofia;
        private string observacao;

        public int Id { get => id; set => id = value; }
        public string CpfAluno { get => cpfAluno; set => cpfAluno = value; }
        public bool HistoricoProblemaCardiaco1 { get => HistoricoProblemaCardiaco; set => HistoricoProblemaCardiaco = value; }
        public bool HistoricoDoresPeito1 { get => HistoricoDoresPeito; set => HistoricoDoresPeito = value; }
        public bool HistoricoDesmaiosOuVertigem1 { get => HistoricoDesmaiosOuVertigem; set => HistoricoDesmaiosOuVertigem = value; }
        public bool HistoricoPressaoAlta1 { get => HistoricoPressaoAlta; set => HistoricoPressaoAlta = value; }
        public bool HistoricoProblemaOsseo1 { get => HistoricoProblemaOsseo; set => HistoricoProblemaOsseo = value; }
        public bool IdosoNaoAcostumado1 { get => IdosoNaoAcostumado; set => IdosoNaoAcostumado = value; }
        public bool DoencaCardiacaCoronariana1 { get => DoencaCardiacaCoronariana; set => DoencaCardiacaCoronariana = value; }
        public bool DoencaCardiacaReumatica1 { get => DoencaCardiacaReumatica; set => DoencaCardiacaReumatica = value; }
        public bool DoencaCardiacaCongenita1 { get => DoencaCardiacaCongenita; set => DoencaCardiacaCongenita = value; }
        public bool BatimentosCardiacosIrregulares1 { get => BatimentosCardiacosIrregulares; set => BatimentosCardiacosIrregulares = value; }
        public bool ProblemaValvulasCardiacas1 { get => ProblemaValvulasCardiacas; set => ProblemaValvulasCardiacas = value; }
        public bool MurmuriosCardiacos1 { get => MurmuriosCardiacos; set => MurmuriosCardiacos = value; }
        public bool AtaqueCardiaco1 { get => AtaqueCardiaco; set => AtaqueCardiaco = value; }
        public bool DerrameCerebral1 { get => DerrameCerebral; set => DerrameCerebral = value; }
        public bool Epilepsia1 { get => Epilepsia; set => Epilepsia = value; }
        public bool Diabetes1 { get => Diabetes; set => Diabetes = value; }
        public bool Hipertensao1 { get => Hipertensao; set => Hipertensao = value; }
        public bool Cancer1 { get => Cancer; set => Cancer = value; }
        public bool DorCostas1 { get => DorCostas; set => DorCostas = value; }
        public bool DorArticulacao1 { get => DorArticulacao; set => DorArticulacao = value; }
        public bool DorPulmonar1 { get => DorPulmonar; set => DorPulmonar = value; }
        public bool Gestante { get => gestante; set => gestante = value; }
        public bool Fumante1 { get => Fumante; set => Fumante = value; }
        public bool BebidaAlcoolica1 { get => BebidaAlcoolica; set => BebidaAlcoolica = value; }
        public bool PerderPeso1 { get => PerderPeso; set => PerderPeso = value; }
        public bool MelhorarFlexibilidade1 { get => MelhorarFlexibilidade; set => MelhorarFlexibilidade = value; }
        public bool DiminuirVicios1 { get => DiminuirVicios; set => DiminuirVicios = value; }
        public bool ReduzirDores1 { get => ReduzirDores; set => ReduzirDores = value; }
        public bool MelhorarNutricao1 { get => MelhorarNutricao; set => MelhorarNutricao = value; }
        public bool MelhorarAptidao1 { get => MelhorarAptidao; set => MelhorarAptidao = value; }
        public bool MelhorarMuscular1 { get => MelhorarMuscular; set => MelhorarMuscular = value; }
        public bool ReduzirEstresse1 { get => ReduzirEstresse; set => ReduzirEstresse = value; }
        public bool SentirMelhor1 { get => SentirMelhor; set => SentirMelhor = value; }
        public bool Hipertrofia { get => hipertrofia; set => hipertrofia = value; }
        public string Observacao { get => observacao; set => observacao = value; }
    }
}
