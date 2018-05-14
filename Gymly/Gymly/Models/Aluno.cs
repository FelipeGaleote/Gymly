using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Gymly.BD;

namespace Gymly.Models
{
    class Aluno
    {
        private string cpf;
        private string nome;
        private string dataNasc;
        private string email;
        private string telefone;
        private char genero;
        private string nivel;
        private List<AvaliacaoFisica> avFisica = new List<AvaliacaoFisica>();
        private Anamnese anamnese; 

        public Aluno() { }

        public static void listaAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            alunos = BDAluno.consultaAluno();
            alunos.ForEach(i => MessageBox.Show("Nome: " + i.Nome , "Email: " + i.Email));
            
        }

        public string Nome                                                                                                      
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }


        public string DataNasc
        {
            get
            {
                return dataNasc;
            }

            set
            {
                dataNasc = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public char Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public string Nivel
        {
            get
            {
                return nivel;
            }

            set
            {
                nivel = value;
            }
        }

        public List<AvaliacaoFisica> AvFisica
        {
            get
            {
                return avFisica;
            }

            set
            {
                avFisica = value;
            }
        }

        public Anamnese Anamnese
        {
            get
            {
                return anamnese;
            }

            set
            {
                anamnese = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public static int calculaIdade(DateTime dataNasc)
        {
            int idade = DateTime.Now.Year - dataNasc.Year;
            if (DateTime.Now.Month < dataNasc.Month || (DateTime.Now.Month == dataNasc.Month && DateTime.Now.Day < dataNasc.Day))
                idade--;

            return idade;
        }

    }
}
