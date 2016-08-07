using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sity_marz2.Models;

namespace sity_marz2.Controllers
{
    public class DefaultController : Controller
    {
        public city_marzEntities db = new city_marzEntities();

        // GET: Default
        public ActionResult Index()
        {
            List<marz> marzsV = new List<marz>();

            var marzs = from ms in db.marzs select ms; 

            foreach (var ts in marzs)
            {
                marz temp = new marz() { name = ts.name, marz_id = ts.marz_id , note = ts.note };
                marzsV.Add(temp);
            }

            return View(marzsV);
        }

        public PartialViewResult GetCities(int id)
        {
            List<city> citiesV = new List<city>();

            var citiesID = from csID in db.connects where csID.marz_id == id select csID;

            foreach (var ts in citiesID)
            {
                var temp = ts.city;

                citiesV.Add(new city() { city_id = temp.city_id, name = temp.name, note = temp.note });
            }

            ViewBag.mID = id;
            
            return PartialView(citiesV);
        }

        [HttpGet]
        public ActionResult AddMarz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMarz([Bind(Include="name,note")] marz model)
        {
            if (ModelState.IsValid)
            {
                db.marzs.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult AddCity()
        {            
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCity([Bind(Include="name,note,connects")]city model, int id)
        {
            if (ModelState.IsValid)
            {
                db.cities.Add(model);

                db.SaveChanges();

                connect connect = new connect() { marz_id = id, city_id = model.city_id };
                
                db.connects.Add(connect);

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}