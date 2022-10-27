﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SI_Request.Models.DataModel
{
    public class StudentAssistanceModel
    {
        [Key]
        public int StudentAssistanceId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Student Number")]
        [Required]
        public string StaffNumber { get; set; }
        [Display(Name = "Statuse")]
        public bool Statuse { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public UserModel? UserModel { get; set; }

    }
}
