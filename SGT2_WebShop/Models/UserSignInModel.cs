using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class UserSignInModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
