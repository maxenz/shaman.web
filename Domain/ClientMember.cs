using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Data;
using Domain.Utils;

namespace Domain
{
    public class ClientMember
    {

        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoIntegrante { get; set; }

        public string AbreviaturaId { get; set; }

        public string NroAfiliado { get; set; }

        public long Documento { get; set; }

        public Domicile Domicilio { get; set; }

        public Locality Localidad { get; set; }

        public string Paciente { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public int Edad { get; set; }

        public DateTime FecNacimiento { get; set; }

        public long SituacionIvaId { get; set; }

        public ClientMember() { }

        public ClientMember(conClientesIntegrantes conClientesIntegrantes )
        {
            this.Id = conClientesIntegrantes.ID;
            this.Nombre = conClientesIntegrantes.Nombre;
            this.Apellido = conClientesIntegrantes.Apellido;
            this.TipoIntegrante = conClientesIntegrantes.TipoIntegrante;
            this.NroAfiliado = conClientesIntegrantes.NroAfiliado;
            this.Documento = conClientesIntegrantes.NroDocumento;
            this.FecNacimiento = conClientesIntegrantes.FecNacimiento;
            if (conClientesIntegrantes.ClienteId != null)
            {
                this.AbreviaturaId = conClientesIntegrantes.ClienteId.AbreviaturaId;
                this.SituacionIvaId = conClientesIntegrantes.ClienteId.SituacionIvaId.ID;
            }

            this.Domicilio = new Domicile(conClientesIntegrantes.Domicilio);
            this.Localidad = new Locality(conClientesIntegrantes.LocalidadId);
            this.Sexo = conClientesIntegrantes.Sexo;
            
            this.SetTelephoneData(conClientesIntegrantes);
            this.SetPatient();
            this.SetAge();

        }

        private void SetTelephoneData(conClientesIntegrantes conClientesIntegrantes)
        {
            if (!string.IsNullOrEmpty(conClientesIntegrantes.Telefono01))
            {
                this.Telefono = conClientesIntegrantes.Telefono01;
                return;
            }

            if (conClientesIntegrantes.Telefono01Fix != 0)
            {
                this.Telefono = Convert.ToString(conClientesIntegrantes.Telefono01Fix);
                return;
            }

            if (!string.IsNullOrEmpty(conClientesIntegrantes.Telefono02))
            {
                this.Telefono = conClientesIntegrantes.Telefono02;
                return;
            }

            if (conClientesIntegrantes.Telefono02Fix != 0)
            {
                this.Telefono = Convert.ToString(conClientesIntegrantes.Telefono02Fix);
                return;
            }
            
        }

        private void SetPatient()
        {
            if (!string.IsNullOrEmpty(this.Nombre) && !string.IsNullOrEmpty(this.Apellido))
            {
                this.Paciente = String.Format("{0}, {1}", this.Apellido, this.Nombre);
            }
        }

        private void SetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.FecNacimiento.Year;
            if (this.FecNacimiento > today.AddYears(-age)) age--;
            this.Edad = age;
        }
    }
}
