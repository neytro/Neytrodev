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
using iText.IO.Image;
using iText.Kernel.XMP.Impl.XPath;

class Example
{
    static void Main()
    {
        string dest = @"E:\Programowanie\neytrodev\Interactive PDF\newPdf.pdf";
        string logo = @"E:\Programowanie\neytrodev\Interactive PDF\logo.jpg";

        using (PdfWriter writer = new PdfWriter(dest))
        using (PdfDocument pdf = new PdfDocument(writer))
        using (Document document = new Document(pdf, PageSize.A4))
        {

            ImageData imageData = ImageDataFactory.Create(logo);
            Image image = new Image(imageData);
            image.ScaleToFit(100, 100);       
            image.SetFixedPosition(450, 760); 

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
            PdfButtonFormField prooDatafRadioGroup = proofbuilder.CreateRadioGroup();
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
            prooDatafRadioGroup.AddKid(fieldJa);
            prooDatafRadioGroup.AddKid(fieldNein);
            prooDatafRadioGroup.AddKid(fieldPart);

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

            RadioFormFieldBuilder saveDatafbuilder = new RadioFormFieldBuilder(pdf, "saveDatafbuilder");
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

            Paragraph howHeight = new Paragraph("Wenn ja, wie hoch?");
            howHeight.SetFontSize(10);
            PdfTextFormField howHeightField = new TextFormFieldBuilder(pdf, "howHeightField")
               .SetWidgetRectangle(new Rectangle(180, 413, 370, 18)).CreateText();


            Paragraph familyProofData = new Paragraph("Sind alle Familienmitglieder mit der Adoption des Hundes einverstanden?");
            familyProofData.SetFontSize(10);

            Paragraph jafamilyProofData = new Paragraph("Ja");
            jafamilyProofData.SetFontSize(10);
            jafamilyProofData.SetFixedPosition(1, 57, 360, 20);

            Paragraph neinfamilyProofData = new Paragraph("Nein");
            neinfamilyProofData.SetFontSize(10);
            neinfamilyProofData.SetFixedPosition(1, 120, 360, 40);

            RadioFormFieldBuilder familyProofbuilder = new RadioFormFieldBuilder(pdf, "familyProofbuilder");
            PdfButtonFormField familyProoRadioGroup = familyProofbuilder.CreateRadioGroup();
            Rectangle rectJafamilyProof = new Rectangle(37, 360, 15, 15);
            Rectangle rectNeinfamilyProof = new Rectangle(100, 360, 15, 15);
            PdfFormAnnotation fieldJafamilyProof = proofbuilder
                    .CreateRadioButton("rectJafamilyProo", rectJafamilyProof)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinfamilyProof = proofbuilder
                    .CreateRadioButton("rectNeinfamilyProo", rectNeinfamilyProof)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            familyProoRadioGroup.AddKid(fieldJafamilyProof);
            familyProoRadioGroup.AddKid(fieldNeinfamilyProof);

            Paragraph whereVacation = new Paragraph("Wo wird der Hund im Fall einer Erkrankung, Abwesenheit oder eines Urlaubs untergebracht?");
            whereVacation.SetFontSize(10);
            PdfTextFormField whereVacationField = new TextFormFieldBuilder(pdf, "whereVacationField")
               .SetWidgetRectangle(new Rectangle(37,315, 515, 18)).CreateText();

            Paragraph alergieData = new Paragraph("Sind bei einem Familienmitglied Allergien gegen Hunde bekannt?");
            alergieData.SetFontSize(10);

            Paragraph jaalergieData = new Paragraph("Ja");
            jaalergieData.SetFontSize(10);
            jaalergieData.SetFixedPosition(1, 57, 280, 20);

            Paragraph neinalergieData = new Paragraph("Nein");
            neinalergieData.SetFontSize(10);
            neinalergieData.SetFixedPosition(1, 120, 280, 40);

            RadioFormFieldBuilder alergiebuilder = new RadioFormFieldBuilder(pdf, "alergiebuilder");
            PdfButtonFormField alergieRadioGroup = alergiebuilder.CreateRadioGroup();
            Rectangle rectJaalergie = new Rectangle(37, 280, 15, 15);
            Rectangle rectNeinalergie = new Rectangle(100, 280, 15, 15);
            PdfFormAnnotation fieldJaalergie = proofbuilder
                    .CreateRadioButton("rectJaalergie", rectJaalergie)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinalergie = proofbuilder
                    .CreateRadioButton("rectNeinalergieo", rectNeinalergie)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            alergieRadioGroup.AddKid(fieldJaalergie);
            alergieRadioGroup.AddKid(fieldNeinalergie);

            Paragraph wasInHomeData = new Paragraph("Lebten früher schon einmal Tiere im Haushalt?");
            wasInHomeData.SetFontSize(10);

            Paragraph jawasInHomeData = new Paragraph("Ja");
            jawasInHomeData.SetFontSize(10);
            jawasInHomeData.SetFixedPosition(1, 57, 240, 20);

            Paragraph neinwasInHomeData = new Paragraph("Nein");
            neinwasInHomeData.SetFontSize(10);
            neinwasInHomeData.SetFixedPosition(1, 120, 240, 40);

            RadioFormFieldBuilder wasInHomebuilder = new RadioFormFieldBuilder(pdf, "wasInHomebuilder");
            PdfButtonFormField wasInHomeRadioGroup = wasInHomebuilder.CreateRadioGroup();
            Rectangle rectJawasInHome = new Rectangle(37, 240, 15, 15);
            Rectangle rectNeinwasInHome = new Rectangle(100, 240, 15, 15);
            PdfFormAnnotation fieldJawasInHome = proofbuilder
                    .CreateRadioButton("rectJawasInHome", rectJawasInHome)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinwasInHome = proofbuilder
                    .CreateRadioButton("rectNeinwasInHomeo", rectNeinwasInHome)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            wasInHomeRadioGroup.AddKid(fieldJawasInHome);
            wasInHomeRadioGroup.AddKid(fieldNeinwasInHome);

            Paragraph ifThen = new Paragraph("Wenn ja, welche?");
            ifThen.SetFontSize(10);
            PdfTextFormField ifThennField = new TextFormFieldBuilder(pdf, "ifThenField")
               .SetWidgetRectangle(new Rectangle(180, 220, 370, 18)).CreateText();

            Paragraph nameOfCompany = new Paragraph("„Free Dogs“ Vergessene Tiere in Not e.V.\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tTelefon: +49 151 / 5478 4497\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tGENODEF1MAR\n" + "Moorlager Weg 13 / Amtsgerichts-Eintrag: Kirchenweg 30 \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t E-Mail: info@VergesseneTiereinNot.de\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tRaiffeisen-Volksbank Fresena eG\n" + "26629 Großefehn / Amtsgerichts-Eintrag: 26624 Südbrookmerland \t\t\t\t\t\t\t\t\t\t\t\t\tWeb: https://VergesseneTiereinNot.de \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   DE62 2836 1592 5200 2489 00\n" + "1. Vorsitzender: Günter Lübke\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t Steuernummer: 54/204/00789\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   2. Vorsitzender: Harm Gronewold\n" + "1. und 2. Vorsitzender fungieren bis zur Bestätigung durch die nächste Hauptversammlung/Amtsgerichtseintragung ‚kooptiert‘. Der aktuelle Vorstand besteht nur aus der Kassenwartin und der Schriftführerin.\n" + "Kassenwartin: Sandra Bohlen\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t Register Nr.: VR 200882 AUR \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tSchriftführerin: Jessica Detmers\n" + "Gläubiger-ID: DE04ZZZ00002287351 \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  PayPal-Zahlungen an free.dogs@web.de"

                                                     );
            nameOfCompany.SetFontSize(5);

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
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(howHeight);
            document.Add(newLine);
            document.Add(familyProofData);
            document.Add(jafamilyProofData);
            document.Add(neinfamilyProofData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whereVacation);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(alergieData);
            document.Add(jaalergieData);
            document.Add(neinalergieData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(wasInHomeData);
            document.Add(jawasInHomeData);
            document.Add(neinwasInHomeData);
            document.Add(image);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(ifThen);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(nameOfCompany);




            form.AddField(nameField);
            form.AddField(dateField);
            form.AddField(mainNameField);
            form.AddField(streetField);
            form.AddField(homeField);
            form.AddField(userIdField);
            form.AddField(prooDatafRadioGroup);
            form.AddField(explanationField);
            form.AddField(permisionRadioGroup);
            form.AddField(saveDataRadioGroup);
            form.AddField(howHeightField);
            form.AddField(familyProoRadioGroup);
            form.AddField(whereVacationField);
            form.AddField(alergieRadioGroup);
            form.AddField(wasInHomeRadioGroup);
            form.AddField(ifThennField);
            document.Close();

        }
    }
}