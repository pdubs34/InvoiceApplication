using System.ComponentModel.DataAnnotations;
namespace InvoiceApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty;
        }

        public void setPassword(string password){
            Password = password;
        }
    }
}
