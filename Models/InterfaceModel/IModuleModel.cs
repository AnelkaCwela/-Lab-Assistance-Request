using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IModuleModel
    {
        ModuleModel Add(ModuleModel model);
        List<ModuleModel> GetAll();
        ModuleModel GetById(int id);
        bool Update(int id,bool Statuse);
    }
}
