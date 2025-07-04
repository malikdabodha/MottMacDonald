using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Processor.Interfaces;
public interface IRobotSimulator
{
    string Place(int x, int y, Directions direction);
    string MoveForward();
    string TurnLeft();
    string TurnRight();
    string Report();
    string RunCommands(string commandBatch);
}