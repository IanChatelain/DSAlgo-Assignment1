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
            this.charMaze = existingMaze;
        }

        public char[][] GetMaze()
        {
            return this.charMaze;
        }

        public string PrintMaze()
        {
            return default;
        }

        // Private?
        public string DepthFirstSearch()
        {
            return default;
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

                string dimensions = sr.ReadLine();
                int rows = int.Parse(dimensions.Split(' ')[0]);
                int columns = int.Parse(dimensions.Split(' ')[1]);
                this.RowLength = rows;
                this.ColumnLength = columns;
                mazeArray = new char[this.RowLength][];

                string startingCoordinates = sr.ReadLine();
                int x = int.Parse(startingCoordinates.Split(' ')[0]);
                int y = int.Parse(startingCoordinates.Split(' ')[1]);
                this.StartingPoint = new Point(x, y);

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
    }
}
