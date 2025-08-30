using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;
using iText.Forms.Fields;
using iText.Forms;
using iText.Layout.Properties;
using iText.Forms.Form.Element;
using Aspose.Words.Fields;

class Example
{
    static void Main()
    {
        string dest = @"E:\Programowanie\neytrodev\Interactive PDF\newPdf.pdf";
        
        using (PdfWriter writer = new PdfWriter(dest))
        using (PdfDocument pdf = new PdfDocument(writer))
        using (Document document = new Document(pdf, PageSize.A4))
        {
            Paragraph paragraph = new Paragraph("Vorkontrollbogen Adoption");
            paragraph.SetFontSize(18);

            Paragraph name = new Paragraph("Name und PLZ des Hundes:");
            name.SetFontSize(10);
            PdfTextFormField nameField = new TextFormFieldBuilder(pdf, "nameFiled")
               .SetWidgetRectangle(new Rectangle(180, 751,200, 18)).CreateText();

            Paragraph date = new Paragraph("Datum der Vorkontrolle:");
            name.SetFontSize(10);
            PdfTextFormField dateField = new TextFormFieldBuilder(pdf, "dateFiled")
               .SetWidgetRectangle(new Rectangle(180, 728, 200, 18)).CreateText();

            Paragraph personalData = new Paragraph("Persönliche Daten der Interessent*innen");
            personalData.SetFontSize(15);

            Paragraph mainName = new Paragraph("Vor- und Nachname:");
            mainName.SetFontSize(10);
            PdfTextFormField mainNameField = new TextFormFieldBuilder(pdf, "mainNameField")
               .SetWidgetRectangle(new Rectangle(180, 673, 200, 18)).CreateText();

            Paragraph street = new Paragraph("Straße und Hausnummer:");
            street.SetFontSize(10);
            PdfTextFormField streetField = new TextFormFieldBuilder(pdf, "streetField")
               .SetWidgetRectangle(new Rectangle(180, 650, 200, 18)).CreateText();

            Paragraph home = new Paragraph("PLZ und Wohnort:");
            home.SetFontSize(10);
            PdfTextFormField homeField = new TextFormFieldBuilder(pdf, "homeField")
               .SetWidgetRectangle(new Rectangle(180, 627, 200, 18)).CreateText();

            Paragraph userId = new Paragraph("PLZ und Wohnort:");
            userId.SetFontSize(10);
            PdfTextFormField userIdField = new TextFormFieldBuilder(pdf, "userIdField")
               .SetWidgetRectangle(new Rectangle(180, 627, 200, 18)).CreateText();

            PdfAcroForm form = PdfFormCreator.GetAcroForm(pdf, true);
            form.AddField(nameField);
            form.AddField(dateField);
            form.AddField(mainNameField);
            form.AddField(streetField);
            form.AddField(homeField);
            form.AddField(userIdField);

            document.Add(paragraph);
            document.Add(name);
            document.Add(date);
            document.Add(personalData);
            document.Add(mainName);
            document.Add(street);
            document.Add(home);
            document.Add(userId);
            document.Close();

        }
    }
}