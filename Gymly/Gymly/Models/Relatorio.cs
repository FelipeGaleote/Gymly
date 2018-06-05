﻿using System;
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
        private static string caminhoPdf = "Relatorios\\RelatorioAlunos.pdf";
        private static Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
        private static Font fonteTextoComum = FontFactory.GetFont(FontFactory.HELVETICA, 14);

        public static void GeraRelatorioAlunos()
        {

            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 10, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(caminhoPdf, FileMode.Create));
            doc.Open();

            Paragraph p1 = new Paragraph("Relatório de Alunos", fonteTitulo)
            {
                Alignment = 1
            };
            Paragraph pulaLinha = new Paragraph(" ");


            PdfPTable table = new PdfPTable(6);
            table.AddCell(CriaCell("Nome", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("CPF", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Idade", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Sexo", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("E-mail", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));
            table.AddCell(CriaCell("Telefone", fonteTextoComum, "Center", "Center", iTextSharp.text.BaseColor.GRAY));

            doc.Add(p1);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(table);


            foreach (string cpf in BDAluno.SelecionaCpfsDosAlunos())
            {
                Aluno aluno = BDAluno.SelecionaAlunoPorCpf(cpf);

                PdfPTable dados = new PdfPTable(6);
                dados.AddCell(CriaCell(aluno.Nome, fonteTextoComum, "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Cpf, fonteTextoComum, "Center", "Center"));
                dados.AddCell(CriaCell(Aluno.CalculaIdade(aluno).ToString(), fonteTextoComum, "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Sexo, fonteTextoComum, "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Email, fonteTextoComum, "Center", "Center"));
                dados.AddCell(CriaCell(aluno.Telefone, fonteTextoComum, "Center", "Center"));
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
    }
}