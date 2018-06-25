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
        private static readonly string textoTitulo = FontFactory.HELVETICA_BOLD;
        private static readonly string textoComum = FontFactory.HELVETICA;
        private static readonly string caminhoFotoLogoEmpresa = "Fotos\\Academia\\Logo\\logo";
        private static string arquivo;
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

                PdfPTable dados = new PdfPTable(6) { WidthPercentage = 106, RunDirection = PdfWriter.RUN_DIRECTION_LTR, ExtendLastRow = false };
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
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte))
            {
                NoWrap = false
            };
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
            iTextSharp.text.Image img=null;
            try
            {
                img = iTextSharp.text.Image.GetInstance(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\" + caminhoImagem);
                img.Alignment = (alinhamento | iTextSharp.text.Image.TEXTWRAP);
                img.Border = (iTextSharp.text.Image.BOX);
                img.BorderWidth = (10);
                img.BorderColor = (BaseColor.WHITE);
                img.ScaleToFit(escalaX, escalaY);
            }
            catch
            {

            }
            
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


        public static void GerarRelatorioDeAvaliacao(string localParaSalvar, AvaliacaoFisica avaliacaoFisica)
        {
            Aluno aluno = BDAluno.SelecionaAlunoPorCpf(avaliacaoFisica.CpfAluno);
            Anamnese anamnese = BDAnamnese.SelecionaAnamnesePeloCpf(avaliacaoFisica.CpfAluno);

            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(localParaSalvar, FileMode.Create));
            doc.Open();
            doc = CriaCapaPdf(doc, aluno, avaliacaoFisica.TipoDeAvaliacao, avaliacaoFisica.Avaliador);
            if (anamnese.CpfAluno != null)
            {
                doc = GeraAnamnese(doc, anamnese);
            }
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

            float imc = (float)(Math.Round(avaliacaoFisica.CalculoImc(avaliacaoFisica.Massa, (avaliacaoFisica.Altura / 100)), 2));

            table.AddCell(CriaCell((avaliacaoFisica.Altura / 100).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //altura
            table.AddCell(CriaCell(avaliacaoFisica.Massa.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //peso
            table.AddCell(CriaCell(imc.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", (imc >= 18.5 && imc <= 24.9) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.ClassificacaoIMC(imc), SelecionaFonte(textoComum, 12), "Center", "Center", (avaliacaoFisica.ClassificacaoIMC(imc).Equals("Eutrofia")) ? BaseColor.WHITE : BaseColor.RED, BaseColor.WHITE));

            doc.Add(table);

            doc.Add(pulaLinha);


            table = new PdfPTable(3);

            table.AddCell(CriaCell("Percentual de Gordura(%)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Massa Magra(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Massa Gorda(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));



            table.AddCell(CriaCell((avaliacaoFisica.TipoDeAvaliacao.Equals("Antropometria")) ? Math.Round(avaliacaoFisica.CalculaPercentualDeGordura(aluno), 2).ToString() : avaliacaoFisica.PorcentagemGorduraCorporal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.CalculaMassaMagra(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.CalculaMassaGorda(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));

            doc.Add(table);

            doc.Add(pulaLinha);

            table = new PdfPTable(2);

            table.AddCell(CriaCell("Pressão Arterial(mmHg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Frequência Cardiaca(bpm)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            table.AddCell(CriaCell(avaliacaoFisica.PressaoArterialSistolica + "x" + avaliacaoFisica.PressaoArterialDiastolica, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));//pressao
            table.AddCell(CriaCell(avaliacaoFisica.FrequenciaCardiaca.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //Frequencia Cardiaca


            doc.Add(table);
            doc.Add(pulaLinha);

            table = new PdfPTable(3);


            PdfPTable tableTemp = new PdfPTable(1);

            tableTemp.AddCell(CriaCell("Treinos/semana", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE)).BorderColor = BaseColor.WHITE;
            tableTemp.AddCell(CriaCell(avaliacaoFisica.QtdadeDiasDeTreino, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)).BorderColor = BaseColor.WHITE;//qtdade Dias de treino

            table.AddCell(new PdfPCell(tableTemp) { BorderColor = BaseColor.WHITE });
            table.AddCell(new PdfPCell() { BorderColor = BaseColor.WHITE, NoWrap = true });

            tableTemp = new PdfPTable(1);

            tableTemp.AddCell(CriaCell("Flexibilidade", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE)).BorderColor = BaseColor.WHITE;
            tableTemp.AddCell(CriaCell(avaliacaoFisica.Flexibilidade, SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)).BorderColor = BaseColor.WHITE;//Flexibilidade
            table.AddCell(new PdfPCell(tableTemp) { BorderColor = BaseColor.WHITE });

            doc.Add(table);

            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Circunferências:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);

            table = new PdfPTable(4);

            table.AddCell(CriaCell("Membro", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
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
            if (avaliacaoFisica.TipoDeAvaliacao.Equals("Antropometria"))
            {
                doc = AdicionaLinha(doc, "Dobras Cutâneas:", SelecionaFonte(textoTitulo, 14), 0);
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


            }

            doc.NewPage();

            if (!avaliacaoFisica.CaminhoImagemFrontal.Equals(""))
            {
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

                try
                {
                    arquivo = Directory.GetFiles(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Fotos\\Avaliacoes\\"+avaliacaoFisica.Id+"\\Frente")[0];
                }
                catch
                {
                    arquivo = null;
                }

                table.AddCell(AdicionaImagem(avaliacaoFisica.CaminhoImagemFrontal, 400, 150, Element.ALIGN_CENTER));
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemFrontal, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao frente
                doc.Add(table);
                doc.NewPage();

            }

            if (!avaliacaoFisica.CaminhoImagemLateral.Equals(""))
            {
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
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemLateral, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao lado
                doc.Add(table);

                doc.NewPage();
            }
            if (!avaliacaoFisica.CaminhoImagemCostas.Equals(""))
            {
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
                table.AddCell(CriaCell(avaliacaoFisica.ObservacaoImagemCostas, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE)); //observacao costas
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


            table.AddCell(CriaCell("Flexão", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.TempoFlexao.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.QtdadeFlexao.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.NivelFlexoes, SelecionaFonte(textoComum, 12), "Center", "Center", (avaliacaoFisica.NivelFlexoes.Equals("Ruim")) ? BaseColor.RED : BaseColor.WHITE, BaseColor.WHITE));   ///Avaliacaooooooo flexaooooooooooooooo-----------

            table.AddCell(CriaCell("Abdominal", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.TempoAbdominal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.QtdadeAbdominais.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.NivelAbdominais, SelecionaFonte(textoComum, 12), "Center", "Center", (avaliacaoFisica.NivelAbdominais.Equals("Ruim")) ? BaseColor.RED : BaseColor.WHITE, BaseColor.WHITE)); ///Avaliacaooooooo Abdominallllllll-----------

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

            vo2 = Math.Round(avaliacaoFisica.CalculaVo2Max(avaliacaoFisica.DistanciaCooper), 2);
            string nivelCooper = avaliacaoFisica.VerificaNivelCapacidadeAerobica(avaliacaoFisica.DistanciaCooper, aluno.Sexo, aluno.CalculaIdade());

            table.AddCell(CriaCell(12.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(avaliacaoFisica.DistanciaCooper.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(vo2.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell(nivelCooper, SelecionaFonte(textoComum, 12), "Center", "Center", (nivelCooper.ToLower().Equals("fraca") || nivelCooper.ToLower().Equals("muito fraca")) ? BaseColor.RED : BaseColor.WHITE, BaseColor.WHITE));  //avaliacaoooo coopppeeerrr

            doc.Add(table);

            doc.Add(pulaLinha);


            if (avaliacaoFisica.Observacao != null && !avaliacaoFisica.Observacao.Equals(""))
            {
                doc = AdicionaLinha(doc, "Observações:", SelecionaFonte(textoTitulo, 14), 0);
                doc.Add(pulaLinha);

                table = new PdfPTable(1);
                table.AddCell(CriaCell(avaliacaoFisica.Observacao, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));//observações finais

                doc.Add(table);
                doc.Add(pulaLinha);
            }

            doc = AdicionaLinha(doc, "Resultados:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);

            if (avaliacaoFisica.TipoDeAvaliacao.Equals("Bioimpedancia"))
            {

                table = new PdfPTable(3);

                table.AddCell(CriaCell("Taxa metabólica basal(cal)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
                table.AddCell(CriaCell("% Água no corpo(%)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
                table.AddCell(CriaCell("% Água no músculo(%)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

                table.AddCell(CriaCell(avaliacaoFisica.TaxaMetabolicaBasal.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
                table.AddCell(CriaCell(avaliacaoFisica.PorcentagemAguaCorpo.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
                table.AddCell(CriaCell(avaliacaoFisica.PorcentagemAguaMusculo.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));

                doc.Add(table);

                doc.Add(pulaLinha);

            }
            else
            {
                table = new PdfPTable(1);

                table.AddCell(CriaCell("Taxa metabólica basal(cal)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
                table.AddCell(CriaCell(avaliacaoFisica.CalculaTaxaMetabolicaBasal(aluno).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //altura

                doc.Add(table);

                doc.Add(pulaLinha);
            }

            table = new PdfPTable(2);

            table.AddCell(CriaCell("Peso recomendado(Kg)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("IMC", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            table.AddCell(CriaCell(Math.Round(avaliacaoFisica.CalculaPesoRecomendado(), 2).ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("24.9", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE));

            doc.Add(table);

            doc.Add(pulaLinha);

            table = new PdfPTable(2);

            table.AddCell(CriaCell("Relação Cintura-Quadril(RCQ)", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));
            table.AddCell(CriaCell("Classificação", SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.GRAY, BaseColor.WHITE));

            float valorRCQ = (float)Math.Round(avaliacaoFisica.CalculaRCQ(), 2);
            string classificacaoRCQ = avaliacaoFisica.ClassificacaoRCQ(valorRCQ, aluno);

            table.AddCell(CriaCell(valorRCQ.ToString(), SelecionaFonte(textoComum, 12), "Center", "Center", BaseColor.WHITE, BaseColor.WHITE)); //altura
            table.AddCell(CriaCell(classificacaoRCQ, SelecionaFonte(textoComum, 12), "Center", "Center", (classificacaoRCQ.Equals("Alto") || classificacaoRCQ.Equals("Muito Alto")) ? BaseColor.RED : BaseColor.WHITE, BaseColor.WHITE));

            doc.Add(table);

            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(2);
            table.AddCell(new PdfPCell(new Phrase("_________________________")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("_________________________")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("(Assinatura do aluno)")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("(Assinatura do avaliador)")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            doc.Add(table);

            return doc;
        }

        public static Document GeraAnamnese(Document doc, Anamnese anamnese)
        {

            Dictionary<string, bool> questionario = anamnese.DictQuestionario();
            Dictionary<string, bool> objetivo = anamnese.DictObjetivos();

            Paragraph pulaLinha = new Paragraph(" ");

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Anamnese", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Questinonário:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);

            PdfPTable table;
            PdfPTable tableInterno;
            PdfPTable tableYorN;

            foreach (var pair in questionario)
            {
                table = new PdfPTable(1);
                tableInterno = new PdfPTable(2);
                tableYorN = new PdfPTable(2);

                tableInterno.AddCell(new PdfPCell(CriaCell(pair.Key, SelecionaFonte(textoComum, 12), "Left", "Center")) { BorderColor = BaseColor.WHITE });
                tableYorN.AddCell(new PdfPCell(CriaCell("Sim", SelecionaFonte(textoComum, 12), "Center", "Center", (pair.Value) ? BaseColor.RED : BaseColor.WHITE)) { BorderColor = BaseColor.WHITE });
                tableYorN.AddCell(new PdfPCell(CriaCell("Não", SelecionaFonte(textoComum, 12), "Center", "Center", (pair.Value) ? BaseColor.WHITE : BaseColor.RED)) { BorderColor = BaseColor.WHITE });
                tableInterno.AddCell(new PdfPCell(tableYorN) { BorderColor = BaseColor.WHITE });
                table.AddCell(new PdfPCell(tableInterno) { BorderColor = BaseColor.WHITE });
                doc.Add(table);
            }

            doc.NewPage();

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Anamnese", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            doc = AdicionaLinha(doc, "Objetivos:", SelecionaFonte(textoTitulo, 14), 0);
            doc.Add(pulaLinha);

            foreach (var pair in objetivo)
            {
                table = new PdfPTable(1);
                tableInterno = new PdfPTable(2);
                tableYorN = new PdfPTable(2);

                tableInterno.AddCell(new PdfPCell(CriaCell(pair.Key, SelecionaFonte(textoComum, 12), "Left", "Center")) { BorderColor = BaseColor.WHITE });
                tableYorN.AddCell(new PdfPCell(CriaCell("Sim", SelecionaFonte(textoComum, 12), "Center", "Center", (pair.Value) ? BaseColor.RED : BaseColor.WHITE)) { BorderColor = BaseColor.WHITE });
                tableYorN.AddCell(new PdfPCell(CriaCell("Não", SelecionaFonte(textoComum, 12), "Center", "Center", (pair.Value) ? BaseColor.WHITE : BaseColor.RED)) { BorderColor = BaseColor.WHITE });
                tableInterno.AddCell(new PdfPCell(tableYorN) { BorderColor = BaseColor.WHITE });
                table.AddCell(new PdfPCell(tableInterno) { BorderColor = BaseColor.WHITE });
                doc.Add(table);
            }

            if (anamnese.Observacao != null && !anamnese.Observacao.Equals(""))
            {
                doc.Add(pulaLinha);

                doc = AdicionaLinha(doc, "Observação:", SelecionaFonte(textoTitulo, 14), 0);
                doc.Add(pulaLinha);

                doc.Add(CriaCell(anamnese.Observacao, SelecionaFonte(textoComum, 12), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));

            }
            else
            {
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);

            }
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);

            table = new PdfPTable(2);
            table.AddCell(new PdfPCell(new Phrase("_________________________")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("_________________________")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("(Assinatura do aluno)")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            table.AddCell(new PdfPCell(new Phrase("(Assinatura do avaliador)")) { BorderColor = BaseColor.WHITE, HorizontalAlignment = 1 });
            doc.Add(table);

            doc.NewPage();

            return doc;
        }

        public static Document CriaCapaPdf(Document doc, Aluno aluno, string tipo, string nomeAvaliador)
        {

            Paragraph pulaLinha = new Paragraph(" ");

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);

            

            try
            {
                arquivo = Directory.GetFiles(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Fotos\\Academia\\Logo")[0];
            }
            catch
            {
                arquivo = null;
            }

            if (arquivo == null && !File.Exists(arquivo))
            {
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
            }
            else
            {
                doc.Add(AdicionaImagem(caminhoFotoLogoEmpresa + GerenciadorDeArquivos.GetExtensao(arquivo), 150, 150, 1));
                doc.Add(pulaLinha);
                
            }
            if (aluno.CaminhoFotoDoRosto!=null && !aluno.CaminhoFotoDoRosto.Equals(""))
            { 
                doc.Add(AdicionaImagem(aluno.CaminhoFotoDoRosto, 300, 300, 1));
            }
            doc.Add(pulaLinha);
           

            PdfPTable table = new PdfPTable(2);

            table.AddCell(CriaCell("Nome: ", aluno.Nome, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Idade: ", aluno.CalculaIdade().ToString(), SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Sexo: ", (aluno.Sexo.Equals("M") ? "Masculino" : "Feminino"), SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Nível: ", aluno.Nivel, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("E-mail: ", aluno.Email, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Telefone: ", aluno.Telefone, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("Nome do avaliador: ", nomeAvaliador, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));
            table.AddCell(CriaCell("", null, SelecionaFonte(textoTitulo, 14), SelecionaFonte(textoComum, 14), "Left", "Center", BaseColor.WHITE, BaseColor.WHITE));


            doc.Add(table);

            doc = AdicionaLinha(doc, (tipo.StartsWith("Ant") ? "Antropométrica" : "Bioimpedância"), SelecionaFonte(textoTitulo, 14), 2);
            doc = AdicionaLinha(doc, DateTime.Now.ToShortDateString(), SelecionaFonte(textoTitulo, 14), 2);


            doc.NewPage();

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
