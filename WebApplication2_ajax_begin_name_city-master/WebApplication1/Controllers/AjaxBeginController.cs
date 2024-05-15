using WebApplication1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace WebApplication1.Controllers
{
    public class AjaxBeginController : Controller
    {
        // GET: AjaxBegin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            UserCreateViewModel model = new UserCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(UserCreateViewModel model)
        {
            Thread.Sleep(3000);

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                WebApplication1.Models.ExampleDBEntities db = new Models.ExampleDBEntities();
                WebApplication1.Models.Users userModel = new Models.Users();
                userModel.UserName = model.UserName;
                userModel.UserSurname = model.UserSurname;
                userModel.City = model.City;
                db.Users.Add(userModel);
                db.SaveChanges();
                jModel.IsSuccess = true;
                jModel.UserMessage = "Kayıt Başarıyla Gerçekleşti.";
            }
            catch (Exception ex)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Kayıt Gerçekleşemedi. Hata: " + ex.Message;
            }
            return Json(jModel, JsonRequestBehavior.AllowGet);
            
        }

    }
}