namespace TestLibrary
{
    /// <summary>
    /// Represents a maze and provides functionality for maze navigation using Depth-First Search.
    /// </summary>
    public class Maze
    {
        private char[][] charMaze;
        public Point StartingPoint { get; set; }
        public int RowLength { get; set; }
        public int ColumnLength { get; set; }
        private Stack<Point> stack = new Stack<Point>();
        private bool exitFound = false;
        private bool searchComplete = false;

        /// <summary>
        /// Initializes a new instance of the Maze class by reading maze details from a file.
        /// </summary>
        /// <param name="fileName">The name of the file containing the maze data.</param>
        public Maze(string fileName)
        {
            this.charMaze = this.ReadMazeFile(fileName);
        }

        /// <summary>
        /// Initializes a new instance of the Maze class with a specified starting point and existing maze structure.
        /// </summary>
        /// <param name="startingRow">The row index of the starting point.</param>
        /// <param name="startingColumn">The column index of the starting point.</param>
        /// <param name="existingMaze">The 2D character array representing the maze.</param>
        /// <exception cref="ApplicationException">Thrown if start point is invalid.</exception>
        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {
            this.StartingPoint = new Point(startingRow, startingColumn);
            this.charMaze = existingMaze;
            this.RowLength = charMaze.Length;
            this.ColumnLength = charMaze[0].Length;

            this.ThrowInvalidStart();
        }

        /// <summary>
        /// Retrieves the maze structure.
        /// </summary>
        /// <returns>A 2D array of characters representing the maze.</returns>
        public char[][] GetMaze()
        {
            return this.charMaze;
        }

        /// <summary>
        /// Generates a string representation of the maze for display.
        /// </summary>
        /// <returns>A string containing the visual representation of the maze.</returns>
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

        /// <summary>
        /// Executes the Depth-First Search algorithm to find a path through the maze.
        /// </summary>
        /// <returns>A string detailing the path found, or a message indicating no exit was found, and the maze.</returns>
        public string DepthFirstSearch()
        {
            this.stack.Clear();

            // Add starting location
            this.stack.Push(this.StartingPoint);

            // Get current location
            Point location;

            // Execute search
            while (this.stack.Size > 0)
            {
                location = this.stack.Top();

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
                    // South
                    this.stack.Push(new Point(location.Row + 1, location.Column));
                }
                else
                {
                    if (this.charMaze[location.Row][location.Column + 1] == ' ' || this.charMaze[location.Row][location.Column + 1] == 'E')
                    {
                        // East
                        this.stack.Push(new Point(location.Row, location.Column + 1));
                    }
                    else if (this.charMaze[location.Row][location.Column - 1] == ' ' || this.charMaze[location.Row][location.Column - 1] == 'E')
                    {
                        // West
                        this.stack.Push(new Point(location.Row, location.Column - 1));
                    }
                    else if (this.charMaze[location.Row - 1][location.Column] == ' ' || this.charMaze[location.Row - 1][location.Column] == ' ')
                    {
                        // North
                        this.stack.Push(new Point(location.Row - 1, location.Column));
                    }
                    else
                    {
                        // Visited
                        this.charMaze[location.Row][location.Column] = 'V';

                        // Backtrack
                        this.stack.Pop();
                    }
                }
            }

            this.searchComplete = true;

            // Reverse stack for output
            Stack<Point> pathStack = GetPathToFollow();
            string outputComment = "No exit found in maze!\n\n";
            string outputMaze = PrintMaze();
            string path = "";

            if (exitFound)
            {
                outputComment = string.Format("Path to follow from Start {0} to Exit {1} - {2} steps:\n", this.StartingPoint.ToString(), this.stack.Top(), this.stack.Size.ToString());
            }

            while (pathStack.Size > 0)
            {
                path += string.Format("{0}\n", pathStack.Pop());
            }

            return outputComment + path + outputMaze;
        }

