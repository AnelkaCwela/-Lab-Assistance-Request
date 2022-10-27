using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SI_Request.Models.DataBind
{
    public class RegisterUserModel
    {
       [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Stuff Number")]
        [Required]
        public string StuffNumber { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "EmailIsInUsE", controller: "Account")]
        [Required]
        public string Email { get; set; }


        [Display(Name = "Role")]
        [Required]
  
        public int RoleId { get; set; }
    }
}

