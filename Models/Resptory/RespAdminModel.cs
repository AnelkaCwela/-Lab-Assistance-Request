using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespAdminModel: IAdminModel
    {
        private DBCONTEX dBCONTEX;
        public RespAdminModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public AdminModel Add(AdminModel model)
        {
            dBCONTEX.AdminTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<AdminModel> GetAll()
        {
            return dBCONTEX.AdminTbl.ToList();
        }

        public AdminModel GetById(int id)
        {
            return dBCONTEX.AdminTbl.FirstOrDefault(O => O.AdminId == id);
        }
        public bool UpdateStatuse(int id, bool Statuse)
        {
            var data = dBCONTEX.AdminTbl.FirstOrDefault(O => O.AdminId == id);
            if (data != null)
            {
                data.Statuse = Statuse;
                var save = dBCONTEX.AdminTbl.Attach(data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();
            }
            return Statuse;
        }
    }
}
