using technical_assessment.Controllers.Inputs;

namespace technical_assessment.Core
{
    public interface IMobileOperatorRepository
    {
        IEnumerable<MobileOperator> Get();
        string Set(MobileOperatorInput mobileOperatorInput);
    }
}