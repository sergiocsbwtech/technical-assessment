using Microsoft.AspNetCore.Mvc;
using technical_assessment.Core;
using technical_assessment.Controllers.Inputs;

namespace technical_assessment.Controllers;

[ApiController]
[Route("[controller]")]
public class CellphoneController : ControllerBase
{
    private readonly ILogger<CellphoneController> _logger;
    private ICellphoneRepository _cellphoneRepository;

    public CellphoneController(ILogger<CellphoneController> logger, ICellphoneRepository cellphoneRepository)
    {
        _logger = logger;
        _cellphoneRepository = cellphoneRepository;
    }

    [HttpGet("get")]
    public IEnumerable<Cellphone> Get()
    {
        return _cellphoneRepository.Get();
    }

    [HttpPost("set")]
    [Produces("application/json")]
    public string Set([FromBody] CellphoneInput cellphoneInput)
    {
        return _cellphoneRepository.Set(cellphoneInput);
    }
}
