using Microsoft.AspNetCore.Mvc;
using RobotSimulator.Models;
using RobotSimulator.Processor.Interfaces;

namespace MottMacDonaldTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RobotSimulatorController : ControllerBase
{
    private readonly IRobotSimulator _robotSimulator;
    public RobotSimulatorController(IRobotSimulator robotSimulator)
    {
        _robotSimulator = robotSimulator;
    }

    [HttpPost("runcommands")]
    public async Task<IActionResult> RunCommands(string requestCommand)
    {
        return await CreateEnvelope(_robotSimulator.RunCommands(requestCommand));
    }
    [HttpPost("place")]
    public async Task<IActionResult> Place(int x, int y, Directions direction)
    {
        return await CreateEnvelope(_robotSimulator.Place(x, y, direction));
    }

    [HttpPost("move")]
    public async Task<IActionResult> MoveForward()
    {
        return await CreateEnvelope(_robotSimulator.MoveForward());
    }

    [HttpPost("turnleft")]
    public async Task<IActionResult> TurnLeft()
    {
        return await CreateEnvelope(_robotSimulator.TurnLeft());
    }

    [HttpPost("turnright")]
    public async Task<IActionResult> TurnRight()
    {
        return await CreateEnvelope(_robotSimulator.TurnRight());
    }

    [HttpGet("report")]
    public async Task<IActionResult> Report()
    {
        return await CreateEnvelope(_robotSimulator.Report());
    }
    private Task<IActionResult> CreateEnvelope(object message)
    {
        var responseEnvelope = new ResponseEnvelope<object>
        {
            ResponseBody = message,
            Flag = false
        };
        return Task.FromResult<IActionResult>(StatusCode(200, responseEnvelope));
    }

    /**/
}