using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespModuleAssgnModel: IModuleAssgnModel
    {
        private DBCONTEX dBCONTEX;
        public RespModuleAssgnModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public ModuleAssgnModel Add(ModuleAssgnModel model)
        {
            dBCONTEX.ModuleAssgnTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;

        }

        public List<ModuleAssgnModel> GetAll()
        {
        return    dBCONTEX.ModuleAssgnTbl.ToList();   
        }

        public List<ModuleAssgnModel> GetAllByAssisatnceId(int Id)
        {
            return dBCONTEX.ModuleAssgnTbl.Where(id=>id.StudentAssistanceId==Id).ToList();
        }

        public ModuleAssgnModel GetById(int id)
        {
          return  dBCONTEX.ModuleAssgnTbl.FirstOrDefault(O => O.ModuleId == id);
        }

        public bool Update(int id, bool Statuse)
        {
            var Data = dBCONTEX.ModuleAssgnTbl.FirstOrDefault(i => i.ModuleAssgnId == id);
            if (Data != null)
            {
                Data.Statuse = Statuse;
                var save = dBCONTEX.ModuleAssgnTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return Statuse;
        }
    }
}
