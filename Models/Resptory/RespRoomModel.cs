using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespRoomModel: IRoomModel
    {
        private DBCONTEX dBCONTEX;
        public RespRoomModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public RoomModel Add(RoomModel model)
        {
            dBCONTEX.RoomTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<RoomModel> GetAll()
        {
            return dBCONTEX.RoomTbl.ToList();
        }

        public RoomModel GetById(int id)
        {
            return dBCONTEX.RoomTbl.FirstOrDefault(o => o.RoomId == id);
        }

        public bool Update(int id, bool Statuse)
        {
            var Data = dBCONTEX.RoomTbl.FirstOrDefault(i => i.RoomId ==id);
            if (Data != null)
            {
                Data.Statuse = Statuse;
                var save = dBCONTEX.RoomTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return Statuse;
        }
    }
}
