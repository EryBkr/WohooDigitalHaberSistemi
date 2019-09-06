using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WohooDigitalProject.News.Bussiness.Abstract;

namespace WohooDigitalProject.News.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IHaberService _haberService;
        public HomeController(IHaberService haberService)
        {
            _haberService = haberService;

        }
        [Route("")]
        public ActionResult Index(int page=1)
        {
            double count = _haberService.GetAll().Count();
            TempData["sayfaSayisi"] = (int)Math.Ceiling(count / 2);
            var haberler = _haberService.GetAll().Where(i => i.IsActive == true).OrderBy(i => i.OrderNumber).Skip((page-1)*2).Take(2).ToList();

            return View(haberler);
        }

        [Route("haber/{baslik}-{id:int}")]
        public ActionResult HaberDetay(int id)
        {
            var haber = _haberService.Get(id);
            return View(haber);
        }
    }
}