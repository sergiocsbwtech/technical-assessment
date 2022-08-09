using Microsoft.AspNetCore.Mvc;
using technical_assessment.Core;

namespace technical_assessment.Controllers;

[ApiController]
[Route("[controller]")]
public class OtherController : ControllerBase
{
    private readonly ILogger<OtherController> _logger;
    private IDatabaseRepository _databaseRepository;

    public OtherController(ILogger<OtherController> logger, IDatabaseRepository databaseRepository)
    {
        _logger = logger;
        _databaseRepository = databaseRepository;
    }

    [HttpGet(Name = "GetOther")]
    public Task<string> Get()
    {
        return _databaseRepository.Setup();
    }
}
