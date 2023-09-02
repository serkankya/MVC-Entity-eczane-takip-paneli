using MVC_Eczane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Eczane.Controllers
{
    public class UrunController : Controller
    {

        MVC_EczaneDBEntities2 ent = new MVC_EczaneDBEntities2();

        public ActionResult Index()
        {
            var urunler = ent.tbl_urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> veriler = (from item in ent.tbl_kategoriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.kategoriad,
                                                Value = item.kategoriid.ToString()
                                            }).ToList();
            ViewBag.degerler = veriler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler ekle)
        {
            var kategori = ent.tbl_kategoriler.Where(m => m.kategoriid == ekle.tbl_kategoriler.kategoriid).FirstOrDefault();
            ekle.tbl_kategoriler = kategori;

            ent.tbl_urunler.Add(ekle);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urunSil = ent.tbl_urunler.Find(id);
            ent.tbl_urunler.Remove(urunSil);
            ent.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var urunGuncelle = ent.tbl_urunler.Find(id);

            return View("Guncelle", urunGuncelle);
        }

        public ActionResult VeriGuncelle(tbl_urunler p)
        {
            var urun = ent.tbl_urunler.Find(p.urunid);
            urun.urunad = p.urunad;
            urun.urunuretici = p.urunuretici;
            urun.urunfiyat = p.urunfiyat;
            urun.urunadet = p.urunadet;

            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}