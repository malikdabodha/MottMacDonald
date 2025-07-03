using RobotSimulator.Models;

namespace RobotSimulator.Test;
public class Utilities
{
    public static Directions NorthDirection
    {
        get { return Enum.Parse<Directions>("NORTH"); }
    }
    public static Directions SouthDirection
    {
        get { return Enum.Parse<Directions>("SOUTH"); }
    }
    public static Directions EastDirection
    {
        get { return Enum.Parse<Directions>("EAST"); }
    }
    public static Directions WestDirection
    {
        get { return Enum.Parse<Directions>("WEST"); }
    }
}

