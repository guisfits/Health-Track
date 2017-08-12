using System;

namespace guisfits.HealthTrack.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected abstract bool EhValido();
    }
}
