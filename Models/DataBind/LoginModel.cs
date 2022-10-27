using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SI_Request.Models.DataBind
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
