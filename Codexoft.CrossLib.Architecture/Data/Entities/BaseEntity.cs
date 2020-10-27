using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Codexoft.CrossLib.Architecture.Exceptions;

namespace Codexoft.CrossLib.Architecture.Data.Entities
{
    public abstract class BaseEntity : BaseValidation
    {
        [Key]
        public string Id { get; private set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsNew => Id == default;

        public void TrackEntityState()
        {
            if (IsNew)
            {
                Id = Guid.NewGuid().ToString();
                CreatedAt = DateTime.Now;
                UpdatedAt = DateTime.Now;
            }
            else
            {
                UpdatedAt = DateTime.Now;
            }
        }

        public void TrackAndValidate()
        {
            TrackEntityState();
            TryValidate();
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}
