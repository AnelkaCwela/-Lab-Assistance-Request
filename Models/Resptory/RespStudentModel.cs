using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespStudentModel: IStudentModel
    {
        private DBCONTEX dBCONTEX;
        public RespStudentModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public StudentModel Add(StudentModel model)
        {
            dBCONTEX.StudentTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<StudentModel> GetAll()
        {
            return dBCONTEX.StudentTbl.ToList();
        }

        public StudentModel GetById(int id)
        {
        return    dBCONTEX.StudentTbl.FirstOrDefault(i=> i.StudentId == id);
        }
        public StudentModel GetBySuperId(int id)
        {
            return dBCONTEX.StudentTbl.FirstOrDefault(i => i.Id == id);
        }
    }
}
