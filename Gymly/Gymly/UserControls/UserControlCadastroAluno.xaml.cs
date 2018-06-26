using Gymly.BD;
using Gymly.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCadastroAluno.xaml
    /// </summary>
    public partial class UserControlCadastroAluno : System.Windows.Controls.UserControl
    {
        int caracteresCont = 0;
        private MainWindow mainWindow;
        private string caminhoFotoDeRosto;
        private string caminhoSalvarFotoDeRosto;
        private string acao;
        private Aluno aluno;
        private int dias;

        public UserControlCadastroAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.acao = "CADASTRAR";
            InitializeComponent();
            PreencheComboBoxs("mes");
            PreencheComboBoxs("ano");
        }

        public UserControlCadastroAluno(MainWindow mainWindow, Aluno aluno)
            : this(mainWindow)
        {
         
            this.aluno = aluno;
            this.acao = "Editar";
            txtBoxCpf.IsEnabled = false;
            btnCadastrarAluno.Content = "Salvar"; 
            this.aluno = aluno;
            if (aluno != null)
            {
                txtBoxNome.Text = aluno.Nome;
                txtBoxCpf.Text = aluno.Cpf;
                txtBoxEmail.Text = aluno.Email;
                txtBoxTelefone.Text = aluno.Telefone;
                comboBoxDia.Text = aluno.DataNasc.Day.ToString();
                comboBoxMes.Text = aluno.DataNasc.Month.ToString();
                comboBoxAno.Text = aluno.DataNasc.Year.ToString();
                ComboBoxNivel.Text = aluno.Nivel;
                rdMasculino.IsChecked = aluno.Sexo.ToString().Equals("M");
                rdFeminino.IsChecked = aluno.Sexo.ToString().Equals("F");
                if (aluno.CaminhoFotoDoRosto != null && !aluno.CaminhoFotoDoRosto.Equals(""))
                {
                    ImageFotoDeRosto.Source = GerenciadorDeArquivos.BuscaImagem(aluno.CaminhoFotoDoRosto);
                    btnAddFotoDeRosto.Background = Brushes.Transparent;
                    btnAddFotoDeRosto.BorderBrush = null;
                    caminhoFotoDeRosto = aluno.CaminhoFotoDoRosto;   
                }

            }

        }

        // private void buttonAtivarCalendario_Click(object sender, RoutedEventArgs e)
        //{
        // calendarDataNasc.Visibility = Visibility.Visible;
        //buttonAtivarCalendario.Visibility = Visibility.Collapsed;
        // }

        private void BtnCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {                   
            if (CamposValidos())
            {
                Aluno aluno = new Aluno
                {
                    Nome = txtBoxNome.Text,
                    Cpf = txtBoxCpf.Text,
                    Email = txtBoxEmail.Text,
                    Telefone = txtBoxTelefone.Text,
                    CaminhoFotoDoRosto = caminhoFotoDeRosto
                    
                };
                if (rdMasculino.IsChecked == true)
                {
                    aluno.Sexo = "M";
                }
                else if (rdFeminino.IsChecked == true)
                {
                    aluno.Sexo = "F";
                }
                string cpf = aluno.Cpf;
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (ComboBoxNivel.SelectedValue != null)
                {             
                    var item = ComboBoxNivel.SelectedValue as ComboBoxItem;
                    var text = item.Content.ToString();
                    aluno.Nivel = text;
                }
                if (caminhoFotoDeRosto != null && !caminhoFotoDeRosto.Equals(""))
                {
                    GerenciadorDeArquivos.AlocaPasta(cpf);
                    GerenciadorDeArquivos.AlocaPasta(cpf, "Cadastro");
                    caminhoSalvarFotoDeRosto = "Fotos\\" + cpf + "\\" + "Cadastro\\rosto" + GerenciadorDeArquivos.GetExtensao(caminhoFotoDeRosto);
                    GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoFotoDeRosto, caminhoSalvarFotoDeRosto);
                    aluno.CaminhoFotoDoRosto = caminhoSalvarFotoDeRosto;
                    System.IO.File.OpenWrite(caminhoSalvarFotoDeRosto).Close();
                }
                else if(!acao.Equals("Editar"))
                {
                    aluno.CaminhoFotoDoRosto = String.Empty;
                }
                CultureInfo culture = new CultureInfo("pt-BR");

                aluno.DataNasc = DateTime.Parse((comboBoxDia.SelectedValue + "-" + comboBoxMes.SelectedValue + "-" + comboBoxAno.SelectedValue));
                try
                {
                    if (acao.Equals("Editar"))
                    {
                        BDAluno.AtualizaAluno(aluno);
                        mainWindow.MudarUserControl("detalhesAluno", aluno.Cpf);
                    }
                    else
                    {


                        BDAluno.InsereAluno(aluno);
                        Anamnese anamnese = new Anamnese
                        {
                            CpfAluno = aluno.Cpf
                        };
                        mainWindow.MudarUserControl("cadastroAnamnese", anamnese);
                    }
                }
                catch(Exception ex)
                {
                    if (ex is System.Data.SQLite.SQLiteException && ex.Message.Equals("constraint failed\r\nUNIQUE constraint failed: ALUNOS.CPF"))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Este cpf ja foi utilizado!", "Cadastro de Aluno", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                     {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Falha ao salvar aluno no banco de dados", "Cadastro de Aluno", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void BtnAddFotoDeRosto_Click(object sender, RoutedEventArgs e)
        {
            
            caminhoFotoDeRosto = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeRosto != null && !caminhoFotoDeRosto.Equals(""))
            {
                ImageFotoDeRosto.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeRosto);
                
                btnAddFotoDeRosto.Background = Brushes.Transparent;
                btnAddFotoDeRosto.BorderBrush = null;
            }
        }
        public void PreencheComboBoxs(string nomeComboBox)
        {
            switch (nomeComboBox)
            {
                case "dia":
                    AdicionaItemNoCmB(1, dias, comboBoxDia, "ASC");
                    break;
                case "mes":
                    AdicionaItemNoCmB(1, 12, comboBoxMes, "ASC");
                    break;
                case "ano":
                    AdicionaItemNoCmB((DateTime.Now.Year - 120), DateTime.Now.Year, comboBoxAno , "DESC");
                    break;
            }
        }

        

        public void AdicionaItemNoCmB(int valorInicial, int valorFinal, System.Windows.Controls.ComboBox comboBox, string ordenacao)
        {
       
            List<string> lista = new List<string>();
            if (ordenacao.Equals("ASC"))
            {
                for (int i = valorInicial; i <= valorFinal; i++)
                {
                    lista.Add(i.ToString());
                }
            }
            else
            {
                for (int i = valorFinal; i >= valorInicial; i--)
                {
                    lista.Add(i.ToString());
                }
            }
            comboBox.ItemsSource = lista;
        }

        private void TxtBoxCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            int txtSize = txtBoxCpf.Text.Length;
            String temp = txtBoxCpf.Text;
            
            if(txtSize == 0)
            {
                caracteresCont = 0;
            }

            if( !(caracteresCont == txtSize-2) && txtSize == 12 && !temp.Substring(11, 1).Equals("-"))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 11) + "-" + temp.Substring(11, txtSize - 11);
                txtBoxCpf.Select(txtSize + 1, 0);
            }
            if (!(caracteresCont == txtSize-2) && txtSize ==8 && !temp.Substring(7,1).Equals("."))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 7) + "." + temp.Substring(7,txtSize-7);
                txtBoxCpf.Select(txtSize + 1, 0);
            }
            else if (!(caracteresCont == txtSize-2) && txtSize == 4 && !temp.Substring(3, 1).Equals("."))
            {
                caracteresCont = txtSize;
                txtBoxCpf.Text = temp.Substring(0, 3) + "." + temp.Substring(3, txtSize-3);
                txtBoxCpf.Select(txtSize+1,0);
            }
            else 
            {
                caracteresCont = txtSize;
            }
        }

        private void TxtBoxCpf_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int valor = (int)e.Key;

                if(valor == 3)
            {
                e.Handled = false;
                return;
            }

            if (txtBoxCpf.Text.Length == 14)
            {
                e.Handled = true;
                return;
            }

            if ((valor >= 34 && valor <= 43) || (valor >= 74 && valor <= 83))
            {
                hintCPF.Visibility = Visibility.Hidden;
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void TxtBoxTelefone_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int valor = (int)e.Key;
            if(valor == 3)
            {
                e.Handled = false;
                return;
            }
            if (txtBoxTelefone.Text.Length == 15)
            {
                e.Handled = true;
                return;
            }
               
            if ((valor >= 34 && valor <= 43) || (valor >= 74 && valor <= 83))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtBoxNome_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            hintNome.Visibility = Visibility.Hidden;
        }

        private void ComboBoxDia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxAno.SelectedValue != null && comboBoxMes.SelectedValue != null)
            hintDataNasc.Visibility = Visibility.Hidden;
        }

        private void ComboBoxMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxAno.SelectedValue != null)
            {
                ConfiguraData();
            }
        }

        private void ComboBoxAno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxDia.SelectedValue != null && comboBoxMes.SelectedValue != null)
            {
                hintDataNasc.Visibility = Visibility.Hidden;
            }
            if (comboBoxMes.SelectedValue != null)
            {
                ConfiguraData();
            }

            //if (!DateTime.IsLeapYear((int)comboBoxAno.SelectedValue)){


        }

        private void ConfiguraData()
        {
            int mes = Convert.ToInt32(comboBoxMes.SelectedValue);
            int ano = Convert.ToInt32(comboBoxAno.SelectedValue);
            //item = comboBoxAno.SelectedValue as ComboBoxItem;
            //texto = item.Content.ToString();

            if (comboBoxAno.SelectedValue != null && comboBoxDia.SelectedValue != null)
                hintDataNasc.Visibility = Visibility.Hidden;
            if (mes == 2)
            {
                if (!DateTime.IsLeapYear(ano))
                {
                    dias = 28;
                }
                else
                {
                    dias = 29;
                }
            }
            else if (mes == 3 || mes == 1 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                dias = 31;
            }
            else
            {
                dias = 30;
            }

            PreencheComboBoxs("dia");
            comboBoxDia.IsEnabled = true;
        }

        private bool CamposValidos()
        {
            bool todosCamposValidos = true;
            if (txtBoxCpf.Text.Equals(""))
            {
                hintCPF.Text = "Informe o CPF";
                hintCPF.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            if (txtBoxNome.Text.Equals(""))
            {
                hintNome.Text = "Informe o nome";
                hintNome.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            if (comboBoxDia.SelectedValue == null || comboBoxMes.SelectedValue == null || comboBoxAno.SelectedValue == null)
            {
                hintDataNasc.Text = "Informe a data de nascimento";
                hintDataNasc.Visibility = Visibility.Visible;
                todosCamposValidos = false;
            }
            if (!txtBoxCpf.Text.Equals("") && !Aluno.ValidaCpf(txtBoxCpf.Text)){
                hintCPF.Text = "CPF inválido";
                hintCPF.Visibility = Visibility.Visible;
                txtBoxCpf.Text = "";
                todosCamposValidos = false;
            }
            if (!ValidaEmail(txtBoxEmail.Text.ToString()))
            {
                txtBoxEmail.Text = "";
                todosCamposValidos = false;
                hintEmail.Text = "Formato de email invalido!";
                hintEmail.Visibility = Visibility.Visible;
            } else
                hintEmail.Visibility = Visibility.Hidden;
            return todosCamposValidos;
        }
        private bool ValidaEmail(String email)
        {
            if (!email.Equals(""))
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"@");
                return regex.IsMatch(email);
            }
            else
                return true;
        }

        private void TxtBoxEmail_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            hintEmail.Visibility = Visibility.Hidden;
        }
    }
}
