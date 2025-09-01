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
               .SetWidgetRectangle(new Rectangle(180, 670, 370, 18)).CreateText();

            Paragraph street = new Paragraph("Straße und Hausnummer:");
            street.SetFontSize(10);
            PdfTextFormField streetField = new TextFormFieldBuilder(pdf, "streetField")
               .SetWidgetRectangle(new Rectangle(180, 647, 370, 18)).CreateText();

            Paragraph home = new Paragraph("PLZ und Wohnort:");
            home.SetFontSize(10);
            PdfTextFormField homeField = new TextFormFieldBuilder(pdf, "homeField")
               .SetWidgetRectangle(new Rectangle(180, 624, 370, 18)).CreateText();

            Paragraph userId = new Paragraph("Personalausweisnummer:");
            userId.SetFontSize(10);
            PdfTextFormField userIdField = new TextFormFieldBuilder(pdf, "userIdField")
               .SetWidgetRectangle(new Rectangle(180, 601, 370, 18)).CreateText();

            Paragraph proofData = new Paragraph("Stimmen die angegebenen Daten aus der Selbstauskunft mit der Wirklichkeit überein?");
            proofData.SetFontSize(10);

            Paragraph jaTextProofData = new Paragraph("Ja");
            jaTextProofData.SetFontSize(10);
            jaTextProofData.SetFixedPosition(1,57, 555, 20);

            Paragraph neinTextProofData = new Paragraph("Nein");
            neinTextProofData.SetFontSize(10);
            neinTextProofData.SetFixedPosition(1, 120, 555, 40);

            Paragraph descriptionTextProofData = new Paragraph("Teilweise, bitte ausführen");
            descriptionTextProofData.SetFontSize(10);
            descriptionTextProofData.SetFixedPosition(1, 183, 555, 200);

            RadioFormFieldBuilder proofbuilder = new RadioFormFieldBuilder(pdf, "proofbuilder");
            PdfButtonFormField proofRadioGroup = proofbuilder.CreateRadioGroup();
            Rectangle rectJa = new Rectangle(37, 555, 15, 15);
            Rectangle rectNein = new Rectangle(100, 555, 15, 15);
            Rectangle rectPart = new Rectangle(163, 555, 15, 15);
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

            Paragraph newLine = new Paragraph("");

            Paragraph explanation = new Paragraph("Erläuterung:");
            explanation.SetFontSize(10);
            PdfTextFormField explanationField = new TextFormFieldBuilder(pdf, "explanationField")
               .SetWidgetRectangle(new Rectangle(180,530, 370, 18)).CreateText();

            Paragraph permisson = new Paragraph("Liegt eine schriftliche Einverständniserklärung des Vermieters zur Hundehaltung vor?");
            permisson.SetFontSize(10);

            Paragraph jaTextPermisionData = new Paragraph("Ja");
            jaTextPermisionData.SetFontSize(10);
            jaTextPermisionData.SetFixedPosition(1, 57, 485, 20);

            Paragraph neinTextPermisionData = new Paragraph("Nein, wird nachgereicht");
            neinTextPermisionData.SetFontSize(10);
            neinTextPermisionData.SetFixedPosition(1, 120, 485, 200);

            Paragraph descriptionTextPermisionData = new Paragraph("Eigentum");
            descriptionTextPermisionData.SetFontSize(10);
            descriptionTextPermisionData.SetFixedPosition(1, 270, 485, 200);

            RadioFormFieldBuilder permisionBuilder = new RadioFormFieldBuilder(pdf, "permisionbuilder");
            PdfButtonFormField permisionRadioGroup = permisionBuilder.CreateRadioGroup();
            Rectangle permisionrectJa = new Rectangle(37, 485, 15, 15);
            Rectangle permisionrectNein = new Rectangle(100, 485, 15, 15);
            Rectangle permisionrectPart = new Rectangle(250, 485, 15, 15);
            PdfFormAnnotation permisionfieldJa = permisionBuilder
                    .CreateRadioButton("permisionrectJa", permisionrectJa)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation permisionfieldNein = permisionBuilder
                    .CreateRadioButton("permisionrectNein", permisionrectNein)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation permisionfieldPart = permisionBuilder
                   .CreateRadioButton("permisionrectPart", permisionrectPart)
                   .SetBorderWidth(1)
                   .SetBorderColor(ColorConstants.BLACK)
                   .SetBackgroundColor(ColorConstants.WHITE);

            permisionRadioGroup.AddKid(permisionfieldJa);
            permisionRadioGroup.AddKid(permisionfieldNein);
            permisionRadioGroup.AddKid(permisionfieldPart);

            Paragraph saveGarten = new Paragraph("Ist der Garten/Hof sicher eingezäunt?");
            saveGarten.SetFontSize(10);

            Paragraph jaTextsaveData = new Paragraph("Ja");
            jaTextsaveData.SetFontSize(10);
            jaTextsaveData.SetFixedPosition(1, 57, 440, 20);

            Paragraph neinTextsaveDataa = new Paragraph("Nein");
            neinTextsaveDataa.SetFontSize(10);
            neinTextsaveDataa.SetFixedPosition(1, 120, 440, 200);

            Paragraph descriptionTextsaveData = new Paragraph("Kein Hof oder Garten vorhanden");
            descriptionTextsaveData.SetFontSize(10);
            descriptionTextsaveData.SetFixedPosition(1, 183, 440, 200);

            RadioFormFieldBuilder saveDatafbuilder = new RadioFormFieldBuilder(pdf, "proofbuilder");
            PdfButtonFormField saveDataRadioGroup = saveDatafbuilder.CreateRadioGroup();
            Rectangle saveDatarectJa = new Rectangle(37, 440, 15, 15);
            Rectangle saveDatarectNein = new Rectangle(100, 440, 15, 15);
            Rectangle saveDatarectPart = new Rectangle(163, 440, 15, 15);
            PdfFormAnnotation saveDatafieldJa = proofbuilder
                    .CreateRadioButton("saveDatarectJa", saveDatarectJa)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation saveDatafieldNein = proofbuilder
                    .CreateRadioButton("saveDatarectNein", saveDatarectNein)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation saveDatafieldPart = proofbuilder
                   .CreateRadioButton("saveDatarectPart", saveDatarectPart)
                   .SetBorderWidth(1)
                   .SetBorderColor(ColorConstants.BLACK)
                   .SetBackgroundColor(ColorConstants.WHITE);
            saveDataRadioGroup.AddKid(saveDatafieldJa);
            saveDataRadioGroup.AddKid(saveDatafieldNein);
            saveDataRadioGroup.AddKid(saveDatafieldPart);

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
            document.Add(jaTextProofData);
            document.Add(neinTextProofData);
            document.Add(descriptionTextProofData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(explanation);
            document.Add(permisson);
            document.Add(jaTextPermisionData);
            document.Add(neinTextPermisionData);
            document.Add(descriptionTextPermisionData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(saveGarten);
            document.Add(jaTextsaveData);
            document.Add(neinTextsaveDataa);
            document.Add(descriptionTextsaveData);

            form.AddField(nameField);
            form.AddField(dateField);
            form.AddField(mainNameField);
            form.AddField(streetField);
            form.AddField(homeField);
            form.AddField(userIdField);
            form.AddField(proofRadioGroup);
            form.AddField(explanationField);
            form.AddField(permisionRadioGroup);
            form.AddField(saveDataRadioGroup);

            document.Close();

        }
    }
}