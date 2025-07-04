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
        robotState.IsPlaced = false;
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
    public string RunCommands(string requestCommand)
    {
        List<string>? list = null;
        string result = "No commands to execute.";

        if (string.IsNullOrWhiteSpace(requestCommand))
            return result;

        list = requestCommand.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int index = 0; index < list.Count; index++)
        {
            string command = list[index].Trim().ToUpper();

            switch (command)
            {
                case "PLACE":

                    //(Nvn): ++index to get the next item in the list
                    var args = list[++index].Split(',');

                    if (args.Length == 3 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y)
                        && Enum.TryParse(typeof(Directions), args[2], true, out var dir))
                    {
                        Place(x, y, (Directions)dir);

                        if (!robotState.IsPlaced)
                            return Messages.InvalidPosition;
                    }
                    break;
                case "MOVE":
                    MoveForward();
                    break;
                case "LEFT":
                    TurnLeft();
                    break;
                case "RIGHT":
                    TurnRight();
                    break;
                case "REPORT":
                    result = Report();
                    break;
                default:
                    return $"Invalid command: {command}";

            }
        }
        return result;
    }
    //Nvn- main class end
}