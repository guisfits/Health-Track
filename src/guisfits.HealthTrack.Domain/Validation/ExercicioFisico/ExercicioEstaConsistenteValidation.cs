using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Specification.ExercicioFisico;

namespace guisfits.HealthTrack.Domain.Validation.ExercicioFisico
{
    public class ExercicioEstaConsistenteValidation : Validator<Models.ExercicioFisico>
    {
        public ExercicioEstaConsistenteValidation()
        {
            var caloriasSpecification = new ExercucioDeveTerCaloriaCompativelSpecification();
            var dataSpecification = new ExercicioNaoDeveTerDataSuperiorAtualSpecification();
            this.Add("caloriasSpecification", new Rule<Models.ExercicioFisico>(caloriasSpecification, "Caloria deve ter um valor possível"));
            this.Add("dataSpecification", new Rule<Models.ExercicioFisico>(dataSpecification, "Data e Hora deve ser menor ou igual a data atual"));
        }
    }
}
