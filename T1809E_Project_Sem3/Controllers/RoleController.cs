using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;
        private ApplicationDbContext context = new ApplicationDbContext();

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;

        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Role
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }
        public ActionResult Create()
        {
            return View();
         }
         [HttpPost]
         public async Task<ActionResult> Create(RoleViewModel model)
         {
             if (ModelState.IsValid)
             {
                 var role = new ApplicationRole() {Name = model.Name};
                 await RoleManager.CreateAsync(role);
                 return RedirectToAction("Index");
            }

             return View(model);
        }
         [HttpPost]
        public async Task<ActionResult> Edit(string id,string name)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if (ModelState.IsValid)
            {
                if (role != null)
                {
                    role.Name = name;
                    await RoleManager.UpdateAsync(role);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeleteComfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}