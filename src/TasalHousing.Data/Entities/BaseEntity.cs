using System;

namespace TasalHousing.Data.Entities
{
    
    public abstract class BaseEntity
    {

        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set: }

        public DateTime Modified { get; set; }

        public DateTime DeletedAt { get; set; }

    }
}