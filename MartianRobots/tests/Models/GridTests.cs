using NUnit.Framework;

namespace MartianRobots.tests.Models;

[TestFixture]
public class GridTests
{
    [Test]
    public void TestValidGridConstruction()
    {
        int width = 25;
        int height = 30;
        Grid grid = new Grid(width, height);
        Assert.That(grid.Width, Is.EqualTo(width));
        Assert.That(grid.Height, Is.EqualTo(height));
        Assert.That(grid.LostPositions, Is.Empty);
    }
    
    [Test]
    public void TestInvalidGridConstruction()
    {
        int width = 57;
        int height = -4;
        Assert.Throws<ArgumentException>(() => new Grid(width, height));
    }
    
    [Test]
    public void ReturnsTrueIfOutOfBounds()
    {
        int width = 10;
        int height = 5;
        Grid grid = new Grid(width, height);
        Position position = new Position(13, 8, Orientation.North);
        bool result = grid.IsOutOfBounds(position);
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void ReturnsFalseIfWithinOfBounds()
    {
        int width = 10;
        int height = 5;
        Grid grid = new Grid(width, height);
        Position position = new Position(3, 3, Orientation.North);
        bool result = grid.IsOutOfBounds(position);
        Assert.That(result, Is.False);
    }

    [Test]
    public void ReturnsTrueIfAlreadyLostFromPosition()
    {
        int width = 10;
        int height = 5;
        Grid grid = new Grid(width, height);
        Position position = new Position(0, 0, Orientation.West);
        grid.AddLostPosition(position);
        Position newPosition = new Position(0, 0, Orientation.West);
        bool result = grid.HasAlreadyLostFromPosition(newPosition);
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void ReturnsFalseIfNoLostFromPosition()
    {
        int width = 10;
        int height = 5;
        Grid grid = new Grid(width, height);
        Position newPosition = new Position(0, 0, Orientation.West);
        bool result = grid.HasAlreadyLostFromPosition(newPosition);
        Assert.That(result, Is.False);
    }

}