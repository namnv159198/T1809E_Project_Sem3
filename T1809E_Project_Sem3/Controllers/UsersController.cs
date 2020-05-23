using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using T1809E_Project_Sem3.Models;
using PagedList;

namespace T1809E_Project_Sem3.Controllers
{

    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
       
        // GET: Users
        public ActionResult Index(string sortOrder, int? page, DateTime? start, DateTime? end, int? status, int? gender)
        {
            ViewBag.CurrentSort = sortOrder;
            List<User> t = new List<User>();
            
            foreach (var u in UserManager.Users)
            {
                t.Add(new User(u));
            }
            var list = t.AsEnumerable();

            //if (status.HasValue)
            //{
            //    list = list.Where(p => (int)p.Status == status.Value);
            //}
            //if (gender.HasValue)
            //{
            //    list = list.Where(p => (int)p.Gender == gender.Value);
            //}
            //Search by Time
            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                list = list.Where(p => p.CreateAt >= startDate);
            }
            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                list = list.Where(p => p.CreateAt <= endDate);
            }
            if (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("date-asc"))
            {
                ViewBag.DateSortParm = "date-desc";
                ViewBag.NameSortParm = "name-desc";
                ViewBag.EmailSortParm = "email-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";

            }

            //Date
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.DateSortParm = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.DateSortParm = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            //Email
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.EmailSortParm = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.EmailSortParm = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            //UserName
            else if (sortOrder.Equals("name-asc"))
            {
                ViewBag.NameSortParm = "name-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("name-desc"))
            {
                ViewBag.NameSortParm = "name-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }

            switch (sortOrder)
            {
                case "name-asc":
                    list = list.OrderBy(p => p.UserName);
                    break;
                case "name-desc":
                    list = list.OrderByDescending(p => p.UserName);
                    break;
                case "email-asc":
                    list = list.OrderBy(p => p.Email);
                    break;
                case "email-desc":
                    list = list.OrderByDescending(p => p.Email);
                    break;
                case "date-asc":
                    list = list.OrderBy(p => p.CreateAt);
                    break;
                case "date-desc":
                    list = list.OrderByDescending(p => p.CreateAt);
                    break;
                default:
                    list = list.OrderByDescending(p => p.CreateAt);
                    ViewBag.SortIcon = "fa fa-sort";
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await UserManager.FindByIdAsync(id);
            User u = new User()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                CreateAt = user.CreateAt,
                Status = user.Status,
                Gender = user.Gender,
            };
            if (u == null)
            {
                return HttpNotFound();
            }

            return View(u);
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Address = model.Address, CreateAt = DateTime.Now, PhoneNumber = model.PhoneNumber,Gender = model.Gender };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await UserManager.FindByIdAsync(id);
            User u = new User()
            {
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                Gender = user.Gender,
            };
            if (u == null)
            {
                return HttpNotFound();
            }

            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            var usersIdentity = await UserManager.FindByIdAsync(user.Id);
            if(usersIdentity != null)
            {
                if (ModelState.IsValid)
                {
                    usersIdentity.Email = user.Email;
                    usersIdentity.UserName = user.UserName;
                    usersIdentity.PhoneNumber = user.PhoneNumber;
                    usersIdentity.Address = user.Address;
                    usersIdentity.Status = user.Status;
                    usersIdentity.Gender = user.Gender;
                  var result = await UserManager.UpdateAsync(usersIdentity);
                    if (result.Succeeded)
                    {


                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        return RedirectToAction("Index", "Users");
                    }

                }
            }
            

            return View(user);
        }
    }
}