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
                dados.AddCell(CriaCell(aluno.Nome, SelecionaFonte(textoComum, 14), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Cpf, SelecionaFonte(textoComum, 14), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.CalculaIdade().ToString(), SelecionaFonte(textoComum, 14), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Sexo, SelecionaFonte(textoComum, 14), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Email, SelecionaFonte(textoComum, 14), "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Telefone, SelecionaFonte(textoComum, 14), "Center", "Center"));
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
            Paragraph p = new Paragraph(texto1, fonteTexto1);
            p.Add(new Chunk(texto2, fonteTexto2));
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
        public static Document AdicionaImagem(Document doc, string caminhoImagem, float escalaX, float escalaY)
        {

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(String.Format(caminhoImagem));
            img.Alignment = (Element.ALIGN_CENTER | iTextSharp.text.Image.TEXTWRAP);
            img.Border = (iTextSharp.text.Image.BOX);
            img.BorderWidth = (10);
            img.BorderColor = (BaseColor.WHITE);
            img.ScaleToFit(escalaX, escalaY);

            doc.Add(img);
            return doc;
        }
        public static Document AdicionaLinha(Document doc, string texto, Font fonte, int alinhamento)
        {
            Paragraph paragraph = new Paragraph(texto, fonte);
            paragraph.Alignment = alinhamento;
            doc.Add(paragraph);

            return doc;
        }
        public static Document AdicionaLinha(Document doc, string texto1, string texto2, Font fonteTexto1, Font fonteTexto2, int alinhamento)
        {
            Paragraph paragraph = new Paragraph(texto1, fonteTexto1);
            paragraph.Add(new Chunk(texto2, fonteTexto2));
            paragraph.Alignment = alinhamento;
            doc.Add(paragraph);

            return doc;
        }
        public static Font SelecionaFonte(string tipoFonte, float tamanho)
        {
            return FontFactory.GetFont(tipoFonte, tamanho);
        }

        public static void GerarRelatorioDeAvaliacao(string cpf, bool agrupaAnamnese, bool agrupaAvaliacaoFisica, string localParaSalvar)
        {
            Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);
            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(localParaSalvar, FileMode.Create));
            doc.Open();
            doc = CriaCapaPdf(doc, aluno);
            if (agrupaAnamnese && agrupaAvaliacaoFisica)
            {
                doc = GeraAnamnese(doc, aluno);
                doc = GeraAvaliacaoFisica(doc, aluno);
            }
            else if (agrupaAnamnese)
            {
                doc = GeraAnamnese(doc, aluno);
            }
            else
            {
                doc = GeraAvaliacaoFisica(doc, aluno);
            }
            doc.Close();
        }

        public static Document GeraAvaliacaoFisica(Document doc, Aluno aluno)
        {
            return doc;
        }

        public static Document GeraAnamnese(Document doc, Aluno aluno)
        {
            return doc;
        }

        public static Document CriaCapaPdf(Document doc, Aluno aluno)
        {
            

            Paragraph pulaLinha = new Paragraph(" ");

            doc.Add(pulaLinha);
            doc = AdicionaLinha(doc, "Avaliação Física", SelecionaFonte(textoTitulo, 34), 1);
            doc.Add(pulaLinha);
            if (!File.Exists(caminhoFotoLogoEmpresa))
            {
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
            }
            else
            {
                doc = AdicionaImagem(doc, caminhoFotoLogoEmpresa, 300, 300);
                doc.Add(pulaLinha);
                doc.Add(pulaLinha);
            }
            doc = AdicionaImagem(doc, aluno.CaminhoFotoDoRosto, 800, 300);
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


    }
}
