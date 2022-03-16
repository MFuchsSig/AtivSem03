using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtivSem03.Controllers
{
    public class SetorController : Controller
    {
        // GET: Setor
        public ActionResult Index()
        {
            return View(Repository.Setor.getAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Setor setor)
        {
            Repository.Setor.save(setor);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Repository.Setor.deleteById(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Repository.Setor.getById(id));
        }

        [HttpPost]
        public ActionResult Edit(Models.Setor setor)
        {
            Repository.Setor.update(setor);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(Repository.Setor.getById(id));
        }
    }
}