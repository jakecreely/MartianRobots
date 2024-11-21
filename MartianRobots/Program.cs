// See https://aka.ms/new-console-template for more information

using System.Text;

try
{
    // Read and validate Grid input
    string? gridInput = Console.ReadLine();
    if (String.IsNullOrEmpty(gridInput))
    {
        throw new ArgumentException("Grid input cannot be left empty");
    }
    
    string[] gridCoordinates = gridInput.Split();
    if (gridCoordinates.Length != 2)
    {
        throw new ArgumentException("Grid coordinates must be two numbers");
    }
    
    int width = int.Parse(gridCoordinates[0]);
    int height = int.Parse(gridCoordinates[1]);
    
    // Create the grid
    Grid grid = new Grid(width, height);
    
    StringBuilder output = new StringBuilder();
    RobotNavigator navigator = new RobotNavigator();

    // Loops until user decides to stop adding robots
    while (true)
    {
        // Read and validate starting position
        string? positionInput = Console.ReadLine();
        if (String.IsNullOrEmpty(positionInput))
        {
            // Exit from loop and start navigation
            break;
        }
        
        string[] seperatedPosition = positionInput.Split();

        if (seperatedPosition.Length != 3)
        {
            throw new ArgumentException("Seperated position must be 2 numbers (X, Y) and an orientation (N, S, E, W)");
        }
        
        int x = int.Parse(seperatedPosition[0]);
        int y = int.Parse(seperatedPosition[1]);
        char direction = char.Parse(seperatedPosition[2]);
        Orientation orientation = direction switch
        {
            'N' => Orientation.North,
            'S' => Orientation.South,
            'E' => Orientation.East,
            'W' => Orientation.West,
            _ => throw new ArgumentException("Invalid direction. Must be N, S, E or W.")
        };
        Position position = new Position(x, y, orientation);
        
        Robot robot = new Robot(position);
        
        string? instructionInput = Console.ReadLine();
        if (String.IsNullOrEmpty(instructionInput))
        {
            throw new ArgumentException("Instructions cannot be left empty");
        }

        if (instructionInput.Length > 100)
        {
            throw new ArgumentException("Instructions cannot be longer than 100 characters");
        }
        
        var result = navigator.Navigate(grid, robot, instructionInput);
        
        // Output
        output.Append(result.finalPosition.ToString());
        output.Append(result.isLost ? " LOST " : "");
        output.AppendLine();

        Console.WriteLine();
    }
    
    Console.Write(output);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error occurred: {ex.Message}");
}