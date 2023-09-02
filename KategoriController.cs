using MVC_Eczane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Eczane.Controllers
{
    public class KategoriController : Controller
    {

        MVC_EczaneDBEntities2 ent = new MVC_EczaneDBEntities2();

        public ActionResult Index()
        {
            var kategoriler = ent.tbl_kategoriler.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(tbl_kategoriler ekle)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            ent.tbl_kategoriler.Add(ekle);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategoriSil = ent.tbl_kategoriler.Find(id);
            ent.tbl_kategoriler.Remove(kategoriSil);
            ent.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var kategoriGuncelle = ent.tbl_kategoriler.Find(id);

            return View("Guncelle", kategoriGuncelle);
        }

        public ActionResult VeriGuncelle(tbl_kategoriler p)
        {
            var kategori = ent.tbl_kategoriler.Find(p.kategoriid);

            kategori.kategoriad = p.kategoriad;
            ent.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}