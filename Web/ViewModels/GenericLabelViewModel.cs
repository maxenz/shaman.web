using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public abstract class GenericLabelViewModel
    {
        public long Id { get; set; }

        public string Label { get; set; }
    }
}