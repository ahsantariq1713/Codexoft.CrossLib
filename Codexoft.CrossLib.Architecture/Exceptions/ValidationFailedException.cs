using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailedException(ICollection<ValidationResult> errors)
        {
            ValidationErrors = errors;
        }

        public ICollection<ValidationResult> ValidationErrors { get; }
    }
}
