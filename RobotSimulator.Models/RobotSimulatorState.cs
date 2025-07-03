namespace RobotSimulator.Models;
public class RobotSimulatorState
{
    public int X { get; set; }
    public int Y { get; set; }
    public Directions Direction { get; set; }
    public bool IsPlaced { get; set; } = false;
}