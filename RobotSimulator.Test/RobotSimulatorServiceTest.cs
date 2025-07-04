using RobotSimulator.Processor.Interfaces;
using RobotSimulator.Processor.Services;

namespace RobotSimulator.Test;
public class RobotSimulatorServiceTest
{
    private readonly IRobotSimulator simulatorServices;
    public RobotSimulatorServiceTest()
    {
        simulatorServices = new RobotSimulatorServices();
    }

    #region Place Tests
    [Fact]
    public void PlaceValidPosition_North()
    {
        var result = simulatorServices.Place(1, 2, Utilities.NorthDirection);
        Assert.Equal("Robot placed.", result);
    }

    [Fact]
    public void PlaceInvalidPosition_South()
    {
        var result = simulatorServices.Place(7, 5, Utilities.SouthDirection);
        Assert.Equal("Invalid position.", result);
    }

    #endregion

    #region Move Forward Tests
    [Fact]
    public void MoveForward_North()
    {
        simulatorServices.Place(3, 4, Utilities.NorthDirection);
        var moveResult = simulatorServices.MoveForward();
        Assert.Equal("Move would fall off the table.", moveResult);
        Assert.Equal("Output: 3,4,NORTH", simulatorServices.Report());
    }

    [Fact]
    public void MoveBlockedEdge_South()
    {
        simulatorServices.Place(2, 4, Utilities.SouthDirection);
        var moveResult = simulatorServices.MoveForward();
        Assert.Equal("Moved.", moveResult);
    }
    #endregion

    #region Left Tests
    [Fact]
    public void TurnLeft_North()
    {
        simulatorServices.Place(2, 3, Utilities.NorthDirection);
        var turnLeft = simulatorServices.TurnLeft();
        Assert.Equal("Turned left.", turnLeft);
        Assert.Equal("Output: 2,3,WEST", simulatorServices.Report());
    }

    [Fact]
    public void TurnLeft_South()
    {
        simulatorServices.Place(1, 3, Utilities.SouthDirection);
        var turnLeft = simulatorServices.TurnLeft();
        Assert.Equal("Turned left.", turnLeft);
    }
    #endregion

    #region Right Tests
    [Fact]
    public void TurnRight_North()
    {
        simulatorServices.Place(2, 4, Utilities.EastDirection);
        var turnLeft = simulatorServices.TurnRight();
        Assert.Equal("Turned right.", turnLeft);
        Assert.Equal("Output: 2,4,SOUTH", simulatorServices.Report());
    }

    [Fact]
    public void TurnRight_South()
    {
        simulatorServices.Place(1, 2, Utilities.SouthDirection);
        var turnLeft = simulatorServices.TurnRight();
        Assert.Equal("Turned right.", turnLeft);
    }
    #endregion

    #region Run Commands
    [Fact]
    public void RunCommands_Batch()
    {
        string requestCommand = "PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT";
        string result = simulatorServices.RunCommands(requestCommand);
        Assert.Equal("Output: 3,3,NORTH", result);
    }
    #endregion

    #region Report
    [Fact]
    public void Report_NotPlaced()
    {
        var result = simulatorServices.Report();
        Assert.Equal("Robot not placed.", result);
    }
    #endregion
}