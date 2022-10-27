using SI_Request.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Models.InterfaceModel
{
    public interface ITaskModel
    {
        TaskModel Add(TaskModel model);
        List<TaskModel> GetAll();
        TaskModel GetById(int id);
        List<TaskModel> GetAssistanceId(int Id);
        TaskModel Update(TaskModel Model);
         bool UpdateStatus(bool Statuse, int Id);
    }
}
