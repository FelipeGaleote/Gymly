using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Gymly.BD;


namespace Gymly.Models
{


    class Relatorio
    {
        private static string textoTitulo = FontFactory.HELVETICA_BOLD;
        private static string textoComum = FontFactory.HELVETICA;
        private static string caminhoFotoLogoEmpresa = "Fotos\\Academia\\Logo\\logo" + GerenciadorDeArquivos.GetExtensao("Fotos\\Academia\\Logo\\logo");

        //private string caminhoRelatorioAvaliacaoFisica = "av.pdf";
        
        public static void GeraRelatorioAlunos(string local)
        {

            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(local, FileMode.Create));
            doc.Open();

            Paragraph p1 = new Paragraph("Relatório de Alunos", SelecionaFonte(textoTitulo, 18))
            {
                Alignment = 1
            };
            Paragraph pulaLinha = new Paragraph(" ");


            PdfPTable table = new PdfPTable(6) { WidthPercentage = 106, RunDirection = PdfWriter.RUN_DIRECTION_LTR, ExtendLastRow = false };
            table.AddCell(CriaCell("Nome", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("CPF", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Idade", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Sexo", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("E-mail", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Telefone", SelecionaFonte(textoComum, 14), "Center", "Center", iTextSharp.text.BaseColor.GRAY));

            doc.Add(p1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(table);


            foreach (string cpf in BDAluno.SelecionaCpfsDosAlunos())
            {
                Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);

                PdfPTable dados = new PdfPTable(6) {WidthPercentage=106 ,RunDirection = PdfWriter.RUN_DIRECTION_LTR, ExtendLastRow = false };
                dados.AddCell(CriaCell(aluno.Nome, SelecionaFonte(textoComum, 12), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Cpf, SelecionaFonte(textoComum, 12), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.CalculaIdade().ToString(), SelecionaFonte(textoComum, 12), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Sexo, SelecionaFonte(textoComum, 12), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Email, SelecionaFonte(textoComum, 12), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Telefone, SelecionaFonte(textoComum, 12), "Center", "Center"));
                doc.Add(dados);
            }
            
            doc.Close();

        }

        public static PdfPCell CriaCell(string texto, Font fonte, string alinhamentoX, string alinhamentoY, BaseColor cor)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte));
            switch (alinhamentoX)
            {
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
                case "Left":
                    cell.HorizontalAlignment = 0;
                    break;
                case "Right":
                    cell.HorizontalAlignment = 2;
                    break;
            }
            switch (alinhamentoX)
            {
                case "Top":
                    cell.VerticalAlignment = 0;
                    break;
                case "Bottom":
                    cell.HorizontalAlignment = 2;
                    break;
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
            }
            cell.BackgroundColor = cor;
            return cell;
        }
        public static PdfPCell CriaCell(string texto, Font fonte, string alinhamentoX, string alinhamentoY)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte));
            cell.NoWrap = false;
            cell.Column.AdjustFirstLine = true;
            switch (alinhamentoX)
            {
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
                case "Left":
                    cell.HorizontalAlignment = 0;
                    break;
                case "Right":
                    cell.HorizontalAlignment = 2;
                    break;
            }
            switch (alinhamentoX)
            {
                case "Top":
                    cell.VerticalAlignment = 0;
                    break;
                case "Bottom":
                    cell.HorizontalAlignment = 2;
                    break;
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
            }
            return cell;
        }
        public static PdfPCell CriaCell(string texto1, string texto2, Font fonteTexto1, Font fonteTexto2, string alinhamentoX, string alinhamentoY, BaseColor corFundo, BaseColor corBorda)
        {
            Paragraph p = new Paragraph(texto1, fonteTexto1)
            {
                new Chunk(texto2, fonteTexto2)
            };
            PdfPCell cell = new PdfPCell(p);
            switch (alinhamentoX)
            {
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
                case "Left":
                    cell.HorizontalAlignment = 0;
                    break;
                case "Right":
                    cell.HorizontalAlignment = 2;
                    break;
            }
            switch (alinhamentoX)
            {
                case "Top":
                    cell.VerticalAlignment = 0;
                    break;
                case "Bottom":
                    cell.HorizontalAlignment = 2;
                    break;
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
            }
            cell.BackgroundColor = corFundo;
            cell.BorderColor = corBorda;
            cell.MinimumHeight = 40;
            return cell;
        }
        public static iTextSharp.text.Image AdicionaImagem(string caminhoImagem, float escalaX, float escalaY, int alinhamento)
        {

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\" + caminhoImagem);
            img.Alignment = (alinhamento | iTextSharp.text.Image.TEXTWRAP);
            img.Border = (iTextSharp.text.Image.BOX);
            img.BorderWidth = (10);
            img.BorderColor = (BaseColor.WHITE);
            img.ScaleToFit(escalaX, escalaY);

            return img;
        }
        public static Document AdicionaLinha(Document doc, string texto, Font fonte, int alinhamento)
        {
            Paragraph paragraph = new Paragraph(texto, fonte)
            {
                Alignment = alinhamento
            };
            doc.Add(paragraph);

            return doc;
        }
        public static Document AdicionaLinha(Document doc, string texto1, string texto2, Font fonteTexto1, Font fonteTexto2, int alinhamento)
        {
            Paragraph paragraph = new Paragraph(texto1, fonteTexto1)
            {
                new Chunk(texto2, fonteTexto2)
            };
            paragraph.Alignment = alinhamento;
            doc.Add(paragraph);

            return doc;
        }
        public static Font SelecionaFonte(string tipoFonte, float tamanho)
        {
            return FontFactory.GetFont(tipoFonte, tamanho);
        }

        public static void GerarRelatorioDeAvaliacao(string cpf, string localParaSalvar, AvaliacaoFisica avaliacaoFisica)
        {
            Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);
            

            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(localParaSalvar, FileMode.Create));
            doc.Open();
            doc = CriaCapaPdf(doc, aluno);
            
            doc = GeraAvaliacaoFisica(doc, avaliacaoFisica, aluno);
            
            doc.Close();
        }
        public static void GerarRelatorioDeAvaliacao(string cpf, string localParaSalvar, Anamnese anamnese)
        {
            Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);


            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(localParaSalvar, FileMode.Create));
            doc.Open();
            doc = CriaCapaPdf(doc, aluno);
            
            doc = GeraAnamnese(doc, anamnese);

            doc.Close();
        }
        public static void GerarRelatorioDeAvaliacao(string cpf, string localParaSalvar, Anamnese anamnese, AvaliacaoFisica avaliacaoFisica)
        {
            Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);


            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(localParaSalvar, FileMode.Create));
            doc.Open();
            doc = CriaCapaPdf(doc, aluno);
            doc = GeraAnamnese(doc, anamnese);
            doc = GeraAvaliacaoFisica(doc, avaliacaoFisica, aluno);
            
            doc.Close();
        }

        public static Document GeraAvaliacaoFisica(Document doc, AvaliacaoFisica avaliacaoFisica, Aluno aluno)
        {
           
            float diferenca = 0f;
            double vo2;

            Paragraph pulaLinha = new Paragraph(" ");

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Informações básicas:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);

            PdfPTable table = new PdfPTable(4);

            table.AddCell(CriaCell("Altura(m)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Peso(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("IMC (Kg/m²)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Classificação", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            float imc =  avaliacaoFisica.CalculoImc(avaliacaoFisica.Massa, avaliacaoFisica.Altura);

            table.AddCell(CriaCell((avaliacaoFisica.Altura/100).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //altura
            table.AddCell(CriaCell(avaliacaoFisica.Massa.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //peso
            table.AddCell(CriaCell(imc.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (imc >= 18.5 && imc <= 24.9) ? BaseColor.WHITE : BaseColor.RED)); 
            table.AddCell(CriaCell(avaliacaoFisica.ClassificacaoIMC(imc), SelecionaFonte(textoComum, 12), "Center", "Center", (avaliacaoFisica.ClassificacaoIMC(imc).Equals("Eutrofia")) ? BaseColor.WHITE : BaseColor.RED));

            doc.Add(table);

            doc.Add(pulaLinha);


            table = new PdfPTable(3);

            table.AddCell(CriaCell("Percentual de Gordura(%)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Massa Magra(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Massa Gorda(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            table.AddCell(CriaCell(avaliacaoFisica.CalculaPercentualDeGordura(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.CalculaMassaMagra(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.CalculaMassaGorda(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));

            doc.Add(table);

            table = new PdfPTable(2);

            table.AddCell(CriaCell("Pressão Arterial:", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Frequência Cardiaca:", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            table.AddCell(CriaCell(avaliacaoFisica.PressaoArterialSistolica + "x" + avaliacaoFisica.PressaoArterialDiastolica, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//pressao
            table.AddCell(CriaCell(avaliacaoFisica.FrequenciaCardiaca.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //Frequencia Cardiaca


            table = new PdfPTable(1);


            table.AddCell(CriaCell("Treinos/semana:", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.QtdadeDiasDeTreino, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));//qtdade Dias de treino

            doc.Add(table);

            table = new PdfPTable(1);

            table.AddCell(CriaCell("Flexibilidade:", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.Flexibilidade, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));//Flexibilidade

           
            doc.Add(table);

            doc = AdicionaLinha(doc, "Circunferências:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(4);

            table.AddCell(CriaCell("Membro:", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Esquerda(cm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Direita(cm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Diferença(cm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            //braço
            table.AddCell(CriaCell("Braço", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroBracoEsquerdo.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroBracoDireito.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroBracoEsquerdo - avaliacaoFisica.PerimetroBracoDireito);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            //Antebraço
            table.AddCell(CriaCell("Antebraço", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroAntebracoEsquerdo.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroAntebracoDireito.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroAntebracoEsquerdo - avaliacaoFisica.PerimetroAntebracoDireito);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            //Coxa Proximal
            table.AddCell(CriaCell("Coxa Proximal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaProximalEsquerda.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaProximalDireita.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroCoxaProximalEsquerda - avaliacaoFisica.PerimetroCoxaProximalDireita);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            //Coxa Medial
            table.AddCell(CriaCell("Coxa Medial", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaMedialEsquerda.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaMedialDireita.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroCoxaMedialEsquerda - avaliacaoFisica.PerimetroCoxaMedialDireita);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            //Coxa Distal
            table.AddCell(CriaCell("Coxa Distal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaDistalEsquerda.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCoxaDistalDireita.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroCoxaDistalEsquerda - avaliacaoFisica.PerimetroCoxaDistalDireita);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            //Panturrilha
            table.AddCell(CriaCell("Panturrilha", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroPernaEsquerda.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Esquerda
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroPernaDireita.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//direita
            diferenca = Math.Abs(avaliacaoFisica.PerimetroPernaEsquerda - avaliacaoFisica.PerimetroPernaDireita);
            table.AddCell(CriaCell(Math.Abs(diferenca).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (diferenca <= 0.5) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));//diferença

            doc.Add(table);

            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(4);
            table.AddCell(CriaCell("Membro", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Tamanho(cm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Membro", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Tamanho(cm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            //Ombro
            table.AddCell(CriaCell("Ombro", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroOmbro.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Ombro

            //Tórax
            table.AddCell(CriaCell("Tórax", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroTorax.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Tórax

            //Cintura
            table.AddCell(CriaCell("Cintura", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroCintura.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Cintura

            //Abdominal
            table.AddCell(CriaCell("Abdominal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroAbdominal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Abdominal

            //Quadril
            table.AddCell(CriaCell("Quadril", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.PerimetroQuadril.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Quadril

            //Envergadura
            table.AddCell(CriaCell("Envergadura", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.Envergadura.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Envergadura

            doc.Add(table);

            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Dobras Cutaneas:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(4);

            table.AddCell(CriaCell("Dobra", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Tamanho(mm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Dobra", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Tamanho(mm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));


            //Subescapular
            table.AddCell(CriaCell("Subescapular", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaSubescapular.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Subescapular

            //Tríceps
            table.AddCell(CriaCell("Tríceps", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaTriceps.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Tríceps

            //Bíceps
            table.AddCell(CriaCell("Bíceps", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaBiceps.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Bíceps

            //Tórax
            table.AddCell(CriaCell("Tórax", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaTorax.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Tórax

            //Axilar Média
            table.AddCell(CriaCell("Axilar Média", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaAxilarMedia.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Axilar Média

            //Supra-íliaca
            table.AddCell(CriaCell("Supra-íliaca", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaSuprailiaca.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Supra-íliaca

            //Abdominal
            table.AddCell(CriaCell("Abdominal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaAbdominal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Abdominal

            //Coxa
            table.AddCell(CriaCell("Coxa", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaCoxa.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Coxa

            //Panturrilha
            table.AddCell(CriaCell("Panturrilha", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DobraCutaneaPerna.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//Panturrilha

            table.AddCell(CriaCell("", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            doc.Add(table);

            doc.NewPage();
            
            if (!avaliacaoFisica.CaminhoImagemFrontal.Equals("")) {
                doc.Add(pulaLinha);
                doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                doc = AdicionaLinha(doc, "Imagem Frente:", SelecionaFonte(textoTitulo, 14), 0);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                table = new PdfPTable(2);
                table.AddCell(AdicionaImagem(avaliacaoFisica.CaminhoImagemFrontal, 400, 150, Element.ALIGN_CENTER));
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemFrontal, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao frente
                doc.Add(table);
                doc.NewPage();

            }

            if (!avaliacaoFisica.CaminhoImagemLateral.Equals("")) { 
                doc.Add(pulaLinha);
                doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                doc = AdicionaLinha(doc, "Imagem Lado:", SelecionaFonte(textoTitulo, 14), 0);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                table = new PdfPTable(2);
                table.AddCell(AdicionaImagem(avaliacaoFisica.CaminhoImagemLateral, 400, 150, Element.ALIGN_CENTER));
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemLateral, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao lado
                doc.Add(table);

                doc.NewPage();
            }
            if (!avaliacaoFisica.CaminhoImagemCostas.Equals("")) {
                doc.Add(pulaLinha);
                doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                doc = AdicionaLinha(doc, "Imagem Costas:", SelecionaFonte(textoTitulo, 14), 0);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

                table = new PdfPTable(2);
                table.AddCell(AdicionaImagem(avaliacaoFisica.CaminhoImagemCostas, 400, 150, Element.ALIGN_CENTER));
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemCostas, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao costas
                doc.Add(table);

                doc.NewPage();
            }
            
            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Testes de resistência:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);


            table = new PdfPTable(4);
            table.AddCell(CriaCell("Exercício", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Tempo(s)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Repetições", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Avaliação", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            string avaliacao = "Ruim";

            table.AddCell(CriaCell("Flexão", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.TempoFlexao.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.QtdadeFlexao.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacao, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, (avaliacao.Equals("Ruim")) ? BaseColor.RED : BaseColor.WHITE ));   ///Avaliacaooooooo flexaooooooooooooooo-----------

            table.AddCell(CriaCell("Abdominal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.TempoAbdominal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.QtdadeAbdominais.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacao, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, (avaliacao.Equals("Ruim")) ? BaseColor.RED : BaseColor.WHITE)); ///Avaliacaooooooo Abdominallllllll-----------

            doc.Add(table);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Teste de Cooper:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);


            table = new PdfPTable(4);
            table.AddCell(CriaCell("Tempo(min)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Distância(m)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("VO2Max(ml/kg/min)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Avaliação", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            vo2 = avaliacaoFisica.CalculaVo2Max(avaliacaoFisica.DistanciaCooper);

            table.AddCell(CriaCell(12.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DistanciaCooper.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(vo2.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.VerificaNivelCapacidadeAerobica(vo2, aluno.Sexo, aluno.CalculaIdade()), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, (avaliacao.Equals("Muito Fraco")) ? BaseColor.RED : BaseColor.WHITE));  //avaliacaoooo coopppeeerrr

            doc.Add(table);

            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Observações:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(1);
            table.AddCell(CriaCell(avaliacaoFisica.Observacao, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));//observações finais

            doc.Add(table);

            return doc;
        }

        public static Document GeraAnamnese(Document doc, Anamnese anamnese)
        {
            return doc;
        }

        public static Document CriaCapaPdf(Document doc, Aluno aluno)
        {
            
            Paragraph pulaLinha = new Paragraph(" ");

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\" + caminhoFotoLogoEmpresa))
            {
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
            }
            else
            {
                doc.Add(AdicionaImagem(caminhoFotoLogoEmpresa, 300, 300, 1));
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
            }
            doc.Add(AdicionaImagem(aluno.CaminhoFotoDoRosto, 800, 300, 1));
            
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            
            PdfPTable table = new PdfPTable(2);

            table.AddCell(CriaCell("Nome: ", aluno.Nome, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Idade: ", aluno.CalculaIdade().ToString(), SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Sexo: ", aluno.Sexo, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Nivel: ", aluno.Nivel, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("E-mail: ", aluno.Email, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Telefone: ", aluno.Telefone, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));

            doc.Add(table);
            doc = AdicionaLinha(doc, DateTime.Now.ToShortDateString(), SelecionaFonte(textoTitulo, 14), 2);

            return doc;

        }
        public static PdfPCell CriaCell(string texto, Font fonte, string alinhamentoX, string alinhamentoY, BaseColor corFundo, BaseColor corBorda)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte));
            switch (alinhamentoX)
            {
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
                case "Left":
                    cell.HorizontalAlignment = 0;
                    break;
                case "Right":
                    cell.HorizontalAlignment = 2;
                    break;
            }
            switch (alinhamentoX)
            {
                case "Top":
                    cell.VerticalAlignment = 0;
                    break;
                case "Bottom":
                    cell.HorizontalAlignment = 2;
                    break;
                case "Center":
                    cell.HorizontalAlignment = 1;
                    break;
            }
            cell.BackgroundColor = corFundo;
            cell.BorderColor = corBorda;
            return cell;
        }

    }
}
