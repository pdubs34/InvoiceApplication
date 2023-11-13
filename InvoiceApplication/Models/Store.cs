namespace InvoiceApplication.Models
{   
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Store() { 
            Name = string.Empty;
            City = string.Empty;
        }
        
        public Store(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
