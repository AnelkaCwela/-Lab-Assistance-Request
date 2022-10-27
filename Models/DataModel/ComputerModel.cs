using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataModel
{
    public class ComputerModel
    {
        [Key]
        public int ComputerId { get; set; }
       
        [Display(Name = "Statuse")]
        public bool statuse { get; set; }
        
        [Required]
        [Display(Name = "Computer Number")]
        public string ComputerNo { get; set; }
        [Display(Name = "Room Number")]
        [Required]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomModel room { get; set; }

    }
}
