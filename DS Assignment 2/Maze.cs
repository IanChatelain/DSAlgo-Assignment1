using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace TestLibrary
{
    public class Maze
    {
        private char[][] charMaze;
        public Point StartingPoint { get; set; }
        public int RowLength { get; set; }
        public int ColumnLength { get; set; }

        public Maze(string fileName)
        {
            this.charMaze = this.ReadMazeFile(fileName);
        }

        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {
            this.StartingPoint = new Point(startingRow, startingColumn);
            this.charMaze = existingMaze;
            this.RowLength = charMaze.Length;
            this.ColumnLength = charMaze[0].Length;

            this.ThrowInvalidStart();
        }

        public char[][] GetMaze()
        {
            return this.charMaze;
        }

        public string PrintMaze()
        {
            string output = "";
            for (int i = 0; i < this.charMaze.Length; i++)
            {
                if (i > 0)
                {
                    output += "\n";

                }

                for (int j = 0; j < this.charMaze[i].Length; j++)
                {
                    output += charMaze[i][j];
                }
            }
            return output;
        }

        public string DepthFirstSearch()
        {
            Stack<Point> stack = new Stack<Point>();

            // Add starting location
            stack.Push(this.StartingPoint);

            // Get location.
            Point location = stack.Top();

            while (stack.Size > 0)
            {
                location = stack.Top();

                if (this.charMaze[location.Row][location.Column] == 'E')
                {
                    break;
                }

                this.charMaze[location.Row][location.Column] = 'V';

                if (this.charMaze[location.Row + 1][location.Column] == ' ')
                {
                    // Move south
                    stack.Push(new Point(location.Row + 1, location.Column));
                }
                else
                {
                    if (this.charMaze[location.Row][location.Column + 1] == ' ')
                    {
                        // Move east
                        stack.Push(new Point(location.Row, location.Column + 1));
                    }
                    else if (this.charMaze[location.Row][location.Column - 1] == ' ')
                    {
                        // Move west
                        stack.Push(new Point(location.Row, location.Column - 1));
                    }
                    else if (this.charMaze[location.Row - 1][location.Column] == ' ')
                    {
                        // Move north
                        stack.Push(new Point(location.Row - 1, location.Column));
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            //Stack<Point> mazePath = new Stack<Point>();

            //while (stack.Size > 0)
            //{
            //    mazePath.Push(stack.Pop());
            //}

            string output = "Path to follow from Start " + this.StartingPoint.ToString() + " to Exit " + stack.Top().ToString() + " - " + stack.Size.ToString() + " steps:\n" + PrintMaze();

            return output;
        }

        public Stack<Point> GetPathToFollow()
        {
            return default;
        }

        // Helper Methods

        private char[][] ReadMazeFile(string fileName)
        {
            char[][] mazeArray;
            int counter = 0;

            try
            {
                StreamReader sr = new StreamReader(fileName);

                // First line.
                int[] dimensions = this.ParseIntsFromString(sr.ReadLine());
                this.RowLength = dimensions[0];
                this.ColumnLength = dimensions[1];

                mazeArray = new char[this.RowLength][];

                // Second line.
                int[] startingCoordinates = this.ParseIntsFromString(sr.ReadLine());
                this.StartingPoint = new Point(startingCoordinates[0], startingCoordinates[1]);

                // Third and remaining lines.
                string mazeLine = sr.ReadLine();

                while (mazeLine != null)
                {
                    mazeArray[counter++] = mazeLine.ToCharArray();
                    mazeLine = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Exception: " + e.Message);
            }

            return mazeArray;
        }

        private int[] ParseIntsFromString(string lineInput)
        {
            int firstInt = int.Parse(lineInput.Split(' ')[0]);
            int secondInt = int.Parse(lineInput.Split(' ')[1]);
            int[] ints = [firstInt, secondInt];

            return ints;
        }

        private bool InvalidStart() => this.charMaze[StartingPoint.Row][StartingPoint.Column] != ' ';

        private void ThrowInvalidStart()
        {
            if (this.InvalidStart()) throw new ApplicationException();
        }
    }
}
