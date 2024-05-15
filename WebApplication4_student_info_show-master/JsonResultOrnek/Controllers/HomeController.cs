using JsonResultOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonResultOrnek.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudent(int id)
        {
            StudentModel model = StudentRepository.StudentList().FirstOrDefault(f => f.ID == id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetStudentAll()
        {
            List<StudentModel> model = StudentRepository.StudentList();
            return Json(model, JsonRequestBehavior.AllowGet);
           
        }


    }
}