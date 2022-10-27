using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SI_Request.Models.DataModel;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
using SI_Request.Models.DataBind;
using SI_Request.Models.InterfaceModel;
using System.Security.Policy;
using System.Linq;

namespace SI_Request.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<IdentityRoleModel> _RoleManger;
        private readonly IStudentAssistance _studentAssistance;
        private readonly IAdminModel _adminModel;
        private readonly IStudentModel _studentModel;
        public AccountController(IStudentModel studentModel,IAdminModel adminModel,IStudentAssistance studentAssistance,RoleManager<IdentityRoleModel> RoleManger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _studentAssistance = studentAssistance;
            _studentModel = studentModel;
            _adminModel = adminModel;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._RoleManger = RoleManger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #region Student Assistance
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> StudentStatuse(bool statuse ,int Id)
        {
            UserModel userModel = null;
            if (Id>0)
            {
                try
                {
                    var Staff = _studentAssistance.GetById(Id);
                    if (Staff != null)
                    {
                        userModel = await _userManager.FindByIdAsync(Id.ToString());
                    }
                    else
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }


                    if (userModel != null)
                    {
                        if (statuse == true)
                        {

                            _studentAssistance.UpdateStatuse(Id, false);
                            await _userManager.RemoveFromRoleAsync(userModel, "Student Assistance");
                            TempData["Data"] = "User was Removed from the role";
                            return RedirectToAction("StudentAssistance", "Account");

                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(userModel, "Student Assistance");
                            _studentAssistance.UpdateStatuse(Id, true);
                            TempData["Data"] = "User was Assign to the role";
                            return RedirectToAction("StudentAssistance", "Account");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            else
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult StudentAssistance()
        {
            if (TempData["Data"] != null)
            {
                ViewBag.Error = TempData["Data"];
                TempData.Clear();
            }
            return View(_studentAssistance.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ActiveStudentAssistance()
        {
            

            return View(_studentAssistance.GetAll().Where(p => p.Statuse ==true));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult InActiveStudentAssistance()
        {

            return View(_studentAssistance.GetAll().Where(p=>p.Statuse==false));
        }
        #endregion
        #region Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminStatuse(bool statuse, int Id)
        {
            UserModel userModel = null;
            if (Id > 0)
            {
                try
                {
                    var Staff = _adminModel.GetById(Id);
                    if (Staff != null)
                    {
                        userModel = await _userManager.FindByIdAsync(Id.ToString());
                    }
                    else
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }


                    if (userModel != null)
                    {
                        if (statuse == true)
                        {

                            _adminModel.UpdateStatuse(Id, false);
                            await _userManager.RemoveFromRoleAsync(userModel, "Admin");
                            TempData["Data"] = "User was Removed from the role";
                            return RedirectToAction("Admin", "Account");

                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(userModel, "Admin");
                            _adminModel.UpdateStatuse(Id, true);
                            TempData["Data"] = "User was Assign to the role";
                            return RedirectToAction("Admin", "Account");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }
                }
                catch
                {
                    TempData["Error"] = "Somthing Went Wrong Please Try Again";
                    return RedirectToAction("Error", "Account");
                }
            }
            else
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {

            return View(_adminModel.GetAll());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ActiveAdmin()
        {

            return View(_adminModel.GetAll().Where(p => p.Statuse == true));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult InActiveAdmin()
        {

            return View(_adminModel.GetAll().Where(p => p.Statuse == false));
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            ViewBag.RoleId = new SelectList(_RoleManger.Roles, "Id", "Name");
         
            return View();
        }
      


        private string Password()
        {
            const string letter = "0M0NB5V4CX9ZA1B2C3D5F4G7H8J9L6PIUYTREWQ";
            StringBuilder res = new StringBuilder();
            int z = 6;
            Random rndm = new Random();
            while (0 < z--)
            {
                res.Append(letter[rndm.Next(letter.Length)]);
            }
            return res.ToString();
        }
        public async Task ConfirmEmail_Token(UserModel userModel,string Password)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(userModel);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = userModel.Id, token }, Request.Scheme);
            SendEmail(userModel.Email, confirmationLink,Password);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterUserModel Model)
        {
            if (ModelState.IsValid)
            {
                string PASSWORD = Password();
                var UserModel = new UserModel { UserName = Model.Email, Email = Model.Email, RegTime = DateTime.Now };
                var RegUser = await _userManager.CreateAsync(UserModel, PASSWORD);
                if (RegUser.Succeeded)
                {
                    await ConfirmEmail_Token(UserModel, PASSWORD);
                    
                    try
                    {
                        if(Model.RoleId==2)
                        {
                            StudentAssistanceModel data = new StudentAssistanceModel();
                            data.StaffNumber = Model.StuffNumber;
                            data.FirstName = Model.FirstName;
                            data.LastName = Model.LastName;
                            data.Statuse = true;
                            data.Id = UserModel.Id;
                            data.Email = Model.Email;

                            await _userManager.AddToRoleAsync(UserModel, "Student Assistance");

                            try
                            {
                                _studentAssistance.Add(data);
                            }
                            catch
                            {
                                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                                return RedirectToAction("Error", "Account");
                            }
                            ViewBag.Success = "User  registered successfully ";
                        }
                        else if (Model.RoleId == 1)
                        {
                            AdminModel data = new AdminModel();
                            data.StaffNumber = Model.StuffNumber;
                            data.FirstName = Model.FirstName;
                            data.LastName = Model.LastName;
                            data.Statuse = true;
                            data.Email = Model.Email;
                            data.Id = UserModel.Id;
                            await _userManager.AddToRoleAsync(UserModel, "Admin");
                            try
                            {
                                _adminModel.Add(data);
                            }
                            catch
                            {
                                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                                return RedirectToAction("Error", "Account");
                            }
                            ViewBag.Success = "User  registered successfully ";
                        }
                        else if (Model.RoleId == 3)
                        {
                            StudentModel data = new StudentModel();
                            data.FirstName = Model.FirstName;
                            data.LastName = Model.LastName;
                            data.StudentNumber = Model.StuffNumber;
                            data.Email = Model.Email;
                            data.Id = UserModel.Id;
                            await _userManager.AddToRoleAsync(UserModel, "Student");
                            try
                            {
                                _studentModel.Add(data);
                            }
                            catch
                            {
                                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                                return RedirectToAction("Error", "Account");
                            }
                            ViewBag.Success = "User  registered successfully ";
                        }

                    }
                    catch
                    {
                        TempData["Error"] = "Somthing Went Wrong Please Try Again";
                        return RedirectToAction("Error", "Account");
                    }


                    TempData["Succeeded"] = "Email Verification Was Sent To Your Email Address";
                    return RedirectToAction("Succeeded", "Account");
                }
                foreach (var error in RegUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.RoleId = new SelectList(_RoleManger.Roles, "Id", "Name");

            return View(Model);
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailIsInUsE(string email)
        {
            var Find_User = await _userManager.FindByEmailAsync(email);

            if (Find_User == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
    
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel Model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var Validate_User = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, true, false);
                if (Validate_User.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {

                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Account");
                }

                ModelState.AddModelError(string.Empty, "Login Failed ... Invalid Email or Password Provided");

            }
            return View(Model);
        }

        [AllowAnonymous]
        public void SendEmail(string? To, string? confirmationLink, string password)
        {

            string Subject = "Email Confimation";
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Your password is "+password+" and Confirm your email before login</p1>" + "<hr/>" + "<a href=" + confirmationLink + ">Confirm</a>";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("noreplay.eprescription@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("noreplay.eprescription@gmail.com", "**********");
            smtp.SendMailAsync(Mail);

        }
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]

        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
            if (UserId == null || token == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");

            }
            var Find_Use = await _userManager.FindByIdAsync(UserId);
            if (Find_Use == null)
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }
            var Confirm_Email = await _userManager.ConfirmEmailAsync(Find_Use, token);
            if (Confirm_Email.Succeeded)
            {
                await _signInManager.SignInAsync(Find_Use, isPersistent: true);

                await _signInManager.SignOutAsync();
                TempData["Succeeded"] = "Your Email Was Confirm Succesfull";
                return RedirectToAction("Succeeded", "Account");
            }
            else
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Succeeded()
        {
            if (TempData["Succeeded"] != null)
            {
                ViewBag.success = TempData["Succeeded"];
                TempData.Clear();
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData.Clear();
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Error()
        {
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData.Clear();
            }
            return View();
        }


    }
}
