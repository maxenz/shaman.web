﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class Domicile
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Reference { get; set; }

        public string Description
        {
            get
            {
                return String.Format("{0} {1} {2}{3}", this.Street, this.Height, this.Department, this.Floor);
            }

            set
            {
                value = this.Description;
            }
        }

        public string BetweenStreet1 { get; set; }

        public string BetweenStreet2 { get; set; }

        public string Street { get; set; }

        public long Height { get; set; }

        public string Floor { get; set; }

        public string Department { get; set; }

        public Domicile() { }

        public Domicile(usrDomicilio usrDomicilio)
        {
            this.Latitude = usrDomicilio.dmLatitud;
            this.Longitude = usrDomicilio.dmLongitud;
            this.Reference = usrDomicilio.dmReferencia;
            this.Description = usrDomicilio.Domicilio;
            this.BetweenStreet1 = usrDomicilio.dmEntreCalle1;
            this.BetweenStreet2 = usrDomicilio.dmEntreCalle2;
            this.Street = usrDomicilio.dmCalle;
            this.Height = usrDomicilio.dmAltura;
            this.Floor = usrDomicilio.dmPiso;
            this.Department = usrDomicilio.dmDepto;
        }
    }
}
