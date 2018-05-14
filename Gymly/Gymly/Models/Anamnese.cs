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
        private bool historico_problema_cardiaco;
        private bool historico_dores_peito;
        private bool historico_desmaios_ou_vertigem;
        private bool historico_pressao_alta;
        private bool historico_problema_osseo;
        private bool idoso_nao_acostumado;
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
        private bool dor_costas;
        private bool dor_articulacao;
        private bool dor_pulmonar;
        private bool gestante;
        private bool fumante;
        private bool bebida_alcoolica;
        private bool perder_peso;
        private bool diminuir_vicios;
        private bool reduzir_dores;
        private bool melhorar_nutricao;
        private bool melhorar_aptidao;
        private bool melhorar_muscular;
        private bool melhorar_flexibilidade;
        private bool reduzir_estresse;
        private bool sentir_melhor;
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

        public bool Historico_problema_cardiaco
        {
            get
            {
                return historico_problema_cardiaco;
            }

            set
            {
                historico_problema_cardiaco = value;
            }
        }

        public bool Historico_dores_peito
        {
            get
            {
                return historico_dores_peito;
            }

            set
            {
                historico_dores_peito = value;
            }
        }

        public bool Historico_desmaios_ou_vertigem
        {
            get
            {
                return historico_desmaios_ou_vertigem;
            }

            set
            {
                historico_desmaios_ou_vertigem = value;
            }
        }

        public bool Historico_pressao_alta
        {
            get
            {
                return historico_pressao_alta;
            }

            set
            {
                historico_pressao_alta = value;
            }
        }

        public bool Historico_problema_osseo
        {
            get
            {
                return historico_problema_osseo;
            }

            set
            {
                historico_problema_osseo = value;
            }
        }

        public bool Idoso_nao_acostumado
        {
            get
            {
                return idoso_nao_acostumado;
            }

            set
            {
                idoso_nao_acostumado = value;
            }
        }

        public bool Doenca_cardiaca_coronariana
        {
            get
            {
                return doenca_cardiaca_coronariana;
            }

            set
            {
                doenca_cardiaca_coronariana = value;
            }
        }

        public bool Doenca_cardiaca_reumatica
        {
            get
            {
                return doenca_cardiaca_reumatica;
            }

            set
            {
                doenca_cardiaca_reumatica = value;
            }
        }

        public bool Doenca_cardiaca_congenita
        {
            get
            {
                return doenca_cardiaca_congenita;
            }

            set
            {
                doenca_cardiaca_congenita = value;
            }
        }

        public bool Batimentos_cardiacos_irregulares
        {
            get
            {
                return batimentos_cardiacos_irregulares;
            }

            set
            {
                batimentos_cardiacos_irregulares = value;
            }
        }

        public bool Problema_valvulas_cardiacas
        {
            get
            {
                return problema_valvulas_cardiacas;
            }

            set
            {
                problema_valvulas_cardiacas = value;
            }
        }

        public bool Murmurios_cardiacos
        {
            get
            {
                return murmurios_cardiacos;
            }

            set
            {
                murmurios_cardiacos = value;
            }
        }

        public bool Ataque_cardiaco
        {
            get
            {
                return ataque_cardiaco;
            }

            set
            {
                ataque_cardiaco = value;
            }
        }

        public bool Derrame_cerebral
        {
            get
            {
                return derrame_cerebral;
            }

            set
            {
                derrame_cerebral = value;
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

        public bool Dor_costas
        {
            get
            {
                return dor_costas;
            }

            set
            {
                dor_costas = value;
            }
        }

        public bool Dor_articulacao
        {
            get
            {
                return dor_articulacao;
            }

            set
            {
                dor_articulacao = value;
            }
        }

        public bool Dor_pulmonar
        {
            get
            {
                return dor_pulmonar;
            }

            set
            {
                dor_pulmonar = value;
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

        public bool Bebida_alcoolica
        {
            get
            {
                return bebida_alcoolica;
            }

            set
            {
                bebida_alcoolica = value;
            }
        }

        public bool Perder_peso
        {
            get
            {
                return perder_peso;
            }

            set
            {
                perder_peso = value;
            }
        }

        public bool Diminuir_vicios
        {
            get
            {
                return diminuir_vicios;
            }

            set
            {
                diminuir_vicios = value;
            }
        }

        public bool Reduzir_dores
        {
            get
            {
                return reduzir_dores;
            }

            set
            {
                reduzir_dores = value;
            }
        }

        public bool Melhorar_nutricao
        {
            get
            {
                return melhorar_nutricao;
            }

            set
            {
                melhorar_nutricao = value;
            }
        }

        public bool Melhorar_aptidao
        {
            get
            {
                return melhorar_aptidao;
            }

            set
            {
                melhorar_aptidao = value;
            }
        }

        public bool Melhorar_muscular
        {
            get
            {
                return melhorar_muscular;
            }

            set
            {
                melhorar_muscular = value;
            }
        }

        public bool Melhorar_flexibilidade
        {
            get
            {
                return melhorar_flexibilidade;
            }

            set
            {
                melhorar_flexibilidade = value;
            }
        }

        public bool Reduzir_estresse
        {
            get
            {
                return reduzir_estresse;
            }

            set
            {
                reduzir_estresse = value;
            }
        }

        public bool Sentir_melhor
        {
            get
            {
                return sentir_melhor;
            }

            set
            {
                sentir_melhor = value;
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
