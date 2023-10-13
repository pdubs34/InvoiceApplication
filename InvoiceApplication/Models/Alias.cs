namespace InvoiceApplication.Models
{
    public class Alias
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Alias() { 
            Name = string.Empty;
            User = new User();
        
        }

    }
}
