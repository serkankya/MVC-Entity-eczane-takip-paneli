using MVC_Eczane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Eczane.Controllers
{
    public class SatisController : Controller
    {
        MVC_EczaneDBEntities2 ent = new MVC_EczaneDBEntities2 ();

        public ActionResult Index()
        {
            var satislar = ent.tbl_satislar.ToList();
            return View(satislar);
        }
    }
}