using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using HtmlAgilityPack;

public static class StoredProcedure
{
    [SqlProcedure()]
    public static void clr_HtmlToPdfUTF8(SqlString sourcePath, SqlString targetPath)
    {

        string str = sourcePath.ToString();
        string str1 = targetPath.ToString();

                       
            if (File.Exists(str1))
            {
                File.Delete(str1);
            }

            HtmlDocument doc = new HtmlDocument();
            doc.Load(str, Encoding.UTF8);
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(str1, FileMode.CreateNew));

            document.Open();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                string tekst = (node.InnerText);
                if (tekst.Contains("span.spanStyle"))
                {
                    var headerParagraph = new Paragraph("", new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.CP1250, true)));
                    document.Add(headerParagraph);
                }
                if (tekst.Contains("XXX") || tekst.Contains("YYY") || tekst.Contains("ZZZ") || tekst.Contains("WWW"))
                {
                    var headerParagraph = new Paragraph(tekst, new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.CP1250, true)));
                    headerParagraph.Alignment = Element.ALIGN_CENTER;
                    document.Add(headerParagraph);
                }
                if (tekst.Contains("*") || tekst.Contains("KKK"))
                {
                    var headerParagraph = new Paragraph(tekst, new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.CP1250, true)));
                    headerParagraph.Alignment = Element.ALIGN_RIGHT;
                    document.Add(headerParagraph);
                }
             

            }
             document.Close();
          
    }
    
}
