using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Specification.Alimento;

namespace guisfits.HealthTrack.Domain.Validation.Alimento
{
    public class AlimentoEstaConsistenteValidation : Validator<Models.Alimento>
    {
        public AlimentoEstaConsistenteValidation()
        {
            var caloriasSpecification = new AlimentoDeveTerCaloriaCompativelSpecification();
            var dataSpecification = new AlimentoNaoDeveTerDataSuperiorAtualSpecification();
            this.Add("caloriasSpecification", new Rule<Models.Alimento>(caloriasSpecification, "Caloria deve ser entre 0 a 1000"));
            this.Add("dataSpecification", new Rule<Models.Alimento>(dataSpecification, "Data e Hora deve ter menor ou igual a data atual"));
        }
    }
}
