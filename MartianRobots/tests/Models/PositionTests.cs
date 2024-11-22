using MartianRobots.Enums;
using MartianRobots.Models;
using NUnit.Framework;

namespace MartianRobots.tests.Models;

[TestFixture]
public class PositionTests
{
    [Test]
    public void TestValidPositionConstruction()
    {
        const int startingX = 5;
        const int startingY = 5;
        const Orientation startingOrientation = Orientation.North;
        Position position = new Position(startingX, startingY, startingOrientation);
        Assert.That(position.X, Is.EqualTo(startingX));
        Assert.That(position.Y, Is.EqualTo(startingY));
        Assert.That(position.Orientation, Is.EqualTo(startingOrientation));
    }

    [Test]
    public void TestLeftTurnFromNorth()
    {
        Position position = new Position(5, 5, Orientation.North);
        Position newPosition = position.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
    [Test]
    public void TestLeftTurnFromSouth()
    {
        Position position = new Position(5, 5, Orientation.South);
        Position newPosition = position.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.East));
    }
    
    [Test]
    public void TestLeftTurnFromEast()
    {
        Position position = new Position(5, 5, Orientation.East);
        Position newPosition = position.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.North));
    }
    
    [Test]
    public void TestLeftTurnFromWest()
    {
        Position position = new Position(5, 5, Orientation.West);
        Position newPosition = position.Turn('L');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.South));
    }
    
    [Test]
    public void TestRightTurnFromNorth()
    {
        Position position = new Position(5, 5, Orientation.North);
        Position newPosition = position.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.East));
    }
    
    [Test]
    public void TestRightTurnFromSouth()
    {
        Position position = new Position(5, 5, Orientation.South);
        Position newPosition = position.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
    [Test]
    public void TestRightTurnFromEast()
    {
        Position position = new Position(5, 5, Orientation.East);
        Position newPosition = position.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.South));
    }
    
    [Test]
    public void TestRightTurnFromWest()
    {
        Position position = new Position(5, 5, Orientation.West);
        Position newPosition = position.Turn('R');
        Assert.That(newPosition.X, Is.EqualTo(5));
        Assert.That(newPosition.Y, Is.EqualTo(5));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.North));
    }

    [Test]
    public void TestInvalidTurnInstruction()
    {
        Position position = new Position(5, 5, Orientation.North);
        Assert.Throws<ArgumentException>(() => position.Turn('P'));
    }

    [Test]
    public void TestMoveForwardFacingNorth()
    {
        const int startingX = 5;
        const int startingY = 5;
        Position position = new Position(startingX, startingY, Orientation.North);
        Position newPosition = position.MoveForward();
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
        Position newPosition = position.MoveForward();
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
        Position newPosition = position.MoveForward();
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
        Position newPosition = position.MoveForward();
        Assert.That(newPosition.X, Is.EqualTo(startingX - 1));
        Assert.That(newPosition.Y, Is.EqualTo(startingY));
        Assert.That(newPosition.Orientation, Is.EqualTo(Orientation.West));
    }
    
}