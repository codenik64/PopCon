using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopsConfectionary14.Models;
using PopsConfectionary14.LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PopsConfectionary12.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        StaffLogic sl = new StaffLogic();

        // GET: Staff
        public ActionResult Index()
        {
            return View(sl.GetAllActive());
        }


        public ActionResult Details(int id)
        {
            return View(sl.FindById(id));
        }


        public ActionResult Create()
        {
            Staff model = new Staff();
            IEnumerable<SelectListItem> items = db.Roles.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name

            });
            ViewBag.StaffType = items;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff Model)
        {
            if (ModelState.IsValid)
            {


                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                string acc = Model.Email;
                var userex = UserManager.FindByName(acc);

                if (userex == null)
                {
                    string UserName = Model.Email;
                    string Email = Model.Email;
                    string Password = "Password01";

                    var user = new ApplicationUser();
                    user.UserName = UserName;
                    user.Email = Email;

                    var newuser = UserManager.Create(user, Password);
                    db.Staff.Add(Model);
                    //UserManager.AddToRoleAsync(user.Id, staff.Role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = $"This E-mail Already Exists , Please Use Another E-mail!";
                }

                RolesBusiness rl = new RolesBusiness();
                rl.AddUserToRoleTwo(Model.StaffType, Model.Email);
                sl.Create(Model);
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        public ActionResult Edit(int id)
        {

            Staff model = new Staff();
            IEnumerable<SelectListItem> items = db.Roles.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name

            });
            ViewBag.StaffType = items;
            return View(sl.FindById(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Staff Model)
        {
            if (ModelState.IsValid)
            {
                 RolesBusiness rl = new RolesBusiness();
                rl.AddUserToRoleTwo(Model.StaffType, Model.Email);
                sl.Edit(Model);
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        public ActionResult Delete(int id)
        {
            return View(sl.FindById(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Staff Model)
        {
            sl.Delete(Model);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteStaff()
        {
            return View(sl.GetAllNotActive());
        }

        public ActionResult ReActivate(int id)
        {
            return View(sl.FindById(id));
        }

        [HttpPost]
        public ActionResult ReActivate(Staff model)
        {
            sl.ReActivate(model);
            return RedirectToAction("Index");
        }

    }
}