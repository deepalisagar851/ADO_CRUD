using AdoMvc.Models;
using AdoMvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ankitAdocrud.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        EmployeeDb db = new EmployeeDb();
        public ActionResult Index()
        {
            var data = db.GetEmployees();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            db.CreateList(e);
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            db.DeleteList(id);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            var row = db.GetEmployees().Find(model => model.Id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            db.UpdateList(emp);
            return RedirectToAction("Index");
        }
    }
}