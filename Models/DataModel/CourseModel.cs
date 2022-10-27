using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataModel
{
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
    }
}
