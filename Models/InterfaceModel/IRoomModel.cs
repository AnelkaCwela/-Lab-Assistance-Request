using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IRoomModel
    {
        RoomModel Add(RoomModel model);
        List<RoomModel> GetAll();
        RoomModel GetById(int id);
        bool Update(int id, bool Statuse);
    }
}
