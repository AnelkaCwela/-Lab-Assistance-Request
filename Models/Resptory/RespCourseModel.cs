using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespCourseModel: ICourseModel
    {
        private DBCONTEX dBCONTEX;
        public RespCourseModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public CourseModel Add(CourseModel model)
        {
            dBCONTEX.CourseTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<CourseModel> GetAll()
        {
           return dBCONTEX.CourseTbl.ToList();
        }

        public CourseModel GetById(int id)
        {
            return dBCONTEX.CourseTbl.FirstOrDefault(O => O.CourseId == id);
        }

        public CourseModel Update(CourseModel Model)
        {
            var Data = dBCONTEX.CourseTbl.FirstOrDefault(i => i.CourseId == Model.CourseId);
            if (Data != null)
            {
                Data.CourseName = Model.CourseName;
                var save = dBCONTEX.CourseTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return Model;
        }
    }
}
