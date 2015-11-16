using DataAccess.Repositories;
using Domain;
using Domain.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Shaman.Controllers
{
    public class OperativeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [System.Web.Mvc.HttpGet]
        public JsonResult GetIncidents()
        {
            try
            {
                //return Json(new Incident(), JsonRequestBehavior.AllowGet);
               return Json(IncidentDal.GetAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                logger.Error(String.Format("Error trayendo los incidentes : {0}", exception.Message));
                return null;
            }

        }
        [System.Web.Mvc.HttpGet]
        public JsonResult GetMobiles()
        {
            try
            {
                return Json(MobileDal.GetAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                logger.Error(String.Format("Error trayendo los moviles : {0}", exception.Message));
                return null;
            }
        }
        [System.Web.Mvc.HttpGet]
        public JsonResult GetChartsData()
        {
            OperativeContainerViewModel operativeViewModel = new OperativeContainerViewModel();
            operativeViewModel.ChartQuantities = IncidentDal.GetChartCantidades(new DateTime(2015, 8, 12));
            operativeViewModel.ChartTimes = IncidentDal.GetChartTiempos(new DateTime(2015, 8, 12));
            return Json(operativeViewModel, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetIncident(string id)
        {
            return Json(IncidentDal.Get(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetNextIncident(string id)
        {
            return Json(IncidentDal.GetNextIncident(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetPreviousIncident(string id)
        {
            return Json(IncidentDal.GetPreviousIncident(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetFirstIncident(string id)
        {
            return Json(IncidentDal.GetFirstIncident(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetLastIncident(string id)
        {
            return Json(IncidentDal.GetLastIncident(id), JsonRequestBehavior.AllowGet);
        }
    }
}