// See https://aka.ms/new-console-template for more information

try
{

// Read the grid input
    string? gridInput = Console.ReadLine();
    if (gridInput == null)
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
    
// Read robot one starting position
// Create robot
// Read instructions
// Add robot and instructions to an array
// Repeat until user stops
// Run navigate on robot in sequential order

}
catch (Exception ex)
{
    Console.Write(ex.ToString());
} 