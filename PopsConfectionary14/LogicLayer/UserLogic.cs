using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.LogicLayer
{
    public class UserLogic
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<ApplicationUser> GetData()
        {
            return db.Users.ToList();
        }

        public List<ApplicationUser> GetAll()
        {
            return GetData().Select(x => new ApplicationUser {
                Id = x.Id,
                Email = x.Email,
                IsActive = x.IsActive
            }).ToList();
        }

        public List<ApplicationUser> GetAllActive()
        {
            return GetAll().Where(x => x.IsActive == true).ToList();
        }

        public List<ApplicationUser> GetAllNotActive()
        {
            return GetAll().Where(x => x.IsActive == false).ToList();
        }

        public void Delete(ApplicationUser user)
        {
            ApplicationUser ss = new ApplicationUser();
            ss = db.Users.SingleOrDefault(x => x.Id == user.Id);
            ss.IsActive = false;
            db.SaveChanges();
        }

        public ApplicationUser FindById(string id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

      
        public void ReActivate(ApplicationUser user)
        {
            ApplicationUser ss = new ApplicationUser();
            ss = db.Users.SingleOrDefault(x => x.Id == user.Id);
            ss.IsActive = true;
            db.SaveChanges();
        }
    }
}