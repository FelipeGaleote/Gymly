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
using Gymly.Models;

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
            MudarUserControl("telaInicial");  
        }
        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
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
            MudarUserControl("telaInicial");
        }

        public void MudarUserControl(String nomeDoControl)
        {
            pnl.Children.Clear();
            switch (nomeDoControl)
            {
                case "telaInicial":
                    pnl.Children.Add(new UserControlTelaInicial(this));
                    break;
                case "aluno":
                    pnl.Children.Add(new UserControlAluno(this));
                    break;
                case "cadastroAluno":
                    pnl.Children.Add(new UserControlCadastroAluno(this));
                    break;
                case "configuracao":
                    pnl.Children.Add(new UserControlConfiguracao(this));
                    break;
            }
        }
        public void MudarUserControl(String nomeDoControl, Anamnese anamnese)
        {
            pnl.Children.Clear();
            switch (nomeDoControl)
            {
                case "cadastroAnamnese":
                    pnl.Children.Add(new UserControlCadastroAnamnese(this, anamnese));
                    break;
                case "cadastroAnamneseProximaEtapa":
                    pnl.Children.Add(new UserControlCadastroAnamneseProximaEtapa(this, anamnese));
                    break;
                case "cadastroAnamneseProximaEtapa2":
                    pnl.Children.Add(new UserControlCadastroAnamneseProximaEtapa2(this, anamnese));
                    break;
                case "cadastroAnamneseProximaEtapa3":
                    pnl.Children.Add(new UserControlCadastroAnamneseProximaEtapa3(this, anamnese));
                    break;
                case "cadastroAnamneseProximaEtapaFinal":
                    pnl.Children.Add(new UserControlCadastroAnamneseProximaEtapaFinal(this, anamnese));
                    break;
            }
        }
        public void MudarUserControl(String nomeDoControl, AvaliacaoFisica avaliacaoFisica)
        {
            pnl.Children.Clear();
            switch (nomeDoControl)
            {
                case "selecionarTipoAvalicaoFisica":
                    pnl.Children.Add(new UserControlTipoAvaliacaoFisica(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisica":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisica(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa2_Antropometria":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa2_Antropometria(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa3":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa3(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa4":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa4(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa5":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa5(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapa6":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapa6(this, avaliacaoFisica));
                    break;
                case "cadastroAvaliacaoFisicaProximaEtapaFinal":
                    pnl.Children.Add(new UserControlCadastroAvaliacaoFisicaProximaEtapaFinal(this, avaliacaoFisica));
                    break;
            }

        }
        public void MudarUserControl(String nomeDoControl, String parametroAdicional)
        {
            pnl.Children.Clear();
            switch (nomeDoControl)
            {
                case "detalhesAluno":
                    pnl.Children.Add(new UserControlDetalhesAluno(parametroAdicional,this));
                    break;
            }
        }

        private void BtnConfiguracao_Click(object sender, RoutedEventArgs e)
        {
            MudarUserControl("configuracao");
        }

        private void BtnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

