using SI_Request.Models.DataModel;
using System.Collections.Generic;

namespace SI_Request.Models.InterfaceModel
{
    public interface IModuleAssgnModel
    {
        ModuleAssgnModel Add(ModuleAssgnModel model);
        List<ModuleAssgnModel> GetAll();
        List<ModuleAssgnModel> GetAllByAssisatnceId(int Id);
        ModuleAssgnModel GetById(int id);
        bool Update(int id,bool Statuse);
    }
}
