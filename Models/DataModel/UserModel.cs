using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace SI_Request.Models.DataModel
{
    public class UserModel : IdentityUser<int>
    {
        public DateTime RegTime { get; set; }
    }
}
