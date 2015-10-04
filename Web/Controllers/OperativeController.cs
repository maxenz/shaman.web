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
    public class OperativeController : ApiController
    {
        //
        // GET: /Operative/
        public OperativeContainerViewModel Get()
        {
            OperativeContainerViewModel operativeViewModel = new OperativeContainerViewModel();
            operativeViewModel.Incidents = IncidentDal.GetAll();
            operativeViewModel.Mobiles = MobileDal.GetAll();
            operativeViewModel.ChartQuantities = IncidentDal.GetChartCantidades(new DateTime(2015, 8, 12));
            operativeViewModel.ChartTimes = IncidentDal.GetChartTiempos(new DateTime(2015, 8, 12));
            return operativeViewModel;
        }
	}
}