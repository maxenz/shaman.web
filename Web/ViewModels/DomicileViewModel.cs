using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class DomicileViewModel
    {
        public string BetweenFirstStreet { get; set; }
        public string BetweenSecondStreet { get; set; }
        public string Department { get; set; }
        public string Floor { get; set; }
        public int Height { get; set; }
        public string Street { get; set; }

        public string Reference { get; set; }

        public Domicile ConvertViewModelToDomicile()
        {
            Domicile dom = new Domicile();
            dom.BetweenStreet1 = this.BetweenFirstStreet;
            dom.BetweenStreet2 = this.BetweenSecondStreet;
            dom.Department = this.Department;
            dom.Floor = this.Floor;
            dom.Height = this.Height;
            dom.Street = this.Street;
            dom.Reference = this.Reference;

            return dom;
        }

        public string GetDomicileDescription()
        {
            string value = string.Format("{0} {1} ", this.Street, this.Height);
            if (!string.IsNullOrEmpty(Department))
            {
                value += " Departamento: " + this.Department;
            }

            if (!string.IsNullOrEmpty(Floor))
            {
                value += " Piso: " + this.Floor;
            }

            return value;
        }
    }
}