using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sity_marz2.Models;

namespace sity_marz2.Controllers
{
    public class customController : Controller
    {
        public city_marzEntities db = new city_marzEntities();
        
        // GET: custom
        public ActionResult Index()
        {
            var marzes = db.marzs.ToList();           
            return View(marzes);
        }      

        public PartialViewResult getCities(int marz)
        {

            var cities_ = from cities in db.connects where cities.marz_id == marz select cities.city;

            List<city> citiesV = new List<city>();

            foreach (var item in cities_)
            {
                citiesV.Add(new city() { city_id = item.city_id, name = item.name, connects = item.connects, note = item.note });
            }

            return PartialView(citiesV);
        }
    }
}