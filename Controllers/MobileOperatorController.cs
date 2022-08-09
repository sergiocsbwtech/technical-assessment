using Microsoft.AspNetCore.Mvc;
using technical_assessment.Core;
using technical_assessment.Controllers.Inputs;

namespace technical_assessment.Controllers;

[ApiController]
[Route("[controller]")]
public class MobileOperatorController : ControllerBase
{
    private readonly ILogger<MobileOperatorController> _logger;
    private IMobileOperatorRepository _mobileOperatorRepository;

    public MobileOperatorController(ILogger<MobileOperatorController> logger, IMobileOperatorRepository mobileOperatorRepository)
    {
        _logger = logger;
        _mobileOperatorRepository = mobileOperatorRepository;
    }

    [HttpGet("get")]
    public IEnumerable<MobileOperator> Get()
    {
        return _mobileOperatorRepository.Get();
    }

    [HttpPost("set")]
    public string Set([FromBody] MobileOperatorInput mobileOperatorInput)
    {
        return _mobileOperatorRepository.Set(mobileOperatorInput);
    }
}
