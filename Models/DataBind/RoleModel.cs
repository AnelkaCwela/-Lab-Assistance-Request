using System.ComponentModel.DataAnnotations;

namespace SI_Request.Models.DataBind
{
    public class RoleModel
    {
        [Key]
        public int RoleId
        {
            get; set;
        }
        public string RoleName
        {
            get
; set;
        }
        public string RoleDescription
        {
            get
; set;
        }
    }
}
