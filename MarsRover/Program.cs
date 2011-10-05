using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Rover> Rovers = new HashSet<Rover>();
            String[] Input;

            Console.WriteLine("Please specify the size of the Mars Plateu:");
            Console.WriteLine("The first number is the width, and the second number is the height.");

            Input = Console.ReadLine().Split(' ');
            Surface MySurface = new Surface(new Size(Convert.ToInt32(Input[0]), Convert.ToInt32(Input[1])));

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Please specify the starting position and direction of the rover:");
                Console.WriteLine("The first number is the horizontal coordinate, the second number is the vertical coordinate");
                Console.WriteLine("The third value is a single character representing a Cardinal Point (N, S, E, or W)");
                Console.WriteLine("Please enter a blank line to indicate you have no more rovers to enter.");

                Input = Console.ReadLine().Split(' ');

                try
                {
                    PhysicalObject.Heading Direction = PhysicalObject.Heading.North;
                    switch (Input[2].ToUpper())
                    {
                        case "N":
                            Direction = PhysicalObject.Heading.North;
                            break;
                        case "E":
                            Direction = PhysicalObject.Heading.East;
                            break;
                        case "S":
                            Direction = PhysicalObject.Heading.South;
                            break;
                        case "W":
                            Direction = PhysicalObject.Heading.West;
                            break;
                    }
                    Rover CurrentRover = new Rover(MySurface, new Point(Convert.ToInt32(Input[0]), Convert.ToInt32(Input[1])), Direction);

                    Console.WriteLine("Please provide a string of directions for the rover to follow.  No spaces are requred.");
                    Console.WriteLine("{ L = Turn Left; R = Turn Right; M = Move 1 unit forward }");

                    String UserInput = Console.ReadLine().Replace(" ", "");

                    foreach (Char character in UserInput.ToUpper())
                    {
                        switch (character)
                        {
                            case 'L':
                                CurrentRover.Rotate(PhysicalObject.Rotation.Left);
                                break;
                            case 'R':
                                CurrentRover.Rotate(PhysicalObject.Rotation.Right);
                                break;
                            case 'M':
                                CurrentRover.Move();
                                break;
                        }
                    }

                    Rovers.Add(CurrentRover);
                }
                catch
                {
                    break;
                }
            }

            Console.WriteLine("These are the resulting location(s) for your rover(s):");

            foreach (Rover TestRover in Rovers)
            {
                String Output = "";
                Output += MySurface.GetPosition(TestRover).X;
                Output += " ";
                Output += MySurface.GetPosition(TestRover).Y;
                Output += " ";

                switch (TestRover.Direction)
                {
                    case PhysicalObject.Heading.North:
                        Output += "N";
                        break;
                    case PhysicalObject.Heading.East:
                        Output += "E";
                        break;
                    case PhysicalObject.Heading.South:
                        Output += "S";
                        break;
                    case PhysicalObject.Heading.West:
                        Output += "W";
                        break;
                }

                Console.WriteLine(Output);
            }

            Console.Read();
        }
    }
}
