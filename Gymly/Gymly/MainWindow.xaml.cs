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
using System.Windows.Threading;
using Gymly.UserControls;

namespace Gymly
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartClock();
        }
        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Tickevent;
            timer.Start();
        }

        private void Tickevent(object sender, EventArgs e)
        {
            txtBlockHora.Text = (FormatStringDate(DateTime.Now.TimeOfDay.Hours) + ":" + FormatStringDate(DateTime.Now.TimeOfDay.Minutes) + ":" + FormatStringDate(DateTime.Now.TimeOfDay.Seconds));
        }

        private string FormatStringDate(int number)
        {
            return (number < 10) ? ("0" + number) : number.ToString();
        }
        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnGymly_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Collapsed;
            pnl.Children.Clear();
            pnl.Children.Add(new UserControlTelaInicial());
        }
        private void BtnAluno_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Collapsed;
            pnl.Children.Clear();
            pnl.Children.Add(new UserControlAluno(this));
        }
        private void BtnAvaliacaoFisica_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Collapsed;
            pnl.Children.Clear();
            pnl.Children.Add(new UserControlAvaliacaoFisica());
        }
        private void BtnGrafico_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Collapsed;
            pnl.Children.Clear();
            pnl.Children.Add(new UserControlGrafico());
        }

       public void mudarUserControl(String nomeDoControl)
        {
            pnl.Children.Clear();
            switch (nomeDoControl)
            {
                case "cadastroAluno":
                    pnl.Children.Add(new UserControlCadastroAluno());
                    break;
                case "cadastroAnamnese":
                    break;
            }
        }
    }
}
