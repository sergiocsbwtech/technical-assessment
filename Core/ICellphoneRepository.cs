using technical_assessment.Controllers.Inputs;
 
namespace technical_assessment.Core
{
    public interface ICellphoneRepository
    {
        IEnumerable<Cellphone> Get();
        string Set(CellphoneInput cellphoneInput);
    }
}