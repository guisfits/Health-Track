using DomainValidation.Validation;
using guisfits.HealthTrack.Domain.Specification.PressaoArterial;

namespace guisfits.HealthTrack.Domain.Validation.PressaoArterial
{
    public class PressaoArterialEstaConsistenteValidation : Validator<Models.PressaoArterial>
    {
        public PressaoArterialEstaConsistenteValidation()
        {
            var dataSpecification = new PressaoNaoDeveTerDataSuperiorAtualSpecification();
            var pressaoPositivo = new PressaoDeveTerValoresPositivosSpecification();
            var pressaoPossivel = new PressaoDeveTerValoresPossiveisSpecification();
            this.Add("dataSpecification", new Rule<Models.PressaoArterial>(dataSpecification, "Data e Hora deve ter menor ou igual a data atual"));
            this.Add("pressaoPositivo", new Rule<Models.PressaoArterial>(pressaoPositivo, "Os valores de sistolica e diastolica devem ser positivos"));
            this.Add("pressaoPossivel", new Rule<Models.PressaoArterial>(pressaoPossivel, "Diastolica é o menor valor e Sistolica o maior"));
        }
    }
}
