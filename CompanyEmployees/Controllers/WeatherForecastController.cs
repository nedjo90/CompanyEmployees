using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers;

[Route("[controller]")]
[ApiController]
public class WeatherForeCastController : ControllerBase
{
    private ILoggerManager _logger;

    public WeatherForeCastController(ILoggerManager logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("Here is info message from our values controller.");
        _logger.LogDebug("Here is debug message from our values controller.");
        _logger.LogWarn("Here is warn message from our values controller.");
        _logger.LogError("Here is error message from our values controller.");
        
        return new [] { "value1", "value2" };
    }
}