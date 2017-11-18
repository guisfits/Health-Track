using FluentValidation.Results;

namespace HealthTrack.Domain.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public abstract ValidationResult Validar();
    }
}
