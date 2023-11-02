namespace InvoiceApplication.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public InvoiceItem() {

            Item = new Item();
            Type = string.Empty;
        }

    }
}
