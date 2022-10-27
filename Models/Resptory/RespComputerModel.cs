using Microsoft.EntityFrameworkCore;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System.Collections.Generic;
using System.Linq;

namespace SI_Request.Models.Resptory
{
    public class RespComputerModel: IComputerModel
    {
        private DBCONTEX dBCONTEX;
        public RespComputerModel(DBCONTEX dBCONTEX)
        {
            this.dBCONTEX = dBCONTEX;
        }

        public ComputerModel Add(ComputerModel model)
        {
            dBCONTEX.ComputerTbl.Add(model);
            dBCONTEX.SaveChanges();
            return model;
        }

        public List<ComputerModel> GetAll()
        {
            return dBCONTEX.ComputerTbl.ToList();
        }

        public ComputerModel GetById(int id)
        {
            return dBCONTEX.ComputerTbl.FirstOrDefault(i=>i.ComputerId==id);
        }
        public List<ComputerModel> GetByRoomId(int id)
        {
            return dBCONTEX.ComputerTbl.Where(i => i.RoomId == id).ToList();
        }
        public bool Statuse(int Id, bool Statuse)
        {
            var Data = dBCONTEX.ComputerTbl.FirstOrDefault(i => i.ComputerId == Id);
            if (Data != null)
            {
                Data.statuse = Statuse;
                var save = dBCONTEX.ComputerTbl.Attach(Data);
                save.State = EntityState.Modified;
                dBCONTEX.SaveChanges();

            }
            return Statuse;
        }
        public ComputerModel Update(ComputerModel model)
        {
            var Data = dBCONTEX.ComputerTbl.FirstOrDefault(i => i.ComputerId == model.ComputerId);
            if (Data != null)
            {
                Data.ComputerNo = model.ComputerNo;
                Data.RoomId = model.RoomId;
                var save = dBCONTEX.ComputerTbl.Attach(Data);
                save.State = EntityState.Modified;
             dBCONTEX.SaveChanges();

            }
            return model;
        }
    }
}
