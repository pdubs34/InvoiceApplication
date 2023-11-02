namespace InvoiceApplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string StoreCode { get; set; }
        public Item() {
            Description = string.Empty;
            StoreCode = string.Empty;
        }
    }
}
