using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SchedulerExtender.Controllers;

[ApiController]
[Route("/api/v1/extender")]
public class ExtenderController : ControllerBase
{
    private readonly ILogger<ExtenderController> _logger;

    public ExtenderController(ILogger<ExtenderController> logger)
    {
        _logger = logger;
    }

    //A "filter" of a K8s scheduler extender.
    [HttpPost("filter")]
    public SchedulerFilterResult Filter([FromBody]SchedulerInput input)
    {
        var json = JsonSerializer.Serialize(input, new JsonSerializerOptions() { WriteIndented = true });
        _logger.LogInformation("Filter input: {input}", input);
        return new SchedulerFilterResult() { Nodes = input.Nodes };
    }
}
