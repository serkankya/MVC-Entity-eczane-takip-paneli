using MVC_Eczane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Eczane.Controllers
{
    public class MusteriController : Controller
    {
        MVC_EczaneDBEntities2 ent = new MVC_EczaneDBEntities2();

        public ActionResult Index()
        {
            var musteriler = ent.tbl_musteriler.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            List<SelectListItem> veriler = (from item in ent.tbl_urunler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.urunad,
                                                Value = item.urunid.ToString()
                                            }).ToList();
            ViewBag.degerler = veriler;
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(tbl_musteriler ekle)
        {
            var urun = ent.tbl_urunler.Where(m => m.urunid == ekle.tbl_urunler.urunid).FirstOrDefault();
            ekle.tbl_urunler = urun;

            ent.tbl_musteriler.Add(ekle);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musteriSil = ent.tbl_musteriler.Find(id);
            ent.tbl_musteriler.Remove(musteriSil);
            ent.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var musteriGuncelle = ent.tbl_musteriler.Find(id);

            return View("Guncelle", musteriGuncelle);
        }

        public ActionResult VeriGuncelle(tbl_musteriler p)
        {
            var musteri = ent.tbl_musteriler.Find(p.musteriid);

            musteri.musteriad = p.musteriad;
            musteri.musterisoyad = p.musterisoyad;
            musteri.musteritckimlik = p.musteritckimlik;
            
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}