using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataModel
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public int StudentAssistanceId { get; set; }
        [ForeignKey("StudentAssistanceId")]
        public StudentAssistanceModel StudentAssistanceModel { get; set; }
        public bool Statuse { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public  DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime EndTime { get; set; }
        public int TaskCategoryId { get; set; }
        [ForeignKey("TaskCategoryId")]
        public  TaskCategoryModel TaskCategoryModel { get; set; }
    }
}
