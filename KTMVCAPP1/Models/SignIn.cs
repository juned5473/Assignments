using System.ComponentModel.DataAnnotations;

namespace KTMVCAPP1.Models
{
    public class SignIn
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
