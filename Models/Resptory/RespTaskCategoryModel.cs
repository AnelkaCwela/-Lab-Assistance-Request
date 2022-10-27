using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespTaskCategoryModel: ITaskCategoryModel
    {
        private DBCONTEX dBCONTEX;
        public RespTaskCategoryModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public TaskCategoryModel Add(TaskCategoryModel model)
        {
            dBCONTEX.TaskCategoryTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<TaskCategoryModel> GetAll()
        {
          return  dBCONTEX.TaskCategoryTbl.ToList();
        }

        public TaskCategoryModel GetById(int id)
        {
          return  dBCONTEX.TaskCategoryTbl.FirstOrDefault(o => o.TaskCategoryId == id);
        }

        public TaskCategoryModel Update(TaskCategoryModel Model)
        {
            throw new System.NotImplementedException();
        }
    }
}
