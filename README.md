# Martian Robots
This project simulates the movement of robots on Mars, as part of the Red Badger technical challenge. The robots follow a series of instructions (L, R, F), and the program outputs their final positions, along with whether they went out of bounds and got lost.

## Features
Robots can turn left (L), right (R), and move forward (F).
Robots that move out of bounds are marked as "lost."
The program outputs the final position of each robot, along with the "LOST" status if applicable.

## Prerequisites
Ensure that you have the following installed:

- .NET 8.0 SDK or higher

## Setup and Installation
1. Clone the repository:
```bash
git clone https://github.com/jakecreely/MartianRobots
```

2. Navigate to the project folder:
```bash
cd MartianRobots
```

3. Restore the project dependencies:
```bash
dotnet restore
```

4. Build the project:
```bash
dotnet build
```

5. Test the program is working
```bash
dotnet test
```

## Running the Program
To run the  program:
```
dotnet run
```

### Input
The program expects input in the following format:

The first line should contain two integers representing the dimensions of the grid seperated by whitespace e.g. ```5 3```
The second line represent the robot's starting position (x y orientation), e.g ```3 2 N``` where N represents North
The third line is for the instructions in the form of a string where each char is an instruction. L for turn left, R for turn right and F for move forward. E.g ``` LFRFLLRFF ```

## Reflections
My approach for this project was to get the basic funcitionality of the Grid, Position, Robot and Navigation implemented and then before starting with the console inputs, 
I wrote testing using NUnit to validate this and ensure the functionality was correct. This included using the sample data to simulate a few scenarios. This process allowed me
to find some bugs in my code and ensured any further changes could easy be checked against the intended functionality. 

Overall this task took a bit longer than I hoped and there are a few areas that I don't think quite work as intended for example, when a robot is lost and out of bounds if an instruction tells
to keep moving out of bounds I think it continues moving. Regarding further testing, I would add some more to test edge cases as well as making sure the inputs are varied as at the moment they are
hard coded. 

