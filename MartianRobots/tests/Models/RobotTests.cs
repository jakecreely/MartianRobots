using NUnit.Framework;

namespace MartianRobots.tests.Models;

[TestFixture]
public class RobotTests
{
    [Test]
    public void TestValidRobotConstruction()
    {
        const int startingX = 5;
        const int startingY = 5;
        const Orientation startingOrientation = Orientation.North;
        Position position = new Position(startingX, startingY, startingOrientation);
        Robot robot = new Robot(position);
        Assert.That(robot.CurrentPosition.X, Is.EqualTo(startingX));
        Assert.That(robot.CurrentPosition.Y, Is.EqualTo(startingY));
        Assert.That(robot.CurrentPosition.Orientation, Is.EqualTo(startingOrientation));
    }

    [Test]
    public void TestLeftTurnFromNorth()
    {
        Position position = new Position(5, 5, Orientation.North);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
    [Test]
    public void TestLeftTurnFromSouth()
    {
        Position position = new Position(5, 5, Orientation.South);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.East));
    }
    
    [Test]
    public void TestLeftTurnFromEast()
    {
        Position position = new Position(5, 5, Orientation.East);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.North));
    }
    
    [Test]
    public void TestLeftTurnFromWest()
    {
        Position position = new Position(5, 5, Orientation.West);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.South));
    }
    
    [Test]
    public void TestRightTurnFromNorth()
    {
        Position position = new Position(5, 5, Orientation.North);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.East));
    }
    
    [Test]
    public void TestRightTurnFromSouth()
    {
        Position position = new Position(5, 5, Orientation.South);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
    [Test]
    public void TestRightTurnFromEast()
    {
        Position position = new Position(5, 5, Orientation.East);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.South));
    }
    
    [Test]
    public void TestRightTurnFromWest()
    {
        Position position = new Position(5, 5, Orientation.West);
        Robot robot = new Robot(position);
        Position newPosition = robot.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.North));
    }

    [Test]
    public void TestInvalidTurnInstruction()
    {
        Position position = new Position(5, 5, Orientation.North);
        Robot robot = new Robot(position);
        Assert.Throws<ArgumentException>(() => robot.Turn('P'));
    }

    [Test]
    public void TestMoveForwardFacingNorth()
    {
        const int startingX = 5;
        const int startingY = 5;
        Position position = new Position(startingX, startingY, Orientation.North);
        Robot robot = new Robot(position);
        Position newPosition = robot.MoveForward();
        Assert.That(newPosition.X, Is.EqualTo(startingX));
        Assert.That(newPosition.Y, Is.EqualTo(startingY + 1));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.North));
    }
    
    [Test]
    public void TestMoveForwardFacingSouth()
    {
        const int startingX = 5;
        const int startingY = 5;
        Position position = new Position(startingX, startingY, Orientation.South);
        Robot robot = new Robot(position);
        Position newPosition = robot.MoveForward();
        Assert.That(newPosition.X, Is.EqualTo(startingX));
        Assert.That(newPosition.Y, Is.EqualTo(startingY - 1));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.South));
    }
    
    [Test]
    public void TestMoveForwardFacingEast()
    {
        const int startingX = 5;
        const int startingY = 5;
        Position position = new Position(startingX, startingY, Orientation.East);
        Robot robot = new Robot(position);
        Position newPosition = robot.MoveForward();
        Assert.That(newPosition.X, Is.EqualTo(startingX + 1));
        Assert.That(newPosition.Y, Is.EqualTo(startingY));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.East));
    }
    
    [Test]
    public void TestMoveForwardFacingWest()
    {
        const int startingX = 5;
        const int startingY = 5;
        Position position = new Position(startingX, startingY, Orientation.West);
        Robot robot = new Robot(position);
        Position newPosition = robot.MoveForward();
        Assert.That(newPosition.X, Is.EqualTo(startingX - 1));
        Assert.That(newPosition.Y, Is.EqualTo(startingY));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
}