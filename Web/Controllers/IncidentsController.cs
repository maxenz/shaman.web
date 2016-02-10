using DataAccess;
using DataAccess.Repositories;
using Domain;
using Shaman.Enums;
using Shaman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class IncidentsController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(IncidentDal.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        public IHttpActionResult GetByPhone(string phone)
        {
            try
            {
                Incident incident = IncidentDal.GetByPhone(phone);
                if (incident == null)
                {
                    ClientMember clientMember = ClientDal.GetByPhone(phone);
                    if (clientMember == null)
                    {
                        return Ok();
                    }
                    return Ok(clientMember);
                }

                return Ok(incident);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult SaveIncident(IncidentViewModel viewModel)
        {
            try
            {
                ValidateIncident(viewModel);
                if (ModelState.IsValid)
                {
                    //Incident incident = IncidentDal.GetByPhone(phone);
                    //if (incident == null)
                    //{
                    //    ClientMember clientMember = ClientDal.GetByPhone(phone);
                    //    if (clientMember == null)
                    //    {
                    //        return Ok();
                    //    }
                    //    return Ok(clientMember);
                    //}

                    //return Ok(incident);
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private void ValidateIncident(IncidentViewModel viewModel)
        {
            if (viewModel.CodigoCliente <= 0)
            {
                ModelState.AddModelError("Cliente", "Debe establecer el código de cliente");
            }

            if (ClientDal.GetIdByNroAfiliado(viewModel.CodigoCliente.ToString(), viewModel.NumeroAfiliado) == null)
            {
                ModelState.AddModelError("Afiliados", "El afiliado no se encuentra en padrón de " + viewModel.CodigoCliente);
            }

            if (viewModel.Clasificacion == Clasificacion.IntDomiciliaria && viewModel.CargaHistorica && viewModel.FechaServicio < DateTime.Now)
            {
                ModelState.AddModelError("Fecha Servicio", "La fecha del servicio no puede ser inferior al día de hoy");
            }
        }
    }
}
