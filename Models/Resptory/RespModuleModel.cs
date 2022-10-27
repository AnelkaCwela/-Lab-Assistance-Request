using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespModuleModel: IModuleModel
    {
        private DBCONTEX dBCONTEX;
        public RespModuleModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public ModuleModel Add(ModuleModel model)
        {
            dBCONTEX.ModuleTbl.Add(model);
            dBCONTEX.SaveChanges(); 
            return model;   
        }

        public List<ModuleModel> GetAll()
        {
            return dBCONTEX.ModuleTbl.ToList();
        }

        public ModuleModel GetById(int id)
        {
            return dBCONTEX.ModuleTbl.FirstOrDefault(u=>u.ModuleId==id);
        }

        public bool Update(int id, bool Statuse)
        {
            var Data = dBCONTEX.ModuleTbl.FirstOrDefault(i => i.ModuleId == id);
            if (Data != null)
            {
                Data.Statuse = Statuse;
 
                var save = dBCONTEX.ModuleTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return Statuse;
        }
    }
}
