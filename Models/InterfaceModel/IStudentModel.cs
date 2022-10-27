using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IStudentModel
    {
        StudentModel Add(StudentModel model);
        List<StudentModel> GetAll();
        StudentModel GetById(int id);
        StudentModel GetBySuperId(int id);
    }
}
