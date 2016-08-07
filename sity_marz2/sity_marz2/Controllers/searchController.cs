using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sity_marz2.Models;
using Newtonsoft.Json;


namespace sity_marz2.Controllers
{
    public class searchController : Controller
    {
        public city_marzEntities db = new city_marzEntities();

        // GET: search
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getSearch(string str)
        {

            List<string> citie_names = new List<string>();
           
            if (str != "")
            {
                    var cities = from citie in db.cities where citie.name.Contains(str) select citie;

                    foreach (var temp in cities)
                    {
                        citie_names.Add(temp.name);
                    }                                    
            }
            return Json(citie_names);             
        }       
    }
}