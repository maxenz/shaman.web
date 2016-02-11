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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetAll()
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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetById(string id)
        {
            try
            {
                return Ok(IncidentDal.GetById(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [HttpOptions]
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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetNewIncidentNumberToCreate()
        {
            try
            {
                return Ok(IncidentDal.GetNewIncidentNumberToCreate());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetFirst()
        {
            try
            {
                return Ok(IncidentDal.GetFirstIncident());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetLast()
        {
            try
            {
                return Ok(IncidentDal.GetLastIncident());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetPrevious(string id)
        {
            try
            {
                return Ok(IncidentDal.GetPreviousIncident(id));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetNext(string id)
        {
            try
            {
                return Ok(IncidentDal.GetNextIncident(id));

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
                    //Incident incident = IncidentDal.SaveIncident(Incidente, IncidentesDomicilios, IncidentesObservaciones, DateTime.Now, Int64 Diagnostico = 0, Int64 Motivo = 0, TiempoCarga IncidenteTiempoCarga = TiempoCarga.Presente);
                    Incident incident = new Incident();
                    return Ok(incident);
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

            if (ClientDal.GetIdByNroAfiliado(viewModel.CodigoCliente.ToString(), viewModel.NroAfiliado) == null)
            {
                ModelState.AddModelError("Afiliados", "El afiliado no se encuentra en padrón de " + viewModel.CodigoCliente);
            }

            if (viewModel.Clasificacion == Clasificacion.IntDomiciliaria && viewModel.CargaHistorica && viewModel.FechaServicio < DateTime.Now)
            {
                ModelState.AddModelError("Fecha Servicio", "La fecha del servicio no puede ser inferior al día de hoy");
            }

            if (viewModel.GradoOperativoId == 0)
            {
                ModelState.AddModelError("Grado Operativo", "Debe establecer el grado operativo del servicio");
            }

            if (String.IsNullOrEmpty(viewModel.DomicilioDescripcion))
            {
                ModelState.AddModelError("Domicilio", "Debe establecer el domicilio del servicio");
            }

            if (viewModel.LocalidadId == 0)
            {
                ModelState.AddModelError("Localidad", "Debe establecer la localidad del domicilio del servicio");
            }

            if (String.IsNullOrEmpty(viewModel.Paciente))
            {
                ModelState.AddModelError("Nombre Paciente", "Debe establecer el nombre del paciente");
            }

            if (String.IsNullOrEmpty(viewModel.DomicilioDestino))
            {
                ModelState.AddModelError("Domicilio Destino", "Debe establecer el domicilio de destino");
            }

            if (String.IsNullOrEmpty(viewModel.LocalidadDestino))
            {
                ModelState.AddModelError("Localidad Destino", "Debe establecer la localidad del domicilio de destino");
            }

            if (String.IsNullOrEmpty(viewModel.LocalidadDestino))
            {
                ModelState.AddModelError("Localidad Destino", "Debe establecer la localidad del domicilio de destino");
            }

            if (viewModel.TipoMorosidad == 2 )
            {
                ModelState.AddModelError("Morosidad", ClientDal.GetEstadoMorosidad(viewModel.CodigoCliente));
            }

            if (viewModel.SinCobertura == 1 || viewModel.SinCobertura == 2)
            {
                //TODO
                //ModelState.AddModelError("Cobertura Grado", ClientDal.GetEstadoMorosidad(viewModel.CodigoCliente));
            }
        }
    }
}
