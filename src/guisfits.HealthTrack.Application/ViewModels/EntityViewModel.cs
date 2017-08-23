using System;
using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public abstract class EntityViewModel
    {
        [Key]
        public Guid Id { get; set; }

        protected EntityViewModel()
        {
            Id = Guid.NewGuid();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
