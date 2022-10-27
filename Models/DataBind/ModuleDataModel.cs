using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataBind
{
    public class ModuleDataModel
    {
        [Key]
        public int Id { get; set; }
        public ModuleModel ModuleModel { get; set; }
        public CourseModel CourseModel { get; set; }
    }
}
