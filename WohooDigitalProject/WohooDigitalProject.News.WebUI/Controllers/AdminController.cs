using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WohooDigitalProject.News.Bussiness.Abstract;
using WohooDigitalProject.News.Entities.Concrete;
using WohooDigitalProject.News.WebUI.URLHelper;

namespace WohooDigitalProject.News.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IHaberService _haberService;

        public AdminController(IHaberService haberService)
        {
            _haberService = haberService;
        }

        public ActionResult Index(int page=1)
        {
            double count = _haberService.GetAll().Count();
            TempData["sayfaSayisi"] = (int)Math.Ceiling(count / 2);
            var haberler = _haberService.GetAll().Where(i => i.IsActive == true).OrderBy(i => i.OrderNumber).Skip((page - 1) * 2).Take(2).ToList();
            return View(haberler);
        }
        
        [HttpGet]
        public ActionResult HaberEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult HaberEkle(Haber entity, HttpPostedFileBase imgSource)
        {
            if (imgSource != null && imgSource.ContentLength > 0)
            {
                var extension = Path.GetExtension(imgSource.FileName);
                if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                {
                    var folder = Server.MapPath("~/CmsFile");
                    var imageName = UrlClass.UrlHelper(entity.Title);
                    var FileName = Path.ChangeExtension(imageName, ".jpg");
                    var path = Path.Combine(folder, FileName);
                    imgSource.SaveAs(path);
                    entity.Image = imageName+extension;
                    _haberService.Add(entity);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["message"] = "Resim Değil";

                }
                return View("Error");
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult HaberGuncelle(int id)
        {
            var haber=_haberService.Get(id);
            return View(haber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HaberGuncelle(Haber entity,HttpPostedFileBase imgSource)
        {
            if (imgSource != null && imgSource.ContentLength > 0)
            {
                var extension = Path.GetExtension(imgSource.FileName);
                if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                {
                    var folder = Server.MapPath("~/CmsFile");
                    var imageName = UrlClass.UrlHelper(entity.Title);
                    var FileName = Path.ChangeExtension(imageName, ".jpg");
                    var path = Path.Combine(folder, FileName);
                    imgSource.SaveAs(path);
                    entity.Image = imageName+extension;
                    _haberService.Update(entity);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["message"] = "Resim Değil";

                }
                return View("Error");
            }
            return View("Error");
        }

        public ActionResult Delete(int id)
        {
            _haberService.Delete(_haberService.Get(id));
            return RedirectToAction("Index","Admin");
        }
    }
}