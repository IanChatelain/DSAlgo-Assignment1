namespace TestLibrary
{
    /// <summary>
    /// Represents a point.
    /// </summary>
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// Initializes a new instance of the Point class.
        /// </summary>
        /// <param name="row">The row value.</param>
        /// <param name="column">The column value.</param>
        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// Returns a representation of the Point class.
        /// </summary>
        /// <returns>A string that represents the coordinates of a point.</returns>
        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.Row, this.Column);
        }
    }

}
