using DataAccess.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Shaman.Controllers
{
    public class MobilesController : Controller
    {
        [System.Web.Mvc.HttpGet]
        public JsonResult GetMobiles()
        {
            return Json(new Mobile(), JsonRequestBehavior.AllowGet);
            //return Json(MobileDal.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}
