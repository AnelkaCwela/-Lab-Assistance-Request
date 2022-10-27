using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace SI_Request.Models.DataModel
{
    public class RequestModel
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        [Display(Name = "Request Description")]
        public string RequestDescription { get; set; }
        [Display(Name = "Statuse")]
        public bool Statuse { get; set; }
        [Display(Name = "Request Time")]
        public DateTime RequestTime { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentModel StudentModel { get; set; }
        [Required]
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public ModuleModel ModuleModel { get; set; }
        [Required]
        
        public int ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public ComputerModel ComputerModel { get; set; }
        public int StudentAssistanceId { get; set; }
        
    }
}
