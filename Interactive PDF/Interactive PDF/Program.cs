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
using iText.Kernel.Colors;

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
            paragraph.SetFontSize(20);

            Paragraph name = new Paragraph("Name und PLZ des Hundes:");
            name.SetFontSize(10);
            PdfTextFormField nameField = new TextFormFieldBuilder(pdf, "nameFiled")
               .SetWidgetRectangle(new Rectangle(180, 748,200, 18)).CreateText();

            Paragraph date = new Paragraph("Datum der Vorkontrolle:");
            name.SetFontSize(10);
            PdfTextFormField dateField = new TextFormFieldBuilder(pdf, "dateFiled")
               .SetWidgetRectangle(new Rectangle(180, 725, 200, 18)).CreateText();

            Paragraph personalData = new Paragraph("Persönliche Daten der Interessent*innen");
            personalData.SetFontSize(15);

            Paragraph mainName = new Paragraph("Vor- und Nachname:");
            mainName.SetFontSize(10);
            PdfTextFormField mainNameField = new TextFormFieldBuilder(pdf, "mainNameField")
               .SetWidgetRectangle(new Rectangle(180, 670, 200, 18)).CreateText();

            Paragraph street = new Paragraph("Straße und Hausnummer:");
            street.SetFontSize(10);
            PdfTextFormField streetField = new TextFormFieldBuilder(pdf, "streetField")
               .SetWidgetRectangle(new Rectangle(180, 647, 200, 18)).CreateText();

            Paragraph home = new Paragraph("PLZ und Wohnort:");
            home.SetFontSize(10);
            PdfTextFormField homeField = new TextFormFieldBuilder(pdf, "homeField")
               .SetWidgetRectangle(new Rectangle(180, 624, 200, 18)).CreateText();

            Paragraph userId = new Paragraph("Personalausweisnummer:");
            userId.SetFontSize(10);
            PdfTextFormField userIdField = new TextFormFieldBuilder(pdf, "userIdField")
               .SetWidgetRectangle(new Rectangle(180, 601, 200, 18)).CreateText();

            Paragraph proofData = new Paragraph("Stimmen die angegebenen Daten aus der Selbstauskunft mit der Wirklichkeit überein?");
            proofData.SetFontSize(10);

            RadioFormFieldBuilder proofbuilder = new RadioFormFieldBuilder(pdf, "proofbuilder");
            PdfButtonFormField proofRadioGroup = proofbuilder.CreateRadioGroup();
            Rectangle rectJa = new Rectangle(40, 788, 15, 15);
            Rectangle rectNein = new Rectangle(60, 788, 15, 15);
            Rectangle rectPart = new Rectangle(80, 788, 15, 15);
            PdfFormAnnotation fieldJa = proofbuilder
                    .CreateRadioButton("rectJa", rectJa)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNein = proofbuilder
                    .CreateRadioButton("rectNein", rectNein)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldPart = proofbuilder
                   .CreateRadioButton("rectPart", rectPart)
                   .SetBorderWidth(1)
                   .SetBorderColor(ColorConstants.BLACK)
                   .SetBackgroundColor(ColorConstants.WHITE);
            
            proofRadioGroup.AddKid(fieldJa);
            proofRadioGroup.AddKid(fieldNein);
            proofRadioGroup.AddKid(fieldPart);

            PdfAcroForm form = PdfFormCreator.GetAcroForm(pdf, true);

            document.Add(paragraph);
            document.Add(name);
            document.Add(date);
            document.Add(personalData);
            document.Add(mainName);
            document.Add(street);
            document.Add(home);
            document.Add(userId);
            document.Add(proofData);

            form.AddField(nameField);
            form.AddField(dateField);
            form.AddField(mainNameField);
            form.AddField(streetField);
            form.AddField(homeField);
            form.AddField(userIdField);
            form.AddField(proofRadioGroup);
            document.Close();

        }
    }
}