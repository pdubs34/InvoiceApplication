namespace InvoiceApplication.Models
{
    public class PDFViewModel
    {
        public string Data { get; set; }

        public PDFViewModel() {
            Data = string.Empty;
        }
        public PDFViewModel(string data)
        {
            Data = data;
        }
    }
}
