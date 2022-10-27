using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SI_Request.Models.DataBind;
using SI_Request.Models.DataModel;
using SI_Request.Models.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Request.Controllers
{
    [Authorize(Roles = "Admin,Student Assistance")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRoleModel> _RoleManger;
        private readonly UserManager<UserModel> _UserManger;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IRoomModel _roomModel;
        private readonly IComputerModel _computer;
        private readonly ICourseModel _courseModel;
        private readonly IModuleModel _moduleModel;
        private readonly IStudentAssistance _studentAssistance;
        private readonly IModuleAssgnModel _moduleAssgnModel;
        private readonly ITaskModel _task;
        private readonly ITaskCategoryModel _taskCategory;
        private readonly IStudentModel _studentModel;
        private readonly IRequestModel _requestModel;
   public AdminController(IRequestModel requestModel,IStudentModel studentModel,ITaskCategoryModel taskCategory,ITaskModel task,IModuleAssgnModel moduleAssgnModel,IStudentAssistance studentAssistance,IModuleModel moduleModel,ICourseModel courseModel,IComputerModel computer,IRoomModel roomModel,RoleManager<IdentityRoleModel> RoleManger, UserManager<UserModel> UserManger, SignInManager<UserModel> signInManager)
        {
            _requestModel = requestModel;
            _roomModel = roomModel;
            _studentModel = studentModel;
            _taskCategory = taskCategory;
            _task = task;
            _moduleAssgnModel = moduleAssgnModel;
            _moduleModel = moduleModel;
            _studentAssistance = studentAssistance;
            _courseModel = courseModel;
            _computer = computer;    
            this._RoleManger = RoleManger;
            this._UserManger = UserManger;
            this._signInManager = signInManager;

        }
        #region Assgin Student Assisatnce
        [HttpGet]
        public IActionResult ViewTask(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var StudenAssistance = _studentAssistance.GetById(Id);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.Id = Id;
                }
                IEnumerable<ModuleModel> Module = _moduleModel.GetAll();
                IEnumerable<ModuleAssgnModel> AssgnModel = _moduleAssgnModel.GetAllByAssisatnceId(Id);

                return View(from AssgnMode in AssgnModel
                            join Room in Module on AssgnMode.ModuleId equals Room.ModuleId into NewList
                            from Room in NewList.DefaultIfEmpty()
                            select new ViewTaskModel
                            {
                                ModuleModel = Room,
                                moduleAssgnModel = AssgnMode
                            });
            }
                

        }
        [HttpGet]
        public IActionResult ViewTask_(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var StudenAssistance = _studentAssistance.GetById(Id);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.Id = Id;
                }
                IEnumerable<TaskCategoryModel> Module = _taskCategory.GetAll();
                IEnumerable<TaskModel> AssgnModel = _task.GetAssistanceId(Id);

                return View(from AssgnMode in AssgnModel
                            join Room in Module on AssgnMode.TaskCategoryId equals Room.TaskCategoryId into NewList
                            from Room in NewList.DefaultIfEmpty()
                            select new TaskViewModelData
                            {
                                TaskCategoryModel = Room,
                                TaskModel = AssgnMode
                            });
            }


        }
        [HttpGet]
        public IActionResult Statuse(int Id,bool Statuse, int i)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                try
                {
                    if (Statuse==true)
                    {
                        _moduleAssgnModel.Update(Id, false);
                    }
                    else
                        _moduleAssgnModel.Update(Id, true);
                    TempData["Data"] = "Statuse Change";
                    if (i>0)
                    {
                        return RedirectToAction("ViewTask", "Admin", new { Id = i });
                    }
                    else
                        return RedirectToAction("StudentAssistance", "Admin");
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }

        }
        [HttpGet]
        public IActionResult Statuse_(int Id, bool Statuse, int i)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                try
                {
                    if (Statuse == true)
                    {
                        _task.UpdateStatus(false,Id);
                    }
                    else
                        _task.UpdateStatus(true,Id);
                    TempData["Data"] = "Statuse Change";
                    if (i > 0)
                    {
                        return RedirectToAction("ViewTask_", "Admin", new { Id = i });
                    }
                    else
                        return RedirectToAction("Assistance", "Admin");
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }

        }
        [HttpGet]
        public IActionResult Assistance(bool Statuse)
        {
            if (TempData["Data"] != null)
            {
                ViewBag.Error = TempData["Data"];
                TempData.Clear();
            }
            if (Statuse == true)
            {
                return View(_studentAssistance.GetAll().Where(o => o.Statuse == false));
            }
            else
                return View(_studentAssistance.GetAll().Where(o => o.Statuse == true));
        }
        [HttpGet]
        public IActionResult StudentAssistance(bool Statuse)
        {
            if (TempData["Data"] != null)
            {
                ViewBag.Error = TempData["Data"];
                TempData.Clear();
            }
            if (Statuse==true)
            {
                return View(_studentAssistance.GetAll().Where(o => o.Statuse == false));
            }
            else
                return View(_studentAssistance.GetAll().Where(o => o.Statuse == true));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Task_(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Statuse = true;
                    _task.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Error while trying process your request";
                    return RedirectToAction("Error", "Account");
                }
                ViewBag.Data = "Request was  successfully";


            }
                var StudenAssistance = _studentAssistance.GetById(model.StudentAssistanceId);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                
            
            ViewBag.FName = StudenAssistance.FirstName;
            ViewBag.LName = StudenAssistance.LastName;
            ViewBag.Staff = StudenAssistance.StaffNumber;
            ViewBag.Email = StudenAssistance.Email;
            ViewBag.TaskCategoryId = new SelectList(_taskCategory.GetAll(), "TaskCategoryId", "TaskCategory");
            return View(model);
        }

        [HttpGet]
        public IActionResult Task_(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var StudenAssistance = _studentAssistance.GetById(Id);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {

                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    TaskModel model = new TaskModel();
                    ViewBag.TaskCategoryId = new SelectList(_taskCategory.GetAll(), "TaskCategoryId", "TaskCategory");
                    model.StudentAssistanceId = StudenAssistance.StudentAssistanceId;
                    // ViewBag.DayOfWeek = new SelectList(DATE().ToList(), "DayOfWeek", "DayOfWeek");

                    return View(model);


                }

            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Task(ModuleAssgnModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Statuse = true;
                    _moduleAssgnModel.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Error while trying process your request";
                    return RedirectToAction("Error", "Account");
                }
                ViewBag.Data = "Request was  successfully";

            }
              var StudenAssistance = _studentAssistance.GetById(model.StudentAssistanceId);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }

                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.ModuleId = new SelectList(_moduleModel.GetAll().Where(op => op.Statuse == true), "ModuleId", "ModuleName");

                    return View(model);
            
        }
       
        [HttpGet]
        public IActionResult Task(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var StudenAssistance = _studentAssistance.GetById(Id);
                if(StudenAssistance==null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                   
                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ModuleAssgnModel model = new ModuleAssgnModel();
                    ViewBag.ModuleId = new SelectList(_moduleModel.GetAll().Where(op => op.Statuse == true), "ModuleId", "ModuleName");
                    model.StudentAssistanceId = StudenAssistance.StudentAssistanceId;
                   // ViewBag.DayOfWeek = new SelectList(DATE().ToList(), "DayOfWeek", "DayOfWeek");
     
                    return View(model);


                }
              
            }
        }

        #endregion
        #region Room Statuse /Edit
        [HttpGet]
        public IActionResult RoomStatuse(int Id, bool Statuse)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                try
                {
                    if(Statuse==true)
                    {
                        _roomModel.Update(Id, false);
                    }
                    else
                    {
                        _roomModel.Update(Id, true);
                    }
                    TempData["Data"] = "Statuse Change";
                    return RedirectToAction("Room", "Admin");
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
        }
        [HttpGet]
        public IActionResult ComputerStatuse(int Id, bool Statuse)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                try
                {
                    if (Statuse == true)
                    {
                        _computer.Statuse(Id, false);
                    }
                    else
                    {
                        _computer.Statuse(Id, true);
                    }
                    TempData["Data"] = "Statuse Change";
                    return RedirectToAction("Computer", "Admin");
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
        }
        [HttpGet]
        public IActionResult ModuleStatuse(int Id,bool Statuse)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                try
                {
                  if (Statuse==false)
                  _moduleModel.Update(Id, true);
                  else
                        _moduleModel.Update(Id, false);
                    TempData["Data"] = "Statuse Change";
                    return RedirectToAction("Module", "Admin");
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }

        }

        [HttpGet]
        public IActionResult EditComputer(int Id)
        {
            if (Id<=0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(_computer.GetById(Id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditComputer(ComputerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Data = "Computer was Updated successfully";
                    _computer.Update(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(model);
        }
        [HttpGet]
        public IActionResult EditCourse(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            return View(_courseModel.GetById(Id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditCourse(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Data = "Course was Updated successfully";
                    _courseModel.Update(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            return View(model);
        }
        #endregion

        #region List Equipment
        [HttpGet]
        public IActionResult Room()
        {

            return View(_roomModel.GetAll());
        }
        [HttpGet]
        public IActionResult InActiveRoom()
        {

            return View(_roomModel.GetAll().Where(p => p.Statuse == false));
        }
        [HttpGet]
        public IActionResult ActiveRoom()
        {

            return View(_roomModel.GetAll().Where(p=>p.Statuse==true));
        }
        [HttpPost]
        public IActionResult Computer(int Id)
        {
            IEnumerable<ComputerModel> Comp = null;
            if (Id>0)
            {
                Comp = _computer.GetAll().Where(i => i.RoomId == Id);
            }
            else
            {
                ViewBag.Error = "Selected Room Number dont exist.";
                Comp = _computer.GetAll();
            }
           
            IEnumerable<RoomModel> Rom = _roomModel.GetAll();
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(from Computer in Comp
                        join Room in Rom on Computer.RoomId equals Room.RoomId into NewList
                        from Room in NewList.DefaultIfEmpty()
                        select new ComputerModelDataModel
                        {
                            room = Room,
                            ComputerModel = Computer
                        });
        }
        [HttpGet]
        public IActionResult Computer()
        {
            if (TempData["Data"] != null)
            {
                ViewBag.Erro = TempData["Data"];
                TempData.Clear();
            }
            IEnumerable<ComputerModel> Comp = _computer.GetAll();
            IEnumerable<RoomModel> Rom = _roomModel.GetAll();
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(from Computer in Comp
                        join Room in Rom on Computer.RoomId equals Room.RoomId into NewList
                        from Room in NewList.DefaultIfEmpty()
                        select new ComputerModelDataModel
                        {
                            room = Room,
                            ComputerModel = Computer
                        });
        }
        [HttpPost]
        public IActionResult Module(int Id)
        {
            IEnumerable<ModuleModel> Module = null;
            if (Id > 0)
                Module = _moduleModel.GetAll().Where(i => i.ModuleId == Id);
            else
                Module = _moduleModel.GetAll();
            IEnumerable<CourseModel> Course = _courseModel.GetAll();
            ViewBag.CourseId = new SelectList(_courseModel.GetAll(), "CourseId", "CourseName");
            return View(from Modules in Module
                        join Courses in Course on Modules.CourseId equals Courses.CourseId into NewList
                        from Courses in NewList.DefaultIfEmpty()
                        select new ModuleDataModel
                        {
                            CourseModel = Courses,
                            ModuleModel = Modules
                        });
        }
        [HttpGet]
        public IActionResult Module()
        {
            IEnumerable<ModuleModel> Module = _moduleModel.GetAll();
            IEnumerable<CourseModel> Course = _courseModel.GetAll();
            ViewBag.CourseId = new SelectList(_courseModel.GetAll(), "CourseId", "CourseName");
            return View(from Modules in Module
                        join Courses in Course on Modules.CourseId equals Courses.CourseId into NewList
                        from Courses in NewList.DefaultIfEmpty()
                        select new ModuleDataModel
                        {
                            CourseModel = Courses,
                            ModuleModel = Modules                          
                        });
        }
        [HttpGet]
        public IActionResult Course()
        {
            return View(_courseModel.GetAll());
        }
        


        #endregion
        #region Create Equipment
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateRoom(RoomModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Statuse = true;
                    ViewBag.Data = "Room was created successfully";
                    _roomModel.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateModule(ModuleModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Statuse = true;
                    ViewBag.Data = "Module was created successfully";
                    _moduleModel.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            ViewBag.CourseId = new SelectList(_courseModel.GetAll(), "CourseId", "CourseName");
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateCourse(CourseModel model)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Data = "Course was created successfully";
                    _courseModel.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateComputer(ComputerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Data = "Computer was created successfully";
                    model.statuse = true;
                    _computer.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {

            return View();
        }
        [HttpGet]
        public IActionResult CreateModule()
        {
            ViewBag.CourseId = new SelectList(_courseModel.GetAll(), "CourseId", "CourseName");
            return View();
        }
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateCategory(TaskCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Data = "Task Category was created successfully";           
                    _taskCategory.Add(model);
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateComputer()
        {
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View();
        }
        #endregion 
        #region Roles
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]

        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRoleModel identityRole = new IdentityRoleModel
                {
                    Name = model.RoleName
                    ,
                    RoleDescription = model.RoleDescription
                };
                IdentityResult result = await _RoleManger.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole", "Admin");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ListRole()
        {
            var role = _RoleManger.Roles;

            return View(role);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole(int Id)
        {
            var role = await _RoleManger.FindByIdAsync(Id.ToString());
            if (role == null)
            {
                ViewBag.errMessage = $"Role with Id = {Id} cannet be found";
                return View("NotFound");
            }
            var model = new EditRoleModel
            {
                Id = role.Id,
                RoleName = role.Name
                ,
                RoleDescription = role.RoleDescription
            };
            foreach (var user in _UserManger.Users)
            {
                if (await _UserManger.IsInRoleAsync(user, role.Name))
                {

                    model.Users.Add(user.UserName);


                }
            }
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            var role = await _RoleManger.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                ViewBag.errMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                role.RoleDescription = model.RoleDescription;
                var result = await _RoleManger.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserToRole(int RoleId)
        {
            ViewBag.RoleId = RoleId;
            var role = await _RoleManger.FindByIdAsync(RoleId.ToString());
            if (role == null)
            {
                ViewBag.errMessage = $"Role with Id = {RoleId} cannet be found";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in _UserManger.Users)
            {

                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName


                };
                if (await _UserManger.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserToRole(List<UserRoleViewModel> model, int RoleId)
        {

            var role = await _RoleManger.FindByIdAsync(RoleId.ToString());
            if (role == null)
            {
                ViewBag.errMessage = $"Role with Id = {model[0].RoleId.ToString()} cannet be found";
                return View("NotFound");
            }
            for (int i = 0; i < model.Count; i++)
            {
                var user = await _UserManger.FindByIdAsync(model[i].UserId.ToString());
                IdentityResult result = null;
                if (model[i].IsSelected && !(await _UserManger.IsInRoleAsync(user, role.Name)))
                {
                    result = await _UserManger.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _UserManger.IsInRoleAsync(user, role.Name))
                {
                    result = await _UserManger.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { id = RoleId });
                }
            }
            return RedirectToAction("EditRole", new { id = RoleId });
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> PracticalTask()
        {
            var FindUser = await _UserManger.FindByNameAsync(User.Identity.Name);
            if (FindUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
       
                var StudenAssistance = _studentAssistance.GetBySuperUserId(FindUser.Id);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.Id = FindUser.Id;
                }
                IEnumerable<ModuleModel> Module = _moduleModel.GetAll();
                IEnumerable<ModuleAssgnModel> AssgnModel = _moduleAssgnModel.GetAllByAssisatnceId(FindUser.Id);

                return View(from AssgnMode in AssgnModel
                            join Room in Module on AssgnMode.ModuleId equals Room.ModuleId into NewList
                            from Room in NewList.DefaultIfEmpty()
                            select new ViewTaskModel
                            {
                                ModuleModel = Room,
                                moduleAssgnModel = AssgnMode
                            });
            }


        }
        [HttpGet]
        public async Task<IActionResult> NormalTask()
        {
            var FindUser =await _UserManger.FindByNameAsync(User.Identity.Name);
            if (FindUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var StudenAssistance = _studentAssistance.GetBySuperUserId(FindUser.Id);
                if (StudenAssistance == null)
                {
                    TempData["Error"] = "We could find the User";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    ViewBag.FName = StudenAssistance.FirstName;
                    ViewBag.LName = StudenAssistance.LastName;
                    ViewBag.Staff = StudenAssistance.StaffNumber;
                    ViewBag.Email = StudenAssistance.Email;
                    ViewBag.Id = FindUser.Id;
                }
                IEnumerable<TaskCategoryModel> Module = _taskCategory.GetAll();
                IEnumerable<TaskModel> AssgnModel = _task.GetAssistanceId(FindUser.Id);

                return View(from AssgnMode in AssgnModel
                            join Room in Module on AssgnMode.TaskCategoryId equals Room.TaskCategoryId into NewList
                            from Room in NewList.DefaultIfEmpty()
                            select new TaskViewModelData
                            {
                                TaskCategoryModel = Room,
                                TaskModel = AssgnMode
                            });
            }


        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> StudentRequest(string Statuse, DateTime EndDate, DateTime StartDate)
        {
            var FindUser = await _UserManger.FindByNameAsync(User.Identity.Name);
            if (FindUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var assistance = _studentAssistance.GetBySuperUserId(FindUser.Id);
                if (assistance==null)
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
               
                IEnumerable<RequestModel> RequestModel = null;
                if (Statuse == 1.ToString() && (EndDate != null && StartDate != null))
                {
                    RequestModel = _requestModel.GetAll().Where(u => u.Statuse == true && u.StudentAssistanceId == assistance.StudentAssistanceId && (u.RequestTime >= StartDate && u.RequestTime <= EndDate));
                }
                else if (Statuse == 2.ToString() && (EndDate != null && StartDate != null))
                    RequestModel = _requestModel.GetAll().Where(u => u.Statuse == false &&u.StudentAssistanceId== assistance.StudentAssistanceId&& (u.RequestTime >= StartDate && u.RequestTime <= EndDate));
                else
                    RequestModel = _requestModel.GetAll().Where(p=>p.StudentAssistanceId== assistance.StudentAssistanceId && p.Statuse == true);
                IEnumerable<StudentModel> StudentModel = _studentModel.GetAll();
                IEnumerable<ModuleModel> ModuleModel = _moduleModel.GetAll();
                IEnumerable<ComputerModel> ComputerModel = _computer.GetAll();
                return View(from Request in RequestModel
                            join Module in ModuleModel on Request.ModuleId equals Module.ModuleId into Tbl
                            from Tbl1 in Tbl.DefaultIfEmpty()

                            join Student in StudentModel on Request.StudentId equals Student.StudentId into Tbl2
                            from Tbl3 in Tbl2.DefaultIfEmpty()

                            join Computer in ComputerModel on Request.ComputerId equals Computer.ComputerId into Tbl4
                            from Tbl5 in Tbl4.DefaultIfEmpty()
                            select new RequestViewModel
                            {
                                StudentModel = Tbl3,
                                ComputerModel = Tbl5,
                                ModuleModel = Tbl1,
                                requestModel = Request
                            });
            }


        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> Student()
        {
            var FindUser = await _UserManger.FindByNameAsync(User.Identity.Name);
            if (FindUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var assistance = _studentModel.GetBySuperId(FindUser.Id);
                if (assistance == null)
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }



                IEnumerable<RequestModel> RequestModel = _requestModel.GetAll().Where(p => p.Statuse == true);
                IEnumerable<StudentModel> StudentModel = _studentModel.GetAll().Where(r=>r.StudentId==assistance.StudentId);
                IEnumerable<ModuleModel> ModuleModel = _moduleModel.GetAll();
                IEnumerable<ComputerModel> ComputerModel = _computer.GetAll();

                return View(from Request in RequestModel
                            join Module in ModuleModel on Request.ModuleId equals Module.ModuleId into Tbl
                            from Tbl1 in Tbl.DefaultIfEmpty()

                            join Student in StudentModel on Request.StudentId equals Student.StudentId into Tbl2
                            from Tbl3 in Tbl2.DefaultIfEmpty()

                            join Computer in ComputerModel on Request.ComputerId equals Computer.ComputerId into Tbl4
                            from Tbl5 in Tbl4.DefaultIfEmpty()
                            select new RequestViewModel
                            {
                                StudentModel = Tbl3,
                                ComputerModel = Tbl5,
                                ModuleModel = Tbl1,
                                requestModel = Request
                            });
            }


        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult request(string Statuse,DateTime EndDate,DateTime StartDate)
        {
   
                IEnumerable<RequestModel> RequestModel = null;
                if (Statuse == 1.ToString()&&(EndDate != null && StartDate != null))
                {
                    RequestModel = _requestModel.GetAll().Where(u => u.Statuse == true && (u.RequestTime >= StartDate && u.RequestTime <= EndDate));
                }
                else if (Statuse == 2.ToString()&& (EndDate != null && StartDate != null))
                    RequestModel = _requestModel.GetAll().Where(u => u.Statuse == false&& (u.RequestTime >= StartDate && u.RequestTime <= EndDate));
                else
                    RequestModel = _requestModel.GetAll();
                IEnumerable<StudentModel> StudentModel = _studentModel.GetAll();
                IEnumerable<ModuleModel> ModuleModel = _moduleModel.GetAll();
                IEnumerable<ComputerModel> ComputerModel = _computer.GetAll();
                return View(from Request in RequestModel
                            join Module in ModuleModel on Request.ModuleId equals Module.ModuleId into Tbl
                            from Tbl1 in Tbl.DefaultIfEmpty()

                            join Student in StudentModel on Request.StudentId equals Student.StudentId into Tbl2
                            from Tbl3 in Tbl2.DefaultIfEmpty()

                            join Computer in ComputerModel on Request.ComputerId equals Computer.ComputerId into Tbl4
                            from Tbl5 in Tbl4.DefaultIfEmpty()
                            select new RequestViewModel
                            {
                                StudentModel = Tbl3,
                                ComputerModel = Tbl5,
                                ModuleModel = Tbl1,
                                requestModel = Request
                            });

        }
        public IActionResult Profile(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
                      
              return View(_studentAssistance.GetById(Id));
        }
        public async Task<IActionResult> Close(int Id)
        {
            if (Id <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            var FindUser = await _UserManger.FindByNameAsync(User.Identity.Name);
            if (FindUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }

            try
            {
                _requestModel.Update(Id);
                return RedirectToAction("StudentRequest", "Admin");
            }
            catch
            {
             TempData["Error"] = "Somthing Went Wrong Please Try Again";
             return RedirectToAction("Error", "Account");
            }

            

        }
    }
}

