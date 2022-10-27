using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataBind
{
    public class RequestBindModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Request Description")]
        public string RequestDescription { get; set; }

        [Required]
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public ModuleModel ModuleModel { get; set; }
        [Required]

        public int ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public ComputerModel ComputerModel { get; set; }
        public int StudentAssistanceId { get; set; }
        public List<ModuleAssgnModel> ModuleAssgnModel { get; set; }

    }
}
