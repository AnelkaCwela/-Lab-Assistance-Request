using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SI_Request.Models.DataBind
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users = new List<string>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Role")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Role Description")]
        [Display(Name = "Role Description")]
        public string RoleDescription { get; set; }
        public List<string> Users { get; set; }
    }
}
