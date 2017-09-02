using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Specification.Peso;

namespace guisfits.HealthTrack.Domain.Validation.Peso
{
    public class PesoEstaConsistenteValidation : Validator<Models.Peso>
    {
        public PesoEstaConsistenteValidation()
        {
            var pesoSpecification = new PesoDeveSerPositivoSpecification();
            var dataSpecification = new PesoNaoDeveTerDataSuperiorAtualSpecification();
            this.Add("pesoSpecification", new Rule<Models.Peso>(pesoSpecification, "Peso deve ter um valor possível"));
            this.Add("dataSpecification", new Rule<Models.Peso>(dataSpecification, "Data deve ser menor ou igual a data atual"));
        }
    }
}
