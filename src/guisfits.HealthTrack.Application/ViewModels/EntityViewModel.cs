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
        }
    }
}
