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
    public class HomeController : Controller
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
        public HomeController(IRequestModel requestModel, IStudentModel studentModel, ITaskCategoryModel taskCategory, ITaskModel task, IModuleAssgnModel moduleAssgnModel, IStudentAssistance studentAssistance, IModuleModel moduleModel, ICourseModel courseModel, IComputerModel computer, IRoomModel roomModel, RoleManager<IdentityRoleModel> RoleManger, UserManager<UserModel> UserManger, SignInManager<UserModel> signInManager)
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
        public JsonResult GetById(int Id)
        {
            SelectList Data = new SelectList(_computer.GetByRoomId(Id), "ComputerId", "ComputerNo");
            return Json(Data);
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ModuleId = new SelectList(_moduleModel.GetAll().Where(op => op.Statuse == true), "ModuleId", "ModuleName");
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");

            return View();
        }
 
        public List<ModuleAssgnModel> ASSIST(int ModuleId)
        {
            return _moduleAssgnModel.GetAll().Where(i => i.DayOfWeek == DateTime.Now.DayOfWeek && (i.StartTime.TimeOfDay <= DateTime.Now.TimeOfDay) && (i.EndTime.TimeOfDay >= DateTime.Now.TimeOfDay) && (i.Statuse == true) && (i.ModuleId == ModuleId)).ToList();
        }
        [HttpGet]
        public IActionResult request(int ModuleId,int ComputerId,string Descr)
        {
            if (ModuleId<=0|| ComputerId<=0|| Descr == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var com = _computer.GetById(ComputerId);
                var module = _moduleModel.GetById(ModuleId);
                if(com==null|| module==null)
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
                ViewBag.RequestDescription = Descr;
                ViewBag.ModuleName = module.ModuleName;
                ViewBag.ComputerNo = com.ComputerNo;
                //
                ViewBag.ModuleId = ModuleId;
                ViewBag.ComputerId = ComputerId;
                ViewBag.RequestDescription = Descr;
            }
            var dat = ASSIST(ModuleId);
            return View(dat);
        }
        [HttpPost]
        public async Task<IActionResult> request(int ModuleId, int ComputerId, string RequestDescription,int StudentAssistanceId)
        {
            if (ModuleId <= 0 || ComputerId <= 0 || RequestDescription == null|| StudentAssistanceId <= 0)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var FindLoginUser =await _UserManger.FindByNameAsync(User.Identity.Name);
             
                if(FindLoginUser==null)
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    var findStudent = _studentModel.GetBySuperId(FindLoginUser.Id);
                    if(findStudent == null)
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }
                    else
                    {
                        RequestModel model = new RequestModel();
                        model.ComputerId = ComputerId;
                        model.ModuleId = ModuleId;
                        model.RequestDescription = RequestDescription;
                        model.RequestTime = DateTime.Now;
                        model.Statuse = true;
                        model.StudentAssistanceId = StudentAssistanceId;
                        model.StudentId = findStudent.StudentId;

                        try
                        {
                            _requestModel.Add(model);
                        }
                        catch
                        {
                            TempData["Error"] = "Somthing Went Wrong Please Try Again";
                            return RedirectToAction("Error", "Account");
                        }
                        TempData["Data"] = "The Request was placed succesfully";
                        return RedirectToAction("MyRequest", "Home");
                    }
                }
               
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> MyRequest()
        {
            if (TempData["Data"] != null)
            {
                ViewBag.Data = TempData["Data"];
                TempData.Clear();
            }
            var FindLoginUser =await _UserManger.FindByNameAsync(User.Identity.Name);

            if (FindLoginUser == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            else
            {
                var findStudent = _studentModel.GetBySuperId(FindLoginUser.Id);
                if (findStudent == null)
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
                else
                {
                    ViewBag.ModuleId = new SelectList(_moduleModel.GetAll(), "ModuleId", "ModuleName");
                    List<RequestModel> model = _requestModel.GetAll().Where(i => i.StudentId == findStudent.StudentId&&i.Statuse==true).ToList();
                    ViewBag.ComputerId = new SelectList(_computer.GetAll(), "ComputerId", "ComputerNo");
                    return View(model);
                }
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(RequestBindDataModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("request", "Home", new { ModuleId = model.ModuleId, ComputerId = model.ComputerId, Descr = model.RequestDescription });
            }
            ViewBag.ModuleId = new SelectList(_moduleModel.GetAll().Where(op => op.Statuse == true), "ModuleId", "ModuleName");
            ViewBag.RoomId = new SelectList(_roomModel.GetAll(), "RoomId", "RoomName");
            return View(model);
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
                IEnumerable<StudentModel> StudentModel = _studentModel.GetAll().Where(r => r.StudentId == assistance.StudentId);
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
                return RedirectToAction("MyRequest", "Home");
            }
            catch
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }



        }
    }
}
