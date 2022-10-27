using Microsoft.AspNetCore.Identity;

namespace SI_Request.Models.DataModel
{
 
        public class IdentityRoleModel : IdentityRole<int>
        {
            public string RoleDescription { get; set; }
        }
    
}
