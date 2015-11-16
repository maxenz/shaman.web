using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman
{
    public class OperativeContainerViewModel
    {

        public List<ChartQuantity> ChartQuantities { get; set; }

        public List<ChartTimes> ChartTimes { get; set; }

        public List<string> QuantityChartDescriptions
        {
            get
            {
                return this.ChartQuantities.Select(x => x.Descripcion).ToList();
            }
        }

        public List<int> QuantityChartQuantities
        {
            get
            {
                return this.ChartQuantities.Select(x => x.Cantidad).ToList();
            }
        }

        public List<string> TimeChartDescriptions
        {
            get
            {
                return this.ChartTimes.Select(x => x.Descripcion).ToList();
            }
        }

        public List<List<int>> TimeChartValues
        {
            get
            {
                List<List<int>> lst = new List<List<int>>();
                foreach (var time in this.ChartTimes)
                {
                    lst.Add(new List<int> { time.Atencion, time.Despacho, time.Desplazamiento, time.Salida });
                }

                return lst;
            }
        }

    }
}