using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SI_Request.Models.DataModel
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Student Number")]
        [Required]
        public string StudentNumber { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public UserModel? UserModel { get; set; }
    }
}
