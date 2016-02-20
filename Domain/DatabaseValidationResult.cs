using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DatabaseValidationResult
    {
        public string ErrorMessages { get; set; }

        public bool IsValid { get; set; }

        public object Result { get; set; }

        public DatabaseValidationResult() { }

        public DatabaseValidationResult(string errorMessages, bool isValid)
        {
            this.ErrorMessages = errorMessages;
            this.IsValid = isValid;
        }

    }
}
