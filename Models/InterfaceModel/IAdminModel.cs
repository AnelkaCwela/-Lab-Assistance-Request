using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IAdminModel
    {
        AdminModel Add(AdminModel model);
        List<AdminModel> GetAll();
        AdminModel GetById(int id);
        bool UpdateStatuse(int id, bool Statuse);
    }
}
