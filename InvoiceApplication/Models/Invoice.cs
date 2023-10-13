namespace InvoiceApplication.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int InvoiceNum { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }
        public int ReturnItemId { get; set; }
        public Item ReturnItem { get; set; }
        public string ReturnReason { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Invoice()
        {
            Description = string.Empty;
            ReturnReason = string.Empty;
            ReturnItem = new Item();
            User = new User();
        }


    }
}
