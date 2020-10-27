using Codexoft.CrossLib.Architecture.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Data.Entities
{
    public class BaseValidation
    {
        public bool IsValid(out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            return Validator.TryValidateObject(this, context, results, validateAllProperties: true);
        }

        public void TryValidate()
        {
            if (!IsValid(out var errors))
            {
                throw new ValidationFailedException(errors);
            }
        }
    }
}
