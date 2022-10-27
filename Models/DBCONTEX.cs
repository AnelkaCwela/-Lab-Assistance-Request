using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SI_Request.Models.DataModel;

namespace SI_Request.Models
{
    public class DBCONTEX : IdentityDbContext<UserModel, IdentityRoleModel, int>
    {

        public DBCONTEX(DbContextOptions<DBCONTEX> options) : base(options)

        { }
        public DbSet<TaskCategoryModel> TaskCategoryTbl { get; set; }
        public DbSet<TaskModel> TaskTbl { get; set; }
        public DbSet<AdminModel> AdminTbl { get; set; }
        public DbSet<ComputerModel> ComputerTbl { get; set; }
        public DbSet<CourseModel> CourseTbl { get; set; }
        public DbSet<ModuleAssgnModel> ModuleAssgnTbl { get; set; }
        public DbSet<ModuleModel> ModuleTbl { get; set; }
        public DbSet<RequestModel> RequestTbl { get; set; }
        public DbSet<RoomModel> RoomTbl { get; set; }
        public DbSet<StudentAssistanceModel> StudentAssistanceTbl { get; set; }
        public DbSet<StudentModel> StudentTbl { get; set; }





    }
}
