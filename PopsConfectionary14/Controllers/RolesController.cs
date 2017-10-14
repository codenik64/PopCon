using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopsConfectionary14.LogicLayer;
using PopsConfectionary14.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PopsConfectionary14.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        UserManager<ApplicationUser> UserManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        ApplicationDbContext db = new ApplicationDbContext();

        RolesBusiness obj = new RolesBusiness();
        // GET: Roles
  

        public ActionResult Index()
        {
            RolesBusiness b = new RolesBusiness();
            return View(b.getall());
        }


        public ActionResult Delete(string name)
        {
            RolesViewModel model = new RolesViewModel();
            RolesBusiness n = new RolesBusiness();
            return View(n.FindByName(name));
        }

        [HttpPost]
        public ActionResult Delete(RolesViewModel model, string name)
        {
            try
            {
                model.RoleName = name;
                var result = roleManager.FindByName(model.RoleName);
                roleManager.Delete(result);


                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Error";
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (roleManager.RoleExists(model.RoleName))
                {
                    ViewBag.Message = "Role Already Exists";
                }
                else
                {
                    IdentityResult result = roleManager.Create(new IdentityRole(model.RoleName));
                    ViewBag.Message = "Role Created";
                }
            }
            return View(model);
        }

        public ActionResult ManageUsers()
        {
            // prepopulat roles for the view dropdown

            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>

            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            ViewBag.Roles = list;

            //Get All Users Into List
            IEnumerable<SelectListItem> items2 = db.Users.Select(c => new SelectListItem
            {
                Value = c.Email,
                Text = c.Email

            });

            //Send To View
            ViewBag.MyUser = items2;
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult GetRoles(string UserName)

        {

            if (!string.IsNullOrWhiteSpace(UserName))

            {

                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));


                if (user.Id != null)
                {
                    ViewBag.RolesForThisUser = manager.GetRoles(user.Id);
                }
                else
                {
                    ViewBag.RolesForThisUser = $"No Records Found for this user";

                }

                // prepopulat roles for the view dropdown

                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

                ViewBag.Roles = list;

                //Get All Users Into List
                IEnumerable<SelectListItem> items2 = db.Users.Select(c => new SelectListItem
                {
                    Value = c.Email,
                    Text = c.Email

                });

                //Send To View
                ViewBag.MyUser = items2;
            }

            else
            {
                ViewBag.del = $"No Records Found!";
            }

            return View("ManageUsers");

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult DeleteRoleForUser(string UserName, string RoleName)

        {

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));



            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();



            if (manager.IsInRole(user.Id, RoleName))

            {

                manager.RemoveFromRole(user.Id, RoleName);

                ViewBag.ResultMessage = "Role removed from this user successfully !";

            }

            else

            {

                ViewBag.Result = "This user doesn't belong to selected role.";

            }

            // prepopulat roles for the view dropdown

            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            ViewBag.Roles = list;

            //Get All Users Into List
            IEnumerable<SelectListItem> items2 = db.Users.Select(c => new SelectListItem
            {
                Value = c.Email,
                Text = c.Email

            });

            //Send To View
            ViewBag.MyUser = items2;

            return View("ManageUsers");

        }

    }
}