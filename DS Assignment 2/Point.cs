namespace TestLibrary
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }

}
