using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.DataBind
{
    public class RequestViewModel
    {
        public StudentModel StudentModel { get; set; }
        public ModuleModel ModuleModel { get; set; }
        public ComputerModel ComputerModel { get; set; }
        public RequestModel requestModel { get; set; }
        //public StudentAssistanceModel StudentAssistanceModel { get; set; }
    }
}
