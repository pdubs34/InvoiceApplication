namespace InvoiceApplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Item() {
            Name = string.Empty;
            Description = string.Empty;
            Type = string.Empty;
        }
    }
}
