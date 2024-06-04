using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Crudlibrary;

namespace CRUD_MVC.Controllers
{
    public class Buscontroller : Controller
    {
        Busdetails bus;
        public Buscontroller()
        {
            bus = new Busdetails();
        }
        // GET: Buscontroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Buscontroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buscontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buscontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buscontroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buscontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buscontroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buscontroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
