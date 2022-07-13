using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class UserSignUpModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(80)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
