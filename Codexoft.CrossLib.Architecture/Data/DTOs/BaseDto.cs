using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Data.DTOs
{
    public abstract class BaseDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
