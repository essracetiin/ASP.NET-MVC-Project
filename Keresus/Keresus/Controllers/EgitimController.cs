using Dapper;
using Keresus.Data;
using Microsoft.AspNetCore.Mvc;

namespace Keresus.Controllers
{
    public class EgitimController : BaseController
    {
        public EgitimController(IConfiguration config) : base(config)
        {
        }

        public IActionResult Liste()
        {
            var qry = "Select * from Egitim";
            var egitims = Connect().Query<Egitim>(qry).ToList();
            return View(egitims);
        }
        
        public IActionResult Guncel(int EgitimId)
        {
            var SecEgitim = EgitimSec(EgitimId);
            return View(SecEgitim);
        }
        [HttpPost]
        public IActionResult Guncel(Egitim egitim)
        {
            var qry = "update Egitim set EgitimAd = @EgitimAd where EgitimId = @EgitimId";
            Connect().ExecuteScalar<int>(qry, egitim);
            return RedirectToAction("Liste");
        }
        public IActionResult Sil(int EgitimId)
        {
            var SecEgitim = EgitimSec(EgitimId);
            return View(SecEgitim);
        }
        [HttpPost]
        public IActionResult Sil(Egitim egitim)
        {
            var qry = "delete from Egitim where EgitimId = @EgitimId";
            Connect().ExecuteScalar<int>(qry, egitim);
            return RedirectToAction("Liste");
        }
        public IActionResult Ekle(Egitim yeniEgitim)
        {
            return View(yeniEgitim);
        }
        [HttpPost]
        public IActionResult Ekle(Egitim egitim,bool asdf)
        {
            var qry = $"insert into Egitim (EgitimAd) values(@EgitimAd)";
            Connect().ExecuteScalar<int>(qry, egitim);
            return RedirectToAction("Liste");
        }
        public Egitim EgitimSec(int EgitimId)
        {
            var qry = $"Select * from Egitim where EgitimId = '{EgitimId}'";
            return Connect().Query<Egitim>(qry).FirstOrDefault();
        }
    }
}
