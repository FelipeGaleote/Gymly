using Gymly.BD;
using Gymly.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlConfiguracao.xam
    /// </summary>
    public partial class UserControlConfiguracao : UserControl
    {
        private MainWindow mainWindow;
        private string caminhoLogoSalvar = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString())+ "\\Fotos\\Academia\\Logo\\logo"+ GerenciadorDeArquivos.GetExtensao("Fotos\\Academia\\Logo\\logo");
        private string avaliadorSelecionado;

        public UserControlConfiguracao(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            PreencheListViewAvaliadores();
           // preencheDataGridAvaliadores();
            hintAvaliador.Visibility = Visibility.Visible;

        }

        private void AdicionarLogo_Click(object sender, RoutedEventArgs e)
        {
            string caminhoLogo;
            caminhoLogo = GerenciadorDeArquivos.ProcuraImagem();
            if (caminhoLogo != String.Empty)
            {
                GerenciadorDeArquivos.AlocaPasta("Academia\\", "Logo");
                caminhoLogoSalvar = "Fotos\\Academia\\Logo\\logo" + GerenciadorDeArquivos.GetExtensao(caminhoLogo);
                GerenciadorDeArquivos.MoveCopiaDeArquivo(caminhoLogo, caminhoLogoSalvar);
                txtBoxcaminhoFoto.Text = caminhoLogoSalvar;
                Xceed.Wpf.Toolkit.MessageBox.Show("Logo adicionado com sucesso", "Logo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void EmitirRelatorioAluno_Click(object sender, RoutedEventArgs e)
        {
            string local = GerenciadorDeArquivos.BuscaLocalParaSalvarArquivo();

            if (!local.Equals(""))
            {
                Relatorio.GeraRelatorioAlunos(local);
            }
        }
        /*
        private void preencheDataGridAvaliadores() {         
            dataGridAvaliador.ItemsSource = BDAvaliador.SelecionaAvaliadores().DefaultView;
        }
        */

        private void PreencheListViewAvaliadores()
        {
            
            listViewAvaliadoresCadastrados.ItemsSource = (BDAvaliador.SelecionaAvaliadores());
        }
        private void adicionarAvaliador_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBoxAvaliador.Text.Equals(""))
            {
                try
                {
                    BDAvaliador.InsereAvaliador(txtBoxAvaliador.Text);
                    //preencheDataGridAvaliadores();
                    PreencheListViewAvaliadores();
                    txtBoxAvaliador.Text = "";
                    hintAvaliador.Visibility = Visibility.Visible;
                }
                catch
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Falha ao adicionar avaliador");
                }
            }
        }

        private void excluirAvaliador_Click(object sender, RoutedEventArgs e)
        {
            if(avaliadorSelecionado != null && !avaliadorSelecionado.Equals(""))
            BDAvaliador.DeletaAvaliador(avaliadorSelecionado);
            PreencheListViewAvaliadores();
            //preencheDataGridAvaliadores();
        }
        /*
        private void dataGridAvaliador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dataGridAvaliador.SelectedItem;
                if(dataRow != null)
                avaliadorSelecionado = dataRow.Row.ItemArray[0].ToString();
            }
            catch
            {

            }
            
        }
        */
        private void txtBoxAvaliador_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtBoxAvaliador.Text.Length > 0)
            {
                hintAvaliador.Visibility = Visibility.Hidden;
            }
            else
            {
                hintAvaliador.Visibility = Visibility.Visible;
            }
        }

        private void listViewAvaliadoresCadastrados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (listViewAvaliadoresCadastrados.SelectedItems[0].ToString() != null)
                    avaliadorSelecionado = listViewAvaliadoresCadastrados.SelectedItems[0].ToString();
            }
            catch
            {

            }
        }
    }
}
