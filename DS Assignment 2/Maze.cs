namespace TestLibrary
{
    public class Maze
    {
        private char[][] charMaze;
        public Point StartingPoint { get; set; }
        public int RowLength { get; set; }
        public int ColumnLength { get; set; }
        private Stack<Point> stack = new Stack<Point>();
        private Stack<Point> reversedCopy = new Stack<Point>();
        private bool exitFound = false;
        private bool searchComplete = false;

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

            // Get current location
            Point location = stack.Top();

            while (stack.Size > 0)
            {
                location = stack.Top();

                // Exit found
                if (this.charMaze[location.Row][location.Column] == 'E')
                {
                    exitFound = true;
                    break;
                }

                // Path
                this.charMaze[location.Row][location.Column] = '.';

                if (this.charMaze[location.Row + 1][location.Column] == ' ' || this.charMaze[location.Row + 1][location.Column] == 'E')
                {
                    // Move south
                    stack.Push(new Point(location.Row + 1, location.Column));
                }
                else
                {
                    if (this.charMaze[location.Row][location.Column + 1] == ' ' || this.charMaze[location.Row][location.Column + 1] == 'E')
                    {
                        // Move east
                        stack.Push(new Point(location.Row, location.Column + 1));
                    }
                    else if (this.charMaze[location.Row][location.Column - 1] == ' ' || this.charMaze[location.Row][location.Column - 1] == 'E')
                    {
                        // Move west
                        stack.Push(new Point(location.Row, location.Column - 1));
                    }
                    else if (this.charMaze[location.Row - 1][location.Column] == ' ' || this.charMaze[location.Row - 1][location.Column] == ' ')
                    {
                        // Move north
                        stack.Push(new Point(location.Row - 1, location.Column));
                    }
                    else
                    {
                        // Visited
                        this.charMaze[location.Row][location.Column] = 'V';

                        // Backtrack
                        stack.Pop();
                    }
                }
            }

            string outputComment = "No exit found in maze!\n\n";
            string outputMaze = PrintMaze();
            string steps = "";

            if (exitFound)
            {
                outputComment = string.Format("Path to follow from Start {0} to Exit {1} - {2} steps:\n", this.StartingPoint.ToString(), stack.Top(), stack.Size.ToString());
            }

            while (stack.Size > 0)
            {
                Point p = stack.Pop();
                this.stack.Push(p);
                this.reversedCopy.Push(p);
            }

            while (this.reversedCopy.Size > 0)
            {
                steps += string.Format("{0}\n", this.reversedCopy.Pop());
            }

            this.searchComplete = true;

            return outputComment + steps + outputMaze;
        }

        public Stack<Point> GetPathToFollow()
        {
            ThrowInvalidPath(this.stack);
            ThrowSearchNotComplete();

            Stack<Point> stackCopy = new Stack<Point>();

            while (this.stack.Size > 0)
            {
                Point p = this.stack.Pop();
                stackCopy.Push(p);
            }

            return GetReverseStackCopy(stackCopy);
        }

        // Helper Methods

        private Stack<Point> GetReverseStackCopy(Stack<Point> stack)
        {
            Stack<Point> reversedStack = new Stack<Point>();

            while (stack.Size > 0)
            {
                Point p = stack.Pop();
                this.reversedCopy.Push(p);
                reversedStack.Push(p);
            }

            while (this.reversedCopy.Size > 0)
            {
                this.stack.Push(this.reversedCopy.Pop());
            }

            return reversedStack;
        }

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

        private void ThrowInvalidStart()
        {
            if (this.charMaze[StartingPoint.Row][StartingPoint.Column] != ' ') throw new ApplicationException();
        }

        private void ThrowInvalidPath(Stack<Point> stack)
        {
            if (exitFound && stack == null)
            {
                throw new ApplicationException();
            }
        }

        private void ThrowSearchNotComplete()
        {
            if (!this.searchComplete)
            {
                throw new ApplicationException();
            }
        }
    }
}
