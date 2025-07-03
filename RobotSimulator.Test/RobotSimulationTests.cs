using RobotSimulator.Models;
using RobotSimulator.Processor.Services;

namespace RobotSimulator.Test;
public class RobotSimulationTests
{
    private readonly RobotSimulatorServices simulatorServices;

    public RobotSimulationTests()
    {
        simulatorServices = new RobotSimulatorServices();
    }

    [Fact]
    public void TestPlaceMoveForwardReport()
    {
        simulatorServices.Place(0, 0, Utilities.NorthDirection);
        simulatorServices.MoveForward();
        var result = simulatorServices.Report();
        Assert.Equal("Output: 0,1,NORTH", result);
    }

    [Fact]
    public void TestPlaceLeftReport()
    {
        simulatorServices.Place(0, 0, Utilities.NorthDirection);
        simulatorServices.TurnLeft();
        var result = simulatorServices.Report();
        Assert.Equal("Output: 0,0,WEST", result);
    }

    [Fact]
    public void TestPlaceMoveForward2TurnLeft1MoveForward1Report()
    {
        simulatorServices.Place(1, 2, Utilities.EastDirection);
        simulatorServices.MoveForward();
        simulatorServices.MoveForward();
        simulatorServices.TurnLeft();  // Ensure Left() is implemented
        simulatorServices.MoveForward();
        var result = simulatorServices.Report();
        Assert.Equal("Output: 3,3,NORTH", result);
    }    
}