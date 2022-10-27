using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI_Request.Models.DataModel
{
    public class TaskCategoryModel
    {
            [Key]
              public int TaskCategoryId { get; set; }
            [Display(Name ="Task Category")]
            [Required]
            public string TaskCategory { get; set; }
    }
}
