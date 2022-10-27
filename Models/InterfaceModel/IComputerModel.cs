using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IComputerModel
    {
        ComputerModel Add(ComputerModel model);
        List<ComputerModel> GetAll();
        ComputerModel GetById(int id);
        ComputerModel Update(ComputerModel model);
       bool Statuse(int Id, bool Statuse);
        List<ComputerModel> GetByRoomId(int id);
    }
}
