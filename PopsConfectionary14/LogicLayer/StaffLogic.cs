using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.LogicLayer
{
    public class StaffLogic
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Staff> GetData()
        {
            return db.Staff.ToList();
        }

        public List<Staff> GetAll()
        {
            return GetData().Select(x => new Staff
            {
                StaffID = x.StaffID,
                StaffType = x.StaffType,
                Name = x.Name,
                Surname = x.Surname,
                ID_Number = x.ID_Number,
                Email = x.Email,
                Confirm_Email = x.Confirm_Email,
                Contact = x.Contact,
                Atype = x.Atype,
                Address = x.Address,
                Suburb = x.Suburb,
                City = x.City,
                PC = x.PC,
                IsActive = x.IsActive
            }).ToList();
        }

        public List<Staff> GetAllActive()
        {
            return GetAll().Where(x => x.IsActive == true).ToList();
        }

        public List<Staff> GetAllNotActive()
        {
            return GetAll().Where(x => x.IsActive == false).ToList();
        }

        public int Create(Staff staff)
        {
            Staff ss = new Staff();
            ss.StaffID = staff.StaffID;
            ss.StaffType = staff.StaffType;
            ss.Name = staff.Name;
            ss.Surname = staff.Surname;
            ss.ID_Number = staff.ID_Number;
            ss.Email = staff.Email;
            ss.Confirm_Email = staff.Confirm_Email;
            ss.Contact = staff.Contact;
            ss.Atype = staff.Atype;
            ss.Address = staff.Address;
            ss.Suburb = staff.Suburb;
            ss.City = staff.City;
            ss.PC = staff.PC;
            ss.IsActive = true;
            db.Staff.Add(ss);
            db.SaveChanges();
            return ss.StaffID;
        }

        public void Edit(Staff staff)
        {
            Staff ss = db.Staff.SingleOrDefault(x => x.StaffID == staff.StaffID);
            ss.StaffType = staff.StaffType;
            ss.StaffID = staff.StaffID;
            ss.Name = staff.Name;
            ss.Surname = staff.Surname;
            ss.ID_Number = staff.ID_Number;
            ss.Email = staff.Email;
            ss.Confirm_Email = staff.Confirm_Email;
            ss.Contact = staff.Contact;
            ss.Atype = staff.Atype;
            ss.Address = staff.Address;
            ss.Suburb = staff.Suburb;
            ss.City = staff.City;
            ss.PC = staff.PC;
            ss.IsActive = true;
            db.SaveChanges();

        }

        public void Delete(Staff staff)
        {
            Staff ss = new Staff();
            ss = db.Staff.SingleOrDefault(x => x.StaffID == staff.StaffID);
            ss.IsActive = false;
            db.SaveChanges();
        }

        public Staff FindById(int id)
        {
            return GetAll().SingleOrDefault(x => x.StaffID.Equals(id));
        }

        public void ReActivate(Staff staff)
        {
            Staff ss = new Staff();
            ss = db.Staff.SingleOrDefault(x => x.StaffID == staff.StaffID);
            ss.IsActive = true;
            db.SaveChanges();
        }
    }
}