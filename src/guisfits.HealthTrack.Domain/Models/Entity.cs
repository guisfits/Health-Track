using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public abstract class Entity
    {
        protected Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
