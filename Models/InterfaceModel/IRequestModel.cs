using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IRequestModel
    {
        RequestModel Add(RequestModel model);
        List<RequestModel> GetAll();
        RequestModel GetById(int id);
        bool Update(int id);
    }
}
