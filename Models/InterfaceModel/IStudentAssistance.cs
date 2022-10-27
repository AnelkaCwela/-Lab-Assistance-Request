using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IStudentAssistance
    {
        StudentAssistanceModel Add(StudentAssistanceModel model);
        List<StudentAssistanceModel> GetAll();
        StudentAssistanceModel GetById(int id);
        bool UpdateStatuse(int id, bool Statuse);
        StudentAssistanceModel GetBySuperUserId(int id);
    }
}
