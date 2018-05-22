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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.DataGrid;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCadastroAluno.xaml
    /// </summary>
    public partial class UserControlCadastroAluno : System.Windows.Controls.UserControl
    {
        private MainWindow mainWindow;
        private string caminhoFotoDeRosto;

        public UserControlCadastroAluno(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

       // private void buttonAtivarCalendario_Click(object sender, RoutedEventArgs e)
        //{
           // calendarDataNasc.Visibility = Visibility.Visible;
            //buttonAtivarCalendario.Visibility = Visibility.Collapsed;
       // }

        private void BtnCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {
            Aluno aluno = new Aluno
            {
                Nome = txtBoxNome.Text,
                Cpf = txtBoxCpf.Text,
                Email = txtBoxEmail.Text,
                Telefone = txtBoxTelefone.Text
            };
            if (rdMasculino.IsChecked == true)
            {
                aluno.Sexo = 'M';
            } else if(rdFeminino.IsChecked == true)
            {
                aluno.Sexo = 'F';
            }
            aluno.Nivel = ComboBoxNivel.SelectedValue.ToString();
            aluno.CaminhoFotoDoRosto = caminhoFotoDeRosto;
            CultureInfo culture = new CultureInfo("pt-BR");
            aluno.DataNasc = Convert.ToDateTime(txtBoxDataNascimento.Text, culture);
            BDAluno.InsereAluno(aluno);
            mainWindow.MudarUserControl("aluno");
        }

        private void BtnAddFotoDeRosto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*",
                RestoreDirectory = true,
                Multiselect = false
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                caminhoFotoDeRosto = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(caminhoFotoDeRosto);
                bitmap.EndInit();
                ImageFotoDeRosto.Source = bitmap;
                btnAddFotoDeRosto.Background = Brushes.Transparent;
                btnAddFotoDeRosto.BorderBrush = null;
            }
        }
    }
}
