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
                    switch (textBoxField?.Name)
                    {
                        case "Consignment Number1":
                            textBoxField.Text = "support@e-iceblue.com";
                            break;
                        case "Item1":
                            textBoxField.Text = "E-iceblue";
                            break;
                        case "Date Span1":
                            textBoxField.Text = "e-iceblue";
                            break;
                        case "Location number from transmittal1":
                            textBoxField.Text = "e-iceblue";
                            break;
                        case "Number of CopiesRow1":
                            textBoxField.Text = "0";
                            break;
                        case "Retrieved by":
                            textBoxField.Text = "Pat";
                            break;
                            
                    }
                }
                
                // Check or uncheck on Check Box field
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = (PdfCheckBoxWidgetFieldWidget) field;
                    switch (checkBoxField.Name)
                    {
                        case "Furnish Copy":
                            checkBoxField.Checked = true;
                            break;
                        case "SRC Delivery":
                            checkBoxField.Checked = true;
                            break;
                    }
                }
            }
            doc.SaveToFile(@"..\..\..\FilledRequestForm.pdf");
        }
    }
}