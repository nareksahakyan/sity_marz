using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sity_marz2.Models;
using Newtonsoft.Json;

namespace sity_marz2.Controllers
{
    public class searchV2Controller : Controller
    {
        public city_marzEntities db = new city_marzEntities();
        

        // GET: searchV2
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getcitie(string citie)
        {            
            var cities = from cts in db.cities where cts.name == citie select cts ;
                        
            if (cities.FirstOrDefault() != null)
            {
                city citieV = new city() { city_id = cities.First().city_id, name = cities.First().name, note = cities.First().note, connects = cities.First().connects };
                return PartialView(citieV);
            }
            else
            {
                return PartialView("nocitie");
            }

        }

        public JsonResult findcitie(string citie)
        {
            List<string> citie_names = new List<string>();

            if (citie != "")
            {
                var cities = from citie1 in db.cities where citie1.name.Contains(citie) select citie1;

                foreach (var temp in cities)
                {
                    citie_names.Add(temp.name);
                }
            }
            return Json(citie_names);
        }

    }
}