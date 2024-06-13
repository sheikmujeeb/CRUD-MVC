using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using classlibrary;

namespace CRUD_MVC.Controllers
{
    public class Buscontroller : Controller
    {
        busrepos reg;
        IStartPoint value;

        public Buscontroller(IConfiguration fig, IStartPoint obj)
        {
            reg = new busrepos(fig);
            value = obj;
        }
        // GET: Buscontroller
        public ActionResult Show()
        {
            var Model = reg.Showall();
            return View("List", Model);
        }

        // GET: Buscontroller/Details/5
        public ActionResult Details(string name)
        {
            var value =reg.Search(name).FirstOrDefault();
            return View("Details", value);
        }

        // GET: Buscontroller/Create
        public ActionResult Create()
        {
            var result = value.Showall();
            var entity = new Busdetails();
            entity.Location = result;
            return View("Create",entity);
        }

        // POST: Buscontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Busdetails abc)
        {
            try
            {
                reg.SPlogin(abc);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buscontroller/Edit/5
        public ActionResult Edit(string name)
        {
               var find = reg.Search(name).FirstOrDefault();
               return View("Edit",find);
        }

        // POST: Buscontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string StartPoint,string Destination,long Fair,long NoofPassenger)
        {
            try
            {
                reg.SPupdate(id,StartPoint,Destination,Fair,NoofPassenger);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buscontroller/Delete/5
        public ActionResult Delete(string name)
        {
            var del = reg.Search(name).FirstOrDefault();
            return View("Delete", del);
        }

        // POST: Buscontroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Busdetails abc)
        {
            try
            {
                var name = abc.BusName;
                reg.SPremove(name);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }
    }
}
