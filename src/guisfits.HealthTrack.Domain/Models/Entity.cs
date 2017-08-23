using System;
using DomainValidation.Validation;

namespace guisfits.HealthTrack.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();
    }
}
