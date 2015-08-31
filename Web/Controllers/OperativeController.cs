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

namespace Store.Controllers
{
    public class OperativeController : ApiController
    {
        //
        // GET: /Operative/
        public List<Incident> Get()
        {
            return IncidentDal.GetAll();
        }
	}
}