using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopsConfectionary14.Models;
using PopsConfectionary14.LogicLayer;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace PopsConfectionary14.LogicLayer
{
    public class RolesBusiness
    {

        UserManager<ApplicationUser> UserManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool AddUserToRoleTwo(string rolename, string username)
        {
            try
            {
                ApplicationUser user = UserManger.FindByName(username);
                IdentityRole role = roleManager.FindByName(rolename);

                if (!UserManger.IsInRole(user.Id, rolename))
                {
                    UserManger.AddToRole(user.Id, rolename);

                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RemoveUserFromRole(string rolename, string username)
        {
            try
            {
                ApplicationUser user = UserManger.FindByName(username);

                IdentityRole role = roleManager.FindByName(rolename);
                if (!UserManger.IsInRole(user.Id, rolename))
                {
                    UserManger.RemoveFromRoleAsync(user.Id, rolename);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<IdentityRole> getdata()
        {
            return roleManager.Roles.ToList();
        }

        public List<RolesViewModel> getall()
        {
            return getdata().Select(x => new RolesViewModel
            {
                RoleName = x.Name,

            }).ToList();
        }

        public RolesViewModel FindByName(string name)
        {
            return getall().SingleOrDefault(x => x.RoleName.Equals(name));
        }
    }
}
