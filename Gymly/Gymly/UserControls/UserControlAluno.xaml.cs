using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Gymly.BD;
using Gymly.Models;

namespace Gymly.UserControls
{

    public partial class UserControlAluno : UserControl, INotifyPropertyChanged
    {

        private string txtBoxTextoConsultaAluno = "Consultar Alunos";

        public UserControlAluno()
        {
            InitializeComponent();
            DataContext = this;
            txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
            txtBoxConsultaAluno.Foreground = Brushes.Gray;

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarPropriedadeAlterada(string propriedade)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private void txtBoxConsultaAluno_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxConsultaAluno.Clear();
            txtBoxConsultaAluno.Foreground = Brushes.Black;
        }

        private void txtBoxConsultaAluno_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtBoxConsultaAluno.Text == String.Empty)
            {
                txtBoxConsultaAluno.Text = txtBoxTextoConsultaAluno;
                txtBoxConsultaAluno.Foreground = Brushes.Gray;
            }
        }

        private void btnCadastraAluno_Click(object sender, RoutedEventArgs e)
        {
            BDAluno.insereAluno();
            List<Aluno> alunos = BDAluno.consultaAluno();
            foreach(Aluno a in alunos)
                Console.WriteLine(a.Nome +" "+ a.Email);
        
        }

        private void btnEditarAnamnese_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Collapsed;
            pnl.Children.Clear();
            pnl.Children.Add(new UserControlGrafico());
        }
    }
}