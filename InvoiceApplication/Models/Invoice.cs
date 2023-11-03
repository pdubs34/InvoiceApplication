 namespace InvoiceApplication.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<InvoiceItem> DeliveredItems { get; set; }
        public ICollection<InvoiceItem> ReturnedItems { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public Invoice()
        {
            DeliveredItems = new List<InvoiceItem>();
            ReturnedItems = new List<InvoiceItem>();
            Store = new Store();
        }
    }
}
