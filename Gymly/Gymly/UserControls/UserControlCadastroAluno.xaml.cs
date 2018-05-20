using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gymly.Models;
using Gymly.BD;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCadastroAluno.xaml
    /// </summary>
    public partial class UserControlCadastroAluno : UserControl
    {
        private MainWindow mainWindow;
        public UserControlCadastroAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void buttonAtivarCalendario_Click(object sender, RoutedEventArgs e)
        {
            calendarDataNasc.Visibility = Visibility.Visible;
            //buttonAtivarCalendario.Visibility = Visibility.Collapsed;
        }

        private void btnCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtBoxNome.Text;
            aluno.Cpf = txtBoxCpf.Text;
            aluno.Email = txtBoxEmail.Text;
            aluno.Telefone = txtBoxTelefone.Text;
            if(rdMasculino.IsChecked == true)
            {
                aluno.Sexo = 'M';
            } else if(rdFeminino.IsChecked == true)
            {
                aluno.Sexo = 'F';
            }
            aluno.Nivel = ComboBoxNivel.SelectedValue.ToString();
            aluno.DataNasc = calendarDataNasc.SelectedDate.Value;
            BDAluno.insereAluno(aluno);
            mainWindow.mudarUserControl("aluno");
        }
    }
}
