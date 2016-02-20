using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DatabaseValidationResult
    {
        public List<string> ValidationMessages { get; set; }

        public bool IsValid { get; set; }
    }
}
