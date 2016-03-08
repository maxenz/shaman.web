using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Shaman.Business
{
    public class DispatchPopupManager
    {
        #region Properties

        private long VId { get; set; }
        private string VUlt { get; set; }

        private string[] VSelViajes { get; set; }

        private conIncidentesViajes objViaje { get; set; }

        private conMovilesActuales objMovilActual { get; set; }

        private conIncidentes objIncidente { get; set; }

        #endregion

        #region Constructors

        public DispatchPopupManager()
        {
            this.objViaje = new conIncidentesViajes();
            this.objMovilActual = new conMovilesActuales();
            this.objIncidente = new conIncidentes();
            this.VId = Convert.ToInt64(modDeclares.callInfo);
            this.VUlt = objViaje.GetLastSuceso(VId);

        }

        #endregion

        public DispatchPopupViewModelData GetDispatchPopupData()
        {
            DispatchPopupViewModelData dispVm = new DispatchPopupViewModelData();
            if (modDeclares.callInfo.Contains(modDeclares.nf))
            {
                VSelViajes = modDeclares.callInfo.Split(Convert.ToChar(modDeclares.nf));
            }

            if (VUlt == "D" || VUlt == "H")
            {
                dispVm.Alerts.Add("El servicio ya se encuentra en instancia de derivación");
            } else
            {
                if (objViaje.Abrir(VId.ToString()))
                {
                    dispVm.IncidentDate = objViaje.IncidenteDomicilioId.IncidenteId.FecIncidente;
                    dispVm.IncidentNumber = objViaje.IncidenteDomicilioId.IncidenteId.NroIncidente;
                    dispVm.OperativeGrade = objViaje.IncidenteDomicilioId.IncidenteId.GradoOperativoId.AbreviaturaId;
                    dispVm.OperativeGradeBackColor = objViaje.IncidenteDomicilioId.IncidenteId.GradoOperativoId.ColorHexa;
                    dispVm.Domicile = objViaje.IncidenteDomicilioId.Domicilio.Domicilio;
                    dispVm.Locality = objViaje.IncidenteDomicilioId.LocalidadId.AbreviaturaId;

                    if (objIncidente.Abrir(objViaje.IncidenteDomicilioId.IncidenteId.ID.ToString()))
                    {
                        dispVm.SelectedView = 3;
                        dispVm.ViewEnabled = false;
                    } else
                    {
                        dispVm.SelectedView = 0;
                    }
                }
            }

            return null;
        }
    }
}
