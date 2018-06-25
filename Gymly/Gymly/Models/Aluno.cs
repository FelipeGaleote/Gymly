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

        public int CalculaIdade()
        {
            int idade = DateTime.Now.Year - this.dataNasc.Year;
            if (DateTime.Now.Month < this.dataNasc.Day || (DateTime.Now.Month == this.dataNasc.Month && DateTime.Now.Day < this.dataNasc.Day))
                idade--;

            return idade;
        }

        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            bool ehValido;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }
            else
            {
                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;

                resto = ((resto < 2) ? 0 : 11 - resto);

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }
                resto = soma % 11;

                resto = ((resto < 2) ? 0 : 11 - resto);

                digito = digito + resto.ToString();
                ehValido = (cpf.EndsWith(digito));
            }

            return ehValido;
        }

    }
}
