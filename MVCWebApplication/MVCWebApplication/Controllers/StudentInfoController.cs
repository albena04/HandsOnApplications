using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication.Models;
namespace MVCWebApplication.Controllers
{
    public class StudentInfoController : Controller
    {
        // GET: StudentInfo
        public ActionResult Index()
        {
            var studentInformations = StudentInfoModel.GetAll();
            return View();
        }
    }
}