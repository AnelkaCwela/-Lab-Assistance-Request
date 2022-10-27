using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SI_Request.Models.DataModel
{
    public class ModuleAssgnModel
    {
        [Key]
        public int ModuleAssgnId { get; set; }
        public int StudentAssistanceId { get; set; }
        [ForeignKey("StudentAssistanceId")]
        public StudentAssistanceModel StudentAssistanceModel { get; set; }
        public bool Statuse { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public ModuleModel ModuleModel { get; set; }
        //DayOfWeek[] days = {
        //DayOfWeek.Sunday,
        //DayOfWeek.Monday,
        //DayOfWeek.Tuesday,
        //DayOfWeek.Wednesday,
        //DayOfWeek.Thursday,
        //DayOfWeek.Friday,
        //DayOfWeek.Saturday };//Open and close Email alert for staff
    }
}
