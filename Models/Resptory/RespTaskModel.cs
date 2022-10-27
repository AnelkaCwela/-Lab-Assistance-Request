using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespTaskModel: ITaskModel
    {
        private DBCONTEX dBCONTEX;
        public RespTaskModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public TaskModel Add(TaskModel model)
        {
            dBCONTEX.TaskTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;

        }

        public List<TaskModel> GetAll()
        {
           return dBCONTEX.TaskTbl.ToList();
        }
        public List<TaskModel> GetAssistanceId(int Id)
        {
            return dBCONTEX.TaskTbl.Where(u => u.StudentAssistanceId == Id).ToList();
        }

        public TaskModel GetById(int id)
        {
            return dBCONTEX.TaskTbl.FirstOrDefault(o => o.TaskId == id);
        }
        public bool UpdateStatus(bool  Statuse,int Id)
        {
            var data = dBCONTEX.TaskTbl.FirstOrDefault(I => I.TaskId == Id);
            if (data != null)
            {
                data.Statuse = Statuse;
                var save = dBCONTEX.TaskTbl.Attach(data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();
            }
            return Statuse;
        }
        public TaskModel Update(TaskModel Model)
        {
            throw new System.NotImplementedException();
        }
    }
}
