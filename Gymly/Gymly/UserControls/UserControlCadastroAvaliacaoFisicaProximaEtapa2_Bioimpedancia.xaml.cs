using Gymly.Models;
using System.Windows.Controls;
namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia : UserControl
    {

        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoPorcent = "%";
        private string txtBoxTextoTaxa = "cal";
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa2_Bioimpedancia(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica,string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            InitializeComponent();
            this.acao = acao;
            AdicionaObservacoesNosCampos(acao);
        }
        public void AdicionaObservacoesNosCampos(string acao)
        {
            if (acao.Equals("Editar"))
            {
                txtBoxPorcentagemDeAguaNoCorpo.Text = avaliacaoFisica.PorcentagemAguaCorpo.ToString();
                txtBoxPorcentagemDeAguaNoMusculo.Text = avaliacaoFisica.PorcentagemAguaMusculo.ToString();
                txtBoxPorcentagemGorduraCorporal.Text = avaliacaoFisica.PorcentagemGorduraCorporal.ToString();
                txtBoxTaxaMetabolicaBasal.Text = avaliacaoFisica.TaxaMetabolicaBasal.ToString();
            }
            else
            {
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPorcentagemDeAguaNoCorpo, txtBoxTextoPorcent);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPorcentagemDeAguaNoMusculo, txtBoxTextoPorcent);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxPorcentagemGorduraCorporal, txtBoxTextoPorcent);
                EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxTaxaMetabolicaBasal, txtBoxTextoTaxa);

            }
        }

        private void TxtBoxPorcentagemGorduraCorporal_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPorcentagemGorduraCorporal);
        }

        private void TxtBoxPorcentagemGorduraCorporal_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPorcentagemGorduraCorporal, txtBoxTextoPorcent);
        }

        private void TxtBoxPorcentagemDeAguaNoCorpo_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPorcentagemDeAguaNoCorpo);
        }

        private void TxtBoxPorcentagemDeAguaNoCorpo_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPorcentagemDeAguaNoCorpo, txtBoxTextoPorcent);
        }

        private void TxtBoxTaxaMetabolicaBasal_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxTaxaMetabolicaBasal);
        }

        private void TxtBoxTaxaMetabolicaBasal_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxTaxaMetabolicaBasal, txtBoxTextoTaxa);
        }

        private void TxtBoxPorcentagemDeAguaNoMusculo_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxPorcentagemDeAguaNoMusculo);
        }

        private void TxtBoxPorcentagemDeAguaNoMusculo_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxPorcentagemDeAguaNoMusculo, txtBoxTextoPorcent);
        }

        private void BtnProximaEtapa_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (!txtBoxPorcentagemGorduraCorporal.Text.Equals(txtBoxTextoPorcent))
            {
                avaliacaoFisica.PorcentagemGorduraCorporal = float.Parse(txtBoxPorcentagemGorduraCorporal.Text.Replace(".",","));
            }
            if (!txtBoxPorcentagemDeAguaNoMusculo.Text.Equals(txtBoxTextoPorcent))
            {
                avaliacaoFisica.PorcentagemAguaMusculo = float.Parse(txtBoxPorcentagemDeAguaNoMusculo.Text.Replace(".", ","));
            }
            if (!txtBoxPorcentagemDeAguaNoCorpo.Text.Equals(txtBoxTextoPorcent))
            {
                avaliacaoFisica.PorcentagemAguaCorpo = float.Parse(txtBoxPorcentagemDeAguaNoCorpo.Text.Replace(".", ","));
            }
            if (!txtBoxTaxaMetabolicaBasal.Text.Equals(txtBoxTextoTaxa))
            {
                avaliacaoFisica.TaxaMetabolicaBasal = float.Parse(txtBoxTaxaMetabolicaBasal.Text.Replace(".", ","));
            }

            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa3", avaliacaoFisica, acao);
        }
    }
}
