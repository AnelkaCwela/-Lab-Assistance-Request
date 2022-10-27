using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataModel
{
    public class RoomModel
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public string RoomName { get; set; }
        [Display(Name = "Statuse")]
        public bool Statuse { get; set; }
    }
}