        /// <summary>
        /// Retrieves the path found by the Depth-First Search as a stack of points.
        /// </summary>
        /// <returns>A stack of points representing the path from start to exit.</returns>
        /// <exception cref="ApplicationException">Thrown if path is invalid, or search was not completed.</exception>
        public Stack<Point> GetPathToFollow()
        {
            ThrowInvalidPath(this.stack);
            ThrowSearchNotComplete();

            return GetReverseStackCopy(this.stack);
        }

        // Helper Methods

        /// <summary>
        /// Creates a copy of a given stack.
        /// </summary>
        /// <param name="stack">The stack to copy.</param>
        /// <returns>A new stack containing all the elements of the original stack in the same order.</returns>
        private Stack<Point> GetStackCopy(Stack<Point> stack)
        {
            Stack<Point> tempStack1 = new Stack<Point>();
            Stack<Point> tempStack2 = new Stack<Point>();

            while (stack.Size > 0)
            {
                Point p = stack.Pop();
                tempStack1.Push(p);
            }

            while (tempStack1.Size > 0)
            {
                Point p = tempStack1.Pop();
                tempStack2.Push(p);
                stack.Push(p);
            }

            return tempStack2;
        }

        /// <summary>
        /// Creates a reversed copy of a given stack.
        /// </summary>
        /// <param name="stack">The stack to reverse and copy.</param>
        /// <returns>A new stack containing all the elements of the original stack in reverse order.</returns>
        private Stack<Point> GetReverseStackCopy(Stack<Point> stack)
        {
            Stack<Point> tempStack1 = new Stack<Point>();
            Stack<Point> tempStack2 = new Stack<Point>();

            while (stack.Size > 0)
            {
                Point p = stack.Pop();
                tempStack1.Push(p);
                tempStack2.Push(p);
            }

            while (tempStack1.Size > 0)
            {
                Point p = tempStack1.Pop();
                stack.Push(p);
            }

            return tempStack2;
        }

        /// <summary>
        /// Reads the maze structure from a file.
        /// </summary>
        /// <param name="fileName">The file path of the maze data.</param>
        /// <returns>A 2D character array representing the maze.</returns>
        /// <exception cref="ApplicationException">Thrown if there was a problem reading the file, or parsing the file contents.</exception>
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

        /// <summary>
        /// Parses a string containing two integers separated by a space.
        /// </summary>
        /// <param name="lineInput">The input string to parse.</param>
        /// <returns>An array of two integers parsed from the input string.</returns>
        private int[] ParseIntsFromString(string lineInput)
        {
            int firstInt = int.Parse(lineInput.Split(' ')[0]);
            int secondInt = int.Parse(lineInput.Split(' ')[1]);
            int[] ints = [firstInt, secondInt];

            return ints;
        }

        /// <summary>
        /// Validates the starting position within the maze to ensure it's an open space.
        /// </summary>
        /// <exception cref="ApplicationException">Thrown if the starting position is invalid.</exception>
        private void ThrowInvalidStart()
        {
            if (this.charMaze[StartingPoint.Row][StartingPoint.Column] != ' ') throw new ApplicationException();
        }

        /// <summary>
        /// Validates the existence of a path in the maze.
        /// </summary>
        /// <param name="stack">The stack representing the path.</param>
        /// <exception cref="ApplicationException">Thrown if no valid path exists.</exception>
        private void ThrowInvalidPath(Stack<Point> stack)
        {
            if (exitFound && stack.IsEmpty())
            {
                throw new ApplicationException();
            }
        }

        /// <summary>
        /// Ensures that the Depth-First Search has been completed before attempting to retrieve the path.
        /// </summary>
        /// <exception cref="ApplicationException">Thrown if the search is not complete.</exception>
        private void ThrowSearchNotComplete()
        {
            if (!this.searchComplete)
            {
                throw new ApplicationException();
            }
        }
    }
}
