using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespStudentAssistance: IStudentAssistance
    {
        private DBCONTEX dBCONTEX;
        public RespStudentAssistance(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public StudentAssistanceModel Add(StudentAssistanceModel model)
        {
            dBCONTEX.StudentAssistanceTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;   
        }

        public List<StudentAssistanceModel> GetAll()
        {
            return dBCONTEX.StudentAssistanceTbl.ToList();
        }

        public StudentAssistanceModel GetById(int id)
        {
            return dBCONTEX.StudentAssistanceTbl.FirstOrDefault(I => I.StudentAssistanceId == id);
        }
        public StudentAssistanceModel GetBySuperUserId(int id)
        {
            return dBCONTEX.StudentAssistanceTbl.FirstOrDefault(I => I.Id == id);
        }
        public bool UpdateStatuse(int id,bool Statuse)
        {
           var data= dBCONTEX.StudentAssistanceTbl.FirstOrDefault(I => I.StudentAssistanceId == id);
            if (data!=null)
            {
                data.Statuse = Statuse;
                var save = dBCONTEX.StudentAssistanceTbl.Attach(data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();
            }
            return Statuse;
        }
    }
}
