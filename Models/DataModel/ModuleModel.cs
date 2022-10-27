using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SI_Request.Models.DataModel
{
    public class ModuleModel
    {
        [Key]
        public int ModuleId { get; set; }
        [Required]
        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }
        [Display(Name = "Statuse")]
        public bool Statuse { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseModel CourseModel { get; set; }
    }
}
