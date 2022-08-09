using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace technical_assessment.Core
{
    public interface IDatabaseRepository
    {
        Task<string> Setup();
    }
}