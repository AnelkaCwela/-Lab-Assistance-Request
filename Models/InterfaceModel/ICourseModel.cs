using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface ICourseModel
    {
        CourseModel Add(CourseModel model);
        List<CourseModel> GetAll();
        CourseModel GetById(int id);
        CourseModel Update(CourseModel Model);
    }
}
