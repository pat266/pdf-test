using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace PDF_test
{
    public class Testing
    {
        /**
         * https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/PDF-FormField/Fill-Form-Fields-in-PDF-File-with-C.html
         */
        
        private static IDictionary<string, string> sampleDataTextbox = new Dictionary<string, string>()
        {
            {"Consignment Number1", "21321" },
            {"Item1", "12ds" },
            {"Date Span1", "08-19-2022" },
            {"Location number from transmittal1", "AAA-sdsa" },
            {"Number of CopiesRow1", "12" },
            {"Retrieved by", "Pat" },
        };

        private static HashSet<string> sampleDataCheckbox = new HashSet<string>()
        {
            {"Furnish Copy" },
            {"SRC Delivery" },
        };
        static void Main(string[] args)
        {
            PdfDocument mainDoc = new PdfDocument(); 
            PdfDocument doc1 = new PdfDocument();
            doc1.LoadFromFile(@"..\..\..\BlankRequestForm.pdf");
            PdfFormWidget formWidget1 = (PdfFormWidget) doc1.Form;
            for (int i = 0; i < formWidget1.FieldsWidget.List.Count; i++)
            {
                //Fill the data for Text Box field
                PdfField field = (PdfField) formWidget1.FieldsWidget.List[i];
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget) field;
                    if (sampleDataTextbox.ContainsKey(textBoxField.Name))
                    {
                        textBoxField.Text = sampleDataTextbox[textBoxField.Name];
                    }
                }
                
                // Check or uncheck on Check Box field
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = (PdfCheckBoxWidgetFieldWidget) field;
                    if (sampleDataCheckbox.Contains(checkBoxField.Name))
                    {
                        checkBoxField.Checked = true;
                    }
                }
            }

            PdfDocument doc2 = new PdfDocument();
            doc2.LoadFromFile(@"..\..\..\BlankRequestForm.pdf");
            PdfFormWidget formWidget2 = (PdfFormWidget)doc2.Form;
            for (int i = 0; i < formWidget2.FieldsWidget.List.Count; i++)
            {
                //Fill the data for Text Box field
                PdfField field = (PdfField)formWidget2.FieldsWidget.List[i];
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                    if (sampleDataTextbox.ContainsKey(textBoxField.Name))
                    {
                        textBoxField.Text = sampleDataTextbox[textBoxField.Name];
                    }
                }

                //// Check or uncheck on Check Box field
                //if (field is PdfCheckBoxWidgetFieldWidget)
                //{
                //    PdfCheckBoxWidgetFieldWidget checkBoxField = (PdfCheckBoxWidgetFieldWidget)field;
                //    if (sampleDataCheckbox.Contains(checkBoxField.Name))
                //    {
                //        checkBoxField.Checked = true;
                //    }
                //}
            }


            // test adding another document
            mainDoc.AppendPage(doc1);
            mainDoc.AppendPage(doc2);
            // export file
            mainDoc.SaveToFile(@"..\..\..\FilledRequestForm.pdf");

            // Found from here: https://www.syncfusion.com/kb/4629/how-to-convert-the-pdf-stored-in-a-pdfdocument-object-to-byte-array
            // Creates a new Memory stream
            MemoryStream stream = new MemoryStream();
            // Saves the document as stream
            mainDoc.SaveToStream(stream, FileFormat.PDF);
            mainDoc.Close();
            // Converts the PdfDocument object to byte form.
            byte[] docBytes = stream.ToArray();
            System.Diagnostics.Debug.WriteLine(System.Text.Encoding.Default.GetString(docBytes));
        }
    }
}