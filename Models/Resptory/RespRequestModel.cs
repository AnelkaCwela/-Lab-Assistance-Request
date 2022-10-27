using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespRequestModel: IRequestModel
    {
        private DBCONTEX dBCONTEX;
        public RespRequestModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public RequestModel Add(RequestModel model)
        {
            dBCONTEX.RequestTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<RequestModel> GetAll()
        {
            return dBCONTEX.RequestTbl.ToList();
        }

        public RequestModel GetById(int id)
        {
            return dBCONTEX.RequestTbl.FirstOrDefault(p => p.RequestId == id);
        }
        public bool Update(int id)
        {
            var Data = dBCONTEX.RequestTbl.FirstOrDefault(i => i.RequestId == id);
            if (Data != null)
            {
                Data.Statuse = false;
                var save = dBCONTEX.RequestTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return false;
        }
    }
}
