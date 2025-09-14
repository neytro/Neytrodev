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
using iText.Kernel.Pdf.Action;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Annot;

class Example
{
    static void Main()
    {
        string dest = @"E:\Programowanie\neytrodev\Interactive PDF\newPdf.pdf";
        string logo = @"E:\Programowanie\neytrodev\Interactive PDF\logo.jpg";


        ///////////////////////////////////////First Page////////////////////////////////////////////////////////////
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
               .SetWidgetRectangle(new Rectangle(180, 748, 200, 18)).CreateText();

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
            jaTextProofData.SetFixedPosition(1, 57, 555, 20);

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
               .SetWidgetRectangle(new Rectangle(180, 530, 370, 18)).CreateText();

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
               .SetWidgetRectangle(new Rectangle(37, 315, 515, 18)).CreateText();

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


            PdfLinkAnnotation linkAnnot = (PdfLinkAnnotation)new PdfLinkAnnotation(new Rectangle(0, 0, 0, 0))
            .SetAction(PdfAction.CreateURI("https://VergesseneTiereinNot.de"))
            .SetBorder(new iText.Kernel.Pdf.PdfArray());

            var webLink = new Paragraph();
            webLink.SetFontSize(5);
            webLink.SetFixedPosition(1, 255, 76, 100);
            webLink.SetBorder(Border.NO_BORDER);
            webLink.SetFontColor(ColorConstants.BLUE);

            var link = new Link("Web: https://VergesseneTiereinNot.de", linkAnnot);
            webLink.Add(link);


            Paragraph nameOfCompany = new Paragraph("„Free Dogs“ Vergessene Tiere in Not e.V.\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tTelefon: +49 151 / 5478 4497\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tGENODEF1MAR\n" + "Moorlager Weg 13 / Amtsgerichts-Eintrag: Kirchenweg 30 \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t E-Mail: info@VergesseneTiereinNot.de\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tRaiffeisen-Volksbank Fresena eG\n" + "26629 Großefehn / Amtsgerichts-Eintrag: 26624 Südbrookmerland \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t DE62 2836 1592 5200 2489 00\n" + "1. Vorsitzender: Günter Lübke\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t Steuernummer: 54/204/00789\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   2. Vorsitzender: Harm Gronewold\n" + "1. und 2. Vorsitzender fungieren bis zur Bestätigung durch die nächste Hauptversammlung/Amtsgerichtseintragung ‚kooptiert‘. Der aktuelle Vorstand besteht nur aus der Kassenwartin und der Schriftführerin.\n" + "Kassenwartin: Sandra Bohlen\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t Register Nr.: VR 200882 AUR \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tSchriftführerin: Jessica Detmers\n" + "Gläubiger-ID: DE04ZZZ00002287351 \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  PayPal-Zahlungen an free.dogs@web.de");
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
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(webLink);
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
            ///////////////////////////////////////Second Page////////////////////////////////////////////////////////////
            pdf.AddNewPage();

            ImageData imageDataPageTwo = ImageDataFactory.Create(logo);
            Image imagePagetwo = new Image(imageData);
            imagePagetwo.ScaleToFit(100, 100);
            imagePagetwo.SetFixedPosition(2, 450, 760);


            Paragraph isInHomeData = new Paragraph("Leben aktuell andere Tiere im Haushalt?");
            isInHomeData.SetFontSize(10);

            Paragraph jaisInHomeData = new Paragraph("Ja");
            jaisInHomeData.SetFontSize(10);
            jaisInHomeData.SetFixedPosition(2, 57, 770, 20);

            Paragraph neinisInHomeData = new Paragraph("Nein");
            neinisInHomeData.SetFontSize(10);
            neinisInHomeData.SetFixedPosition(2, 120, 770, 40);

            RadioFormFieldBuilder isInHomebuilder = new RadioFormFieldBuilder(pdf, "isInHomebuilder");
            PdfButtonFormField isInHomeRadioGroup = isInHomebuilder.CreateRadioGroup();
            Rectangle rectJaisInHome = new Rectangle(37, 770, 15, 15);
            Rectangle rectNeinisInHome = new Rectangle(100, 770, 15, 15);
            PdfFormAnnotation fieldJaisInHome = proofbuilder
                    .CreateRadioButton("rectJaisInHome", rectJaisInHome)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinisInHome = proofbuilder
                    .CreateRadioButton("rectNeinisInHomeo", rectNeinisInHome)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            isInHomeRadioGroup.AddKid(fieldJaisInHome);
            isInHomeRadioGroup.AddKid(fieldNeinisInHome);

            Paragraph isInHomeWhere = new Paragraph("Wenn ja, welche? (Alter, Geschlecht, kastriert/unkastriert, Verträglichkeit)");
            isInHomeWhere.SetFontSize(10);
            PdfTextFormField isInHomeWhereField = new TextFormFieldBuilder(pdf, "isInHomeWhereField")
               .SetWidgetRectangle(new Rectangle(37, 690, 515, 54)).CreateMultilineText();

            Paragraph areDogsDead = new Paragraph("Sind frühere Haustiere verstorben oder mussten abgegeben werden? Bitte mit Begründung");
            areDogsDead.SetFontSize(10);
            PdfTextFormField areDogsDeadField = new TextFormFieldBuilder(pdf, "areDogsDeadField")
               .SetWidgetRectangle(new Rectangle(37, 610, 515, 54)).CreateMultilineText();

            Paragraph howLongAlone = new Paragraph("Wie lange wird der Hund in der Regel allein sein?");
            howLongAlone.SetFontSize(10);
            PdfTextFormField howLongAloneField = new TextFormFieldBuilder(pdf, "howLongAloneField")
               .SetWidgetRectangle(new Rectangle(37, 570, 515, 18)).CreateText();

            Paragraph howLongWalk = new Paragraph("Wie oft und lange werden Spaziergänge eingeplant?");
            howLongWalk.SetFontSize(10);
            PdfTextFormField howLongWalkField = new TextFormFieldBuilder(pdf, "howLongWalkField")
               .SetWidgetRectangle(new Rectangle(37, 520, 515, 18)).CreateText();

            Paragraph whoPlay = new Paragraph("Wie soll der Hund beschäftigt werden?");
            whoPlay.SetFontSize(10);
            PdfTextFormField whoPlayField = new TextFormFieldBuilder(pdf, "whoPlayField")
               .SetWidgetRectangle(new Rectangle(37, 470, 515, 18)).CreateText();


            Paragraph findTrainer = new Paragraph("Soll eine Hundeschule/Hundetrainer*in besucht werden?");
            findTrainer.SetFontSize(10);

            Paragraph jaTextfindTrainer = new Paragraph("Ja");
            jaTextfindTrainer.SetFontSize(10);
            jaTextfindTrainer.SetFixedPosition(2, 57, 430, 20);

            Paragraph neinTextfindTrainera = new Paragraph("Nein");
            neinTextfindTrainera.SetFontSize(10);
            neinTextfindTrainera.SetFixedPosition(2, 120, 430, 200);

            Paragraph descriptionTextfindTrainer = new Paragraph("Nur wenn nötig");
            descriptionTextfindTrainer.SetFontSize(10);
            descriptionTextfindTrainer.SetFixedPosition(2, 183, 430, 200);

            RadioFormFieldBuilder findTrainerfbuilder = new RadioFormFieldBuilder(pdf, "findTrainerfbuilder");
            PdfButtonFormField findTrainerRadioGroup = findTrainerfbuilder.CreateRadioGroup();
            Rectangle findTrainerrectJa = new Rectangle(37, 430, 15, 15);
            Rectangle findTrainerrectNein = new Rectangle(100, 430, 15, 15);
            Rectangle findTrainerrectPart = new Rectangle(163, 430, 15, 15);
            PdfFormAnnotation findTrainerfieldJa = proofbuilder
                    .CreateRadioButton("findTrainerrectJa", findTrainerrectJa)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation findTrainerfieldNein = proofbuilder
                    .CreateRadioButton("findTrainerrectNein", findTrainerrectNein)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation findTrainerfieldPart = proofbuilder
                   .CreateRadioButton("findTrainerrectPart", findTrainerrectPart)
                   .SetBorderWidth(1)
                   .SetBorderColor(ColorConstants.BLACK)
                   .SetBackgroundColor(ColorConstants.WHITE);

            findTrainerRadioGroup.AddKid(findTrainerfieldJa);
            findTrainerRadioGroup.AddKid(findTrainerfieldNein);
            findTrainerRadioGroup.AddKid(findTrainerfieldPart);

            Paragraph whatExpectation = new Paragraph("Welche Erwartungen haben die Interessent*innen an den Hund?");
            whatExpectation.SetFontSize(10);
            PdfTextFormField whatExpectationField = new TextFormFieldBuilder(pdf, "whatExpectationField")
               .SetWidgetRectangle(new Rectangle(37, 345, 515, 54)).CreateMultilineText();

            Paragraph isBehaveStableData = new Paragraph("Ist den Interessent*innen bewusst, dass es keine „Garantie“ auf die Persönlichkeitsentwicklung/gesundheitliche Entwicklung des Hundes gibt? sehr ängstlich, unsicher, nicht stubenrein, nicht verträglich mit anderen Tieren");
            isBehaveStableData.SetFontSize(10);

            Paragraph jaisBehaveStableData = new Paragraph("Ja");
            jaisBehaveStableData.SetFontSize(10);
            jaisBehaveStableData.SetFixedPosition(2, 57, 285, 20);

            Paragraph neinisBehaveStableData = new Paragraph("Nein");
            neinisBehaveStableData.SetFontSize(10);
            neinisBehaveStableData.SetFixedPosition(2, 120, 285, 40);

            RadioFormFieldBuilder isBehaveStablebuilder = new RadioFormFieldBuilder(pdf, "isBehaveStablebuilder");
            PdfButtonFormField isBehaveStableRadioGroup = isBehaveStablebuilder.CreateRadioGroup();
            Rectangle rectJaisBehaveStable = new Rectangle(37, 285, 15, 15);
            Rectangle rectNeinisBehaveStable = new Rectangle(100, 285, 15, 15);
            PdfFormAnnotation fieldJaisBehaveStable = proofbuilder
                    .CreateRadioButton("rectJaisBehaveStable", rectJaisBehaveStable)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinisBehaveStable = proofbuilder
                    .CreateRadioButton("rectNeinisBehaveStableo", rectNeinisBehaveStable)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            isBehaveStableRadioGroup.AddKid(fieldJaisBehaveStable);
            isBehaveStableRadioGroup.AddKid(fieldNeinisBehaveStable);

            Paragraph whatToDowithDog = new Paragraph("Welche unerwünschten Verhaltensweisen bzw. Eigenschaften würden zu einer Abgabe des Hundes führen? Bitte Erläuterung nennen lassen");
            whatToDowithDog.SetFontSize(10);
            PdfTextFormField whatToDowithDognField = new TextFormFieldBuilder(pdf, "whatToDowithDogField")
               .SetWidgetRectangle(new Rectangle(37, 180, 515, 54)).CreateMultilineText();


            var webLink2 = new Paragraph();
            webLink2.SetFontSize(5);
            webLink2.SetFixedPosition(2, 255, 80, 100);
            webLink2.SetBorder(Border.NO_BORDER);
            webLink2.SetFontColor(ColorConstants.BLUE);

            webLink2.Add(link);


            document.Add(imagePagetwo);
            document.Add(isInHomeData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(jaisInHomeData);
            document.Add(neinisInHomeData);
            document.Add(isInHomeWhere);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(areDogsDead);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(howLongAlone);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(howLongWalk);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whoPlay);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(findTrainer);
            document.Add(jaTextfindTrainer);
            document.Add(neinTextfindTrainera);
            document.Add(descriptionTextfindTrainer);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whatExpectation);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(isBehaveStableData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(jaisBehaveStableData);
            document.Add(neinisBehaveStableData);
            document.Add(newLine);
            document.Add(whatToDowithDog);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(nameOfCompany);
            document.Add(webLink2);



            form.AddField(isInHomeRadioGroup);
            form.AddField(isInHomeWhereField);
            form.AddField(areDogsDeadField);
            form.AddField(howLongAloneField);
            form.AddField(howLongWalkField);
            form.AddField(whoPlayField);
            form.AddField(findTrainerRadioGroup);
            form.AddField(whatExpectationField);
            form.AddField(isBehaveStableRadioGroup);
            form.AddField(whatToDowithDognField);

            ///////////////////////////////////////Third Page////////////////////////////////////////////////////////////
            pdf.AddNewPage();

            ImageData imageDataPageThree = ImageDataFactory.Create(logo);
            Image imagePageThree = new Image(imageData);
            imagePageThree.ScaleToFit(100, 100);
            imagePageThree.SetFixedPosition(3, 450, 760);

            document.Add(imagePageThree);

            Paragraph freeTimeWithDog = new Paragraph("Wie planen die Interessent:innen die erste Zeit der Eingewöhnung?");
            freeTimeWithDog.SetFontSize(10);
            PdfTextFormField freeTimeWithDogField = new TextFormFieldBuilder(pdf, "freeTimeWithDogField")
               .SetWidgetRectangle(new Rectangle(37, 680, 515, 54)).CreateMultilineText();

            Paragraph areCostIncludedData = new Paragraph("Sind die Kosten für Futter, Tierarzt, Steuern, Versicherung, etc. eingeplant?");
            areCostIncludedData.SetFontSize(10);

            Paragraph jaareCostIncludedData = new Paragraph("Ja");
            jaareCostIncludedData.SetFontSize(10);
            jaareCostIncludedData.SetFixedPosition(3, 57, 630, 20);

            Paragraph neinareCostIncludedData = new Paragraph("Nein");
            neinareCostIncludedData.SetFontSize(10);
            neinareCostIncludedData.SetFixedPosition(3, 120, 630, 40);

            RadioFormFieldBuilder areCostIncludedbuilder = new RadioFormFieldBuilder(pdf, "areCostIncludedbuilder");
            PdfButtonFormField areCostIncludedRadioGroup = areCostIncludedbuilder.CreateRadioGroup();
            Rectangle rectJaareCostIncluded = new Rectangle(37, 630, 15, 15);
            Rectangle rectNeinareCostIncluded = new Rectangle(100, 630, 15, 15);
            PdfFormAnnotation fieldJaareCostIncluded = proofbuilder
                    .CreateRadioButton("rectJaareCostIncluded", rectJaareCostIncluded)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinareCostIncluded = proofbuilder
                    .CreateRadioButton("rectNeinareCostIncludedo", rectNeinareCostIncluded)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            areCostIncludedRadioGroup.AddKid(fieldJaareCostIncluded);
            areCostIncludedRadioGroup.AddKid(fieldNeinareCostIncluded);

            Paragraph areInformedData = new Paragraph("Sind die Interessent*innen, darüber informiert, dass der Hund bei der Stadt angemeldet und bei der Versicherung mit in die Haftpflichtversicherung aufgenommen werden muss?");
            areInformedData.SetFontSize(10);

            Paragraph jaareInformedData = new Paragraph("Ja");
            jaareInformedData.SetFontSize(10);
            jaareInformedData.SetFixedPosition(3, 57, 570, 20);

            Paragraph neinareInformedData = new Paragraph("Nein");
            neinareInformedData.SetFontSize(10);
            neinareInformedData.SetFixedPosition(3, 120, 570, 40);

            RadioFormFieldBuilder areInformedbuilder = new RadioFormFieldBuilder(pdf, "areInformedbuilder");
            PdfButtonFormField areInformedRadioGroup = areInformedbuilder.CreateRadioGroup();
            Rectangle rectJaareInformed = new Rectangle(37, 570, 15, 15);
            Rectangle rectNeinareInformed = new Rectangle(100, 570, 15, 15);
            PdfFormAnnotation fieldJaareInformed = proofbuilder
                    .CreateRadioButton("rectJaareInformed", rectJaareInformed)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinareInformed = proofbuilder
                    .CreateRadioButton("rectNeinareInformedo", rectNeinareInformed)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            areInformedRadioGroup.AddKid(fieldJaareInformed);
            areInformedRadioGroup.AddKid(fieldNeinareInformed);

            Paragraph areTestedData = new Paragraph("Würden die Interessent*innen einen Test auf Mittelmeerkrankheiten durchführen lassen? Hintergrund: Mittelmeerkrankheiten haben eine Inkubationszeit von ca. 6 Monaten. Sinnvoll wäre ca. 1 Jahr nach Ankunft des Hundes in Deutschland, einen Bluttest auf Mittelmeerkrankheiten durchführen zu lassen");
            areTestedData.SetFontSize(10);

            Paragraph jaareTestedData = new Paragraph("Ja");
            jaareTestedData.SetFontSize(10);
            jaareTestedData.SetFixedPosition(3, 57, 490, 20);

            Paragraph neinareTestedData = new Paragraph("Nein");
            neinareTestedData.SetFontSize(10);
            neinareTestedData.SetFixedPosition(3, 120, 490, 40);

            RadioFormFieldBuilder areTestedbuilder = new RadioFormFieldBuilder(pdf, "areTestedbuilder");
            PdfButtonFormField areTestedRadioGroup = areTestedbuilder.CreateRadioGroup();
            Rectangle rectJaareTested = new Rectangle(37, 490, 15, 15);
            Rectangle rectNeinareTested = new Rectangle(100, 490, 15, 15);
            PdfFormAnnotation fieldJaareTested = proofbuilder
                    .CreateRadioButton("rectJaareTested", rectJaareTested)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinareTested = proofbuilder
                    .CreateRadioButton("rectNeinareTestedo", rectNeinareTested)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            areTestedRadioGroup.AddKid(fieldJaareTested);
            areTestedRadioGroup.AddKid(fieldNeinareTested);

            Paragraph areSecuredData = new Paragraph("Sind die Interessent:innen ausreichend über das Thema Sicherheit aufgeklärt worden? Sicherheitsgeschirr (Doppelsicherung), GPS Tracker, nicht alleine bzw. ungesichert in den Garten/Balkon lassen (trotz Zaun), Türen abschließen, Registrierung bei TASSO/Findefix");
            areSecuredData.SetFontSize(10);

            Paragraph jaareSecuredData = new Paragraph("Ja");
            jaareSecuredData.SetFontSize(10);
            jaareSecuredData.SetFixedPosition(3, 57, 415, 20);

            Paragraph neinareSecuredData = new Paragraph("Nein");
            neinareSecuredData.SetFontSize(10);
            neinareSecuredData.SetFixedPosition(3, 120, 415, 40);

            RadioFormFieldBuilder areSecuredbuilder = new RadioFormFieldBuilder(pdf, "areSecuredbuilder");
            PdfButtonFormField areSecuredRadioGroup = areSecuredbuilder.CreateRadioGroup();
            Rectangle rectJaareSecured = new Rectangle(37, 415, 15, 15);
            Rectangle rectNeinareSecured = new Rectangle(100, 415, 15, 15);
            PdfFormAnnotation fieldJaareSecured = proofbuilder
                    .CreateRadioButton("rectJaareSecured", rectJaareSecured)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinareSecured = proofbuilder
                    .CreateRadioButton("rectNeinareSecuredo", rectNeinareSecured)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            areSecuredRadioGroup.AddKid(fieldJaareSecured);
            areSecuredRadioGroup.AddKid(fieldNeinareSecured);

            Paragraph whoWasTested = new Paragraph("Welche Personen waren bei der Vorkontrolle anwesend? (Bitte namentlich aufführen)");
            whoWasTested.SetFontSize(10);
            PdfTextFormField whoWasTestedField = new TextFormFieldBuilder(pdf, "whoWasTestedField")
               .SetWidgetRectangle(new Rectangle(37, 320, 515, 54)).CreateMultilineText();

            Paragraph privateControle = new Paragraph("Persönlicher Eindruck der Vorkontrolle");
            privateControle.SetFontSize(13);

            Paragraph homeCondition = new Paragraph("Wie ist der Zustand der Wohnung/des Hauses?");
            homeCondition.SetFontSize(10);
            PdfTextFormField homeConditionField = new TextFormFieldBuilder(pdf, "homeConditionField")
               .SetWidgetRectangle(new Rectangle(37, 230, 515, 18)).CreateText();

            Paragraph famileBehave = new Paragraph("Wie war die Stimmung innerhalb der Familie?");
            famileBehave.SetFontSize(10);
            PdfTextFormField famileBehaveField = new TextFormFieldBuilder(pdf, "famileBehavenField")
               .SetWidgetRectangle(new Rectangle(37, 185, 515, 18)).CreateText();

            var webLink3 = new Paragraph();
            webLink3.SetFontSize(5);
            webLink3.SetFixedPosition(3, 255, 76, 100);
            webLink3.SetBorder(Border.NO_BORDER);
            webLink3.SetFontColor(ColorConstants.BLUE);

            webLink3.Add(link);



            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(freeTimeWithDog);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(areCostIncludedData);
            document.Add(jaareCostIncludedData);
            document.Add(neinareCostIncludedData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(areInformedData);
            document.Add(jaareInformedData);
            document.Add(neinareInformedData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(areTestedData);
            document.Add(jaareTestedData);
            document.Add(neinareTestedData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(areSecuredData);
            document.Add(jaareSecuredData);
            document.Add(neinareSecuredData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whoWasTested);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(privateControle);
            document.Add(newLine);
            document.Add(homeCondition);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(famileBehave);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(nameOfCompany);
            document.Add(webLink3);

            form.AddField(freeTimeWithDogField);
            form.AddField(areCostIncludedRadioGroup);
            form.AddField(areInformedRadioGroup);
            form.AddField(areTestedRadioGroup);
            form.AddField(areSecuredRadioGroup);
            form.AddField(whoWasTestedField);
            form.AddField(homeConditionField);
            form.AddField(famileBehaveField);

            ///////////////////////////////////////Fourth Page////////////////////////////////////////////////////////////
            pdf.AddNewPage();

            ImageData imageDataPageFourth = ImageDataFactory.Create(logo);
            Image imagePageFourth = new Image(imageData);
            imagePageFourth.ScaleToFit(100, 100);
            imagePageFourth.SetFixedPosition(4, 450, 760);

            document.Add(imagePageFourth);

            Paragraph whichAnimalsAdditionaly = new Paragraph("Wenn weitere Tiere im Haushalt leben, in welchem Zustand waren die Tiere? (Gesundheitszustand/Verhalten)");
            whichAnimalsAdditionaly.SetFontSize(10);
            PdfTextFormField whichAnimalsAdditionalyField = new TextFormFieldBuilder(pdf, "whichAnimalsAdditionalyField")
               .SetWidgetRectangle(new Rectangle(37, 720, 515, 18)).CreateText();

            Paragraph howToUseToIt = new Paragraph("Wie sind die Interessent*innen mit den im Haushalt lebenden Tieren umgegangen?)");
            howToUseToIt.SetFontSize(10);
            PdfTextFormField howToUseToItField = new TextFormFieldBuilder(pdf, "howToUseToItField")
               .SetWidgetRectangle(new Rectangle(37, 680, 515, 18)).CreateText();

            Paragraph whichConditions = new Paragraph("Wie hat die Umgebung gewirkt? Wo liegt die Wohnung/das Haus? (Ruhig, ländlich, laut, Sackgasse, Hauptstraße, Innenstadt, etc.)");
            whichConditions.SetFontSize(10);
            PdfTextFormField whichConditionsField = new TextFormFieldBuilder(pdf, "whichConditionsField")
               .SetWidgetRectangle(new Rectangle(37, 580, 515, 54)).CreateMultilineText();

            Paragraph DoYouKnowResponsibilityData = new Paragraph("Wissen die Interessent*innen genau, was es bedeutet einen Tierschutzhund aufzunehmen und sind sich über mögliche Komplikationen bewusst?");
            DoYouKnowResponsibilityData.SetFontSize(10);

            Paragraph jaDoYouKnowResponsibilityData = new Paragraph("Ja");
            jaDoYouKnowResponsibilityData.SetFontSize(10);
            jaDoYouKnowResponsibilityData.SetFixedPosition(4, 57, 520, 20);

            Paragraph neinDoYouKnowResponsibilityData = new Paragraph("Nein");
            neinDoYouKnowResponsibilityData.SetFontSize(10);
            neinDoYouKnowResponsibilityData.SetFixedPosition(4, 120, 520, 40);

            RadioFormFieldBuilder DoYouKnowResponsibilitybuilder = new RadioFormFieldBuilder(pdf, "DoYouKnowResponsibilitybuilder");
            PdfButtonFormField DoYouKnowResponsibilityRadioGroup = DoYouKnowResponsibilitybuilder.CreateRadioGroup();
            Rectangle rectJaDoYouKnowResponsibility = new Rectangle(37, 520, 15, 15);
            Rectangle rectNeinDoYouKnowResponsibility = new Rectangle(100, 520, 15, 15);
            PdfFormAnnotation fieldJaDoYouKnowResponsibility = proofbuilder
                    .CreateRadioButton("rectJaDoYouKnowResponsibility", rectJaDoYouKnowResponsibility)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinDoYouKnowResponsibility = proofbuilder
                    .CreateRadioButton("rectNeinDoYouKnowResponsibilityo", rectNeinDoYouKnowResponsibility)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            DoYouKnowResponsibilityRadioGroup.AddKid(fieldJaDoYouKnowResponsibility);
            DoYouKnowResponsibilityRadioGroup.AddKid(fieldNeinDoYouKnowResponsibility);

            Paragraph resultsTheControl = new Paragraph("Einschätzung der/des Vorkontrolleur*in");
            resultsTheControl.SetFontSize(13);

            Paragraph arrangementData = new Paragraph("Ich kann eine Vermittlung in diesen Haushalt");
            arrangementData.SetFontSize(10);

            Paragraph jaarrangementData = new Paragraph("Empfehlen");
            jaarrangementData.SetFontSize(10);
            jaarrangementData.SetFixedPosition(4, 57, 450, 100);

            Paragraph neinarrangementData = new Paragraph("Nur bedingt empfehlen");
            neinarrangementData.SetFontSize(10);
            neinarrangementData.SetFixedPosition(4, 140, 450, 200);

            Paragraph notRecomendetData = new Paragraph("Nicht empfehlen");
            notRecomendetData.SetFontSize(10);
            notRecomendetData.SetFixedPosition(4, 270, 450, 200);

            RadioFormFieldBuilder arrangementbuilder = new RadioFormFieldBuilder(pdf, "arrangementbuilder");
            PdfButtonFormField arrangementRadioGroup = arrangementbuilder.CreateRadioGroup();
            Rectangle rectJaarrangement = new Rectangle(37, 450, 15, 15);
            Rectangle rectNeinarrangement = new Rectangle(120, 450, 15, 15);
            Rectangle rectNotRecomendetarrangement = new Rectangle(250, 450, 15, 15);
            PdfFormAnnotation fieldJaarrangement = proofbuilder
                    .CreateRadioButton("rectJaarrangement", rectJaarrangement)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNeinarrangement = proofbuilder
                    .CreateRadioButton("rectNeinarrangement", rectNeinarrangement)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            PdfFormAnnotation fieldNotRecomendetarrangement = proofbuilder
                    .CreateRadioButton("rectNotRecomendetarrangement", rectNotRecomendetarrangement)
                    .SetBorderWidth(1)
                    .SetBorderColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);

            arrangementRadioGroup.AddKid(fieldJaarrangement);
            arrangementRadioGroup.AddKid(fieldNeinarrangement);
            arrangementRadioGroup.AddKid(fieldNotRecomendetarrangement);

            Paragraph grounds = new Paragraph("Begründung:");
            grounds.SetFontSize(10);
            PdfTextFormField groundsField = new TextFormFieldBuilder(pdf, "groundsField")
               .SetWidgetRectangle(new Rectangle(37, 400, 515, 18)).CreateText();

            Paragraph controler = new Paragraph("Name Vorkontrolleur*in:");
            controler.SetFontSize(10);
            PdfTextFormField controlerField = new TextFormFieldBuilder(pdf, "controlerField")
               .SetWidgetRectangle(new Rectangle(37, 360, 515, 18)).CreateText();

            Paragraph contact = new Paragraph("Kontaktmöglichkeit Vorkontrolleur*in:");
            contact.SetFontSize(10);
            PdfTextFormField contactField = new TextFormFieldBuilder(pdf, "contactField")
               .SetWidgetRectangle(new Rectangle(37, 320, 515, 18)).CreateText();

            Paragraph removeDocuments = new Paragraph("Ich habe die vom Verein erhaltenen Unterlagen für diese VK gelöscht:");
            removeDocuments.SetFontSize(10);
            PdfTextFormField removeDocumentsField = new TextFormFieldBuilder(pdf, "removeDocumentsField")
               .SetWidgetRectangle(new Rectangle(37, 280, 515, 18)).CreateText();



            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whichAnimalsAdditionaly);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(howToUseToIt);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(whichConditions);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(DoYouKnowResponsibilityData);
            document.Add(jaDoYouKnowResponsibilityData);
            document.Add(neinDoYouKnowResponsibilityData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(resultsTheControl);
            document.Add(arrangementData);
            document.Add(jaarrangementData);
            document.Add(neinarrangementData);
            document.Add(notRecomendetData);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(grounds);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(controler);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(contact);
            document.Add(newLine);
            document.Add(newLine);
            document.Add(removeDocuments);

            form.AddField(whichAnimalsAdditionalyField);
            form.AddField(howToUseToItField);
            form.AddField(whichConditionsField);
            form.AddField(DoYouKnowResponsibilityRadioGroup);
            form.AddField(arrangementRadioGroup);
            form.AddField(groundsField);
            form.AddField(controlerField);
            form.AddField(contactField);
            form.AddField(removeDocumentsField);

            document.Close();

        }
    }
}