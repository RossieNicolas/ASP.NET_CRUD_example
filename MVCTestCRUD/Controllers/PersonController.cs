using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTestCRUD.Models;

namespace MVCTestCRUD.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Person.ToList());
            }
            
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Person.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Person.Add(person);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Person.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(person).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Person.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    person = db.Person.Where(x => x.Id == id).FirstOrDefault();
                    db.Person.Remove(person);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
