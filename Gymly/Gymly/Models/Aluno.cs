using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Gymly.BD;

namespace Gymly.Models
{
    public class Aluno
    {
        private string cpf;
        private string nome;
        private DateTime dataNasc;
        private string email;
        private string telefone;
        private string sexo;
        private string nivel;
        private string caminhoFotoDoRosto;
        private Anamnese anamnese; 

        public Aluno() { }

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

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
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

        public List<AvaliacaoFisica> AvFisica { get; set; } = new List<AvaliacaoFisica>();

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

        public DateTime DataNasc
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

        public string CaminhoFotoDoRosto
        {
            get
            {
                return caminhoFotoDoRosto;
            }
            set
            {
                caminhoFotoDoRosto = value;
            }
        }

        public static int CalculaIdade(Aluno aluno)
        {
            int idade = DateTime.Now.Year - aluno.dataNasc.Year;
            MessageBox.Show(aluno.dataNasc.ToString());
            if (DateTime.Now.Month < aluno.dataNasc.Day || (DateTime.Now.Month == aluno.dataNasc.Month && DateTime.Now.Day < aluno.dataNasc.Day))
                idade--;

            return idade;
        }

    }
}
