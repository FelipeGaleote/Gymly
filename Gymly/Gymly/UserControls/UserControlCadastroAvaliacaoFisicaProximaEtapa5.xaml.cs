﻿using Gymly.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gymly.UserControls
{
    /// <summary>
    /// Interação lógica para UserControlCadastroAvaliacaoFisicaProximaEtapa5.xam
    /// </summary>
    public partial class UserControlCadastroAvaliacaoFisicaProximaEtapa5 : UserControl
    {
        private MainWindow mainWindow;
        private AvaliacaoFisica avaliacaoFisica;
        private string txtBoxTextoObservacao = "Observação";
        private string caminhoFotoDeCostas;
        private string acao;

        public UserControlCadastroAvaliacaoFisicaProximaEtapa5(MainWindow mainWindow, AvaliacaoFisica avaliacaoFisica, string acao)
        {
            this.mainWindow = mainWindow;
            this.avaliacaoFisica = avaliacaoFisica;
            this.acao = acao;
            InitializeComponent();
            EditorTxtBox.AdicionaTextoInicialTxtBox(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnProximaEtapa_Click(object sender, RoutedEventArgs e)
        {
            if (caminhoFotoDeCostas != null && !caminhoFotoDeCostas.Equals(""))
            {
                avaliacaoFisica.CaminhoImagemCostas = caminhoFotoDeCostas;
            }
            else
            {
                avaliacaoFisica.CaminhoImagemCostas = String.Empty;

            }
            if (txtBoxObservacao.Text != String.Empty)
            {
                avaliacaoFisica.ObservacaoImagemCostas = txtBoxObservacao.Text;
            }

            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica,acao);
        }
        private void TxtBoxObservacao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!acao.Equals("Editar"))
                EditorTxtBox.GotFocus(txtBoxObservacao);
        }

        private void TxtBoxObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            EditorTxtBox.LostFocus(txtBoxObservacao, txtBoxTextoObservacao);
        }

        private void BtnPulaFotos_Click(object sender, RoutedEventArgs e)
        {
            avaliacaoFisica.CaminhoImagemCostas = String.Empty;
            avaliacaoFisica.ObservacaoImagemCostas = String.Empty;
            mainWindow.MudarUserControl("cadastroAvaliacaoFisicaProximaEtapa6", avaliacaoFisica,acao);
        }
        private void BtnAddFotoDeCostas_Click(object sender, RoutedEventArgs e)
        {
            caminhoFotoDeCostas = GerenciadorDeArquivos.ProcuraImagem();

            if (caminhoFotoDeCostas != null && !caminhoFotoDeCostas.Equals(""))
            {
                ImageFotoDeCostas.Source = GerenciadorDeArquivos.AdicionaImagem(caminhoFotoDeCostas);
                btnAddFotoDeCostas.Background = Brushes.Transparent;
                btnAddFotoDeCostas.BorderBrush = null;
            }
        }
    }
}
