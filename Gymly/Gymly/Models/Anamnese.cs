using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymly.Models
{
    public class Anamnese { 
        private int id;
        private string cpfAluno;
        private bool historico_problema_cardiaco;
        private bool historico_dores_peito;
        private bool historico_desmaios_ou_vertigem;
        private bool historico_pressao_alta;
        private bool historico_problema_osseo;
        private bool razao_fisica;
        private bool idoso_regular;
        private bool doenca_cardiaca_coronariana;
        private bool doenca_cardiaca_reumatica;
        private bool doenca_cardiaca_congenita;
        private bool batimentos_cardiacos_irregulares;
        private bool problema_valvulas_cardiacas;
        private bool murmurios_cardiacos;
        private bool ataque_cardiaco;
        private bool derrame_cerebral;
        private bool epilepsia;
        private bool diabetes;
        private bool hipertensao;
        private bool cancer;
        private bool dor_articulacao;
        private bool dor_pulmonar;
        private bool problema_recente_parente;
        private bool restricao_fisica;
        private bool gestante;
        private bool fumante;
        private bool bebida_alcoolica;
        private bool todos_grupos_alimentares;
        private bool alta_gordura_saturada;
        private bool perder_peso;
        private bool parar_fumar;
        private bool reduzir_dores_costas;
        private bool melhorar_nutricao;
        private bool melhorar_aptidao;
        private bool melhorar_muscular;
        private bool reduzir_estresse;
        private bool diminuir_colesterol;
        private bool sentir_melhor;



        public int Id { get => id; set => id = value; }
        public string Cpf { get => Cpf; set => Cpf = value; }
        public bool Historico_problema_cardiaco { get => historico_problema_cardiaco; set => historico_problema_cardiaco = value; }
        public bool Historico_dores_peito { get => historico_dores_peito; set => historico_dores_peito = value; }
        public bool Historico_desmaios_ou_vertigem { get => historico_desmaios_ou_vertigem; set => historico_desmaios_ou_vertigem = value; }
        public bool Historico_pressao_alta { get => historico_pressao_alta; set => historico_pressao_alta = value; }
        public bool Historico_problema_osseo { get => historico_problema_osseo; set => historico_problema_osseo = value; }
        public bool Razao_fisica { get => razao_fisica; set => razao_fisica = value; }
        public bool Idoso_regular { get => idoso_regular; set => idoso_regular = value; }
        public bool Doenca_cardiaca_coronariana { get => doenca_cardiaca_coronariana; set => doenca_cardiaca_coronariana = value; }
        public bool Doenca_cardiaca_reumatica { get => doenca_cardiaca_reumatica; set => doenca_cardiaca_reumatica = value; }
        public bool Doenca_cardiaca_congenita { get => doenca_cardiaca_congenita; set => doenca_cardiaca_congenita = value; }
        public bool Batimentos_cardiacos_irregulares { get => batimentos_cardiacos_irregulares; set => batimentos_cardiacos_irregulares = value; }
        public bool Problema_valvulas_cardiacas { get => problema_valvulas_cardiacas; set => problema_valvulas_cardiacas = value; }
        public bool Murmurios_cardiacos { get => murmurios_cardiacos; set => murmurios_cardiacos = value; }
        public bool Ataque_cardiaco { get => ataque_cardiaco; set => ataque_cardiaco = value; }
        public bool Derrame_cerebral { get => derrame_cerebral; set => derrame_cerebral = value; }
        public bool Epilepsia { get => epilepsia; set => epilepsia = value; }
        public bool Diabetes { get => diabetes; set => diabetes = value; }
        public bool Hipertensao { get => hipertensao; set => hipertensao = value; }
        public bool Cancer { get => cancer; set => cancer = value; }
        public bool Dor_articulacao { get => dor_articulacao; set => dor_articulacao = value; }
        public bool Dor_pulmonar { get => dor_pulmonar; set => dor_pulmonar = value; }
        public bool Problema_recente_parente { get => problema_recente_parente; set => problema_recente_parente = value; }
        public bool Restricao_fisica { get => restricao_fisica; set => restricao_fisica = value; }
        public bool Gestante { get => gestante; set => gestante = value; }
        public bool Fumante { get => fumante; set => fumante = value; }
        public bool Bebida_alcoolica { get => bebida_alcoolica; set => bebida_alcoolica = value; }
        public bool Todos_grupos_alimentares { get => todos_grupos_alimentares; set => todos_grupos_alimentares = value; }
        public bool Alta_gordura_saturada { get => alta_gordura_saturada; set => alta_gordura_saturada = value; }
        public bool Perder_peso { get => perder_peso; set => perder_peso = value; }
        public bool Parar_fumar { get => parar_fumar; set => parar_fumar = value; }
        public bool Reduzir_dores_costas { get => reduzir_dores_costas; set => reduzir_dores_costas = value; }
        public bool Melhorar_nutricao { get => melhorar_nutricao; set => melhorar_nutricao = value; }
        public bool Melhorar_aptidao { get => melhorar_aptidao; set => melhorar_aptidao = value; }
        public bool Melhorar_muscular { get => melhorar_muscular; set => melhorar_muscular = value; }
        public bool Reduzir_estresse { get => reduzir_estresse; set => reduzir_estresse = value; }
        public bool Diminuir_colesterol { get => diminuir_colesterol; set => diminuir_colesterol = value; }
        public bool Sentir_melhor { get => sentir_melhor; set => sentir_melhor = value; }

    }
}
