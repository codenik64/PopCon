using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.LogicLayer
{
    public class ClientBussiness
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Client> GetData()
        {
            return db.Clients.ToList();
        }

        public List<Client> GetAll()
        {
            return GetData().Select(x => new Client
            {
                CusID = x.CusID,
                Cname = x.Cname,
                Surname = x.Surname,
                Contact = x.Contact,
                Email = x.Email,
            }).ToList();
        }

        public void RegisterClient(RegisterViewModel model)
        {
            Client s = new Client();
            s.Cname = model.Name;
            s.Surname = model.Surname;
            s.Email = model.Email;
            s.Address = model.Address;
            s.Contact = model.Contact;
            db.Clients.Add(s);
            db.SaveChanges();
        }
    }
}