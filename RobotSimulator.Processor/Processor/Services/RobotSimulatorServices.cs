using RobotSimulator.Models;
using RobotSimulator.Processor.Interfaces;
using RobotSimulator.Processor.Utilities;

namespace RobotSimulator.Processor.Services;
public class RobotSimulatorServices : IRobotSimulator
{
    private readonly int max = 5;
    public RobotSimulatorState robotState { get; set; } = new();
    public string Place(int x, int y, Directions direction)
    {
        if (x >= 0 && x < max && y >= 0 && y < max)
        {
            robotState.X = x;
            robotState.Y = y;
            robotState.Direction = direction;
            robotState.IsPlaced = true;
            return Messages.RobotPlaced;
        }

        return Messages.InvalidPosition;
    }
    public string MoveForward()
    {
        if (!robotState.IsPlaced)
            return Messages.RobotNotPlaced;

        int newX = robotState.X;
        int newY = robotState.Y;

        switch (robotState.Direction)
        {
            case Directions.NORTH:
                newY++;
                break;
            case Directions.SOUTH:
                newY--;
                break;
            case Directions.EAST:
                newX++;
                break;
            case Directions.WEST:
                newX--;
                break;
        }

        if (newX >= 0 && newX < max && newY >= 0 && newY < max)
        {
            robotState.X = newX;
            robotState.Y = newY;
            return Messages.Moved;
        }

        return Messages.MoveWouldFall;
    }
    public string TurnLeft()
    {
        if (!robotState.IsPlaced)
            return Messages.RobotNotPlaced;

        robotState.Direction = (Directions)(((int)robotState.Direction + 3) % 4);
        return Messages.TurnedLeft;
    }
    public string TurnRight()
    {
        if (!robotState.IsPlaced)
            return Messages.RobotNotPlaced;

        robotState.Direction = (Directions)(((int)robotState.Direction + 1) % 4);
        return Messages.TurnedRight;
    }
    public string Report()
    {
        if (!robotState.IsPlaced)
            return Messages.RobotNotPlaced;

        return $"Output: {robotState.X},{robotState.Y},{robotState.Direction}";
    }
}