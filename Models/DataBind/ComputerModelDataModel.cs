using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataBind
{
    public class ComputerModelDataModel
    {
        [Key]
        public int Id { get; set; }
        public ComputerModel ComputerModel { get; set; }
        public RoomModel room { get; set; }
    }
}
