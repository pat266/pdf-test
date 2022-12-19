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
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\BlankRequestForm.pdf");
            PdfFormWidget formWidget = (PdfFormWidget) doc.Form;
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                //Fill the data for Text Box field
                PdfField field = (PdfField) formWidget.FieldsWidget.List[i];
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
            doc.SaveToFile(@"..\..\..\FilledRequestForm.pdf");
        }
    }
}