using NUnit.Framework;

[TestFixture]
public class RobotNavigatorTests
{
    [Test]
    public void TestSampleScenarioOne()
    {
        Grid grid = new Grid(5, 3);
        Position startingPosition = new Position(1, 1, Orientation.East);
        Robot robot = new Robot(startingPosition);
        string instructions = "RFRFRFRF";
        RobotNavigator navigator = new RobotNavigator();
        
        navigator.Navigate(grid, robot, instructions);
        
        Assert.That(robot.CurrentPosition.X, Is.EqualTo(1));
        Assert.That(robot.CurrentPosition.Y, Is.EqualTo(1));
        Assert.That(robot.CurrentPosition.Orientation, Is.EqualTo(Orientation.East));
        Assert.That(grid.LostPositions, Is.Empty);
    }
    
    [Test]
    public void TestSampleScenarioTwo()
    {
        Grid grid = new Grid(5, 3);
        Position startingPosition = new Position(3, 2, Orientation.North);
        Robot robot = new Robot(startingPosition);
        string instructions = "FRRFLLFFRRFLL";
        RobotNavigator navigator = new RobotNavigator();
        
        navigator.Navigate(grid, robot, instructions);
        
        Assert.That(robot.CurrentPosition.X, Is.EqualTo(3));
        Assert.That(robot.CurrentPosition.Y, Is.EqualTo(3));
        Assert.That(robot.CurrentPosition.Orientation, Is.EqualTo(Orientation.North));
        Assert.That(grid.LostPositions.Count, Is.EqualTo(1));
        Assert.That(grid.LostPositions[0].X, Is.EqualTo(3));    
        Assert.That(grid.LostPositions[0].Y, Is.EqualTo(3));    
        Assert.That(grid.LostPositions[0].Orientation, Is.EqualTo(Orientation.North));
    }
    
    // All three robots
    [Test]
    public void TestSampleScenarioThree()
    {
        Grid grid = new Grid(5, 3);
        RobotNavigator navigator = new RobotNavigator();
        
        // Robot One
        Position robotOneStartingPosition = new Position(1, 1, Orientation.East);
        Robot robotOne = new Robot(robotOneStartingPosition);
        string robotOneInstructions = "RFRFRFRF";
        
        navigator.Navigate(grid, robotOne, robotOneInstructions);
        
        // Robot Two
        Position robotTwoStartingPosition = new Position(3, 2, Orientation.North);
        Robot robotTwo = new Robot(robotTwoStartingPosition);
        string robotTwoInstructions = "FRRFLLFFRRFLL";
        
        navigator.Navigate(grid, robotTwo, robotTwoInstructions);
        
        // Robot Three
        Position robotThreeStartingPosition = new Position(0, 3, Orientation.West);
        Robot robotThree = new Robot(robotThreeStartingPosition);
        string robotThreeInstructions = "LLFFFLFLFL";
        
        navigator.Navigate(grid, robotThree, robotThreeInstructions);
        
        Assert.That(robotOne.CurrentPosition.X, Is.EqualTo(1));
        Assert.That(robotOne.CurrentPosition.Y, Is.EqualTo(1));
        Assert.That(robotOne.CurrentPosition.Orientation, Is.EqualTo(Orientation.East));
        
        Assert.That(robotTwo.CurrentPosition.X, Is.EqualTo(3));
        Assert.That(robotTwo.CurrentPosition.Y, Is.EqualTo(3));
        Assert.That(robotTwo.CurrentPosition.Orientation, Is.EqualTo(Orientation.North));
        
        Assert.That(grid.LostPositions.Count, Is.EqualTo(1));
        Assert.That(grid.LostPositions[0].X, Is.EqualTo(3));    
        Assert.That(grid.LostPositions[0].Y, Is.EqualTo(3));    
        Assert.That(grid.LostPositions[0].Orientation, Is.EqualTo(Orientation.North));
        
        Assert.That(robotThree.CurrentPosition.X, Is.EqualTo(2));
        Assert.That(robotThree.CurrentPosition.Y, Is.EqualTo(3));
        Assert.That(robotThree.CurrentPosition.Orientation, Is.EqualTo(Orientation.South));
    }
}