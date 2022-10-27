using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.InterfaceModel
{
    public interface ITaskCategoryModel
    {
        TaskCategoryModel Add(TaskCategoryModel model);
        List<TaskCategoryModel> GetAll();
        TaskCategoryModel GetById(int id);
        TaskCategoryModel Update(TaskCategoryModel Model);
    }
}
