using System;
using System.Linq;

namespace snake_project
{
    internal class OutlineElements : SettingElements
    {
        private enum OutlineDivision
        {
            TopLine,
            BottomLine,
            LeftColumn,
            RightColumn,
        }

        public Point[][] PixelsPosition { get; private set; }

        public OutlineElements()
        {
            PixelsPosition = new Point[4][];

            PixelsPosition[(int)OutlineDivision.TopLine] = new Point[LineSize + 1];
            PixelsPosition[(int)OutlineDivision.BottomLine] = new Point[LineSize + 1];
            PixelsPosition[(int)OutlineDivision.LeftColumn] = new Point[ColumnSize + 1];
            PixelsPosition[(int)OutlineDivision.RightColumn] = new Point[ColumnSize + 1];

            for (int i = 0; i <= LineSize; i++)
            {
                PixelsPosition[(int)OutlineDivision.TopLine][i] = new Point(i, StartColumn);
                PixelsPosition[(int)OutlineDivision.BottomLine][i] = new Point(i, ColumnSize);
            }

            for (int i = 0; i <= ColumnSize; i++)
            {
                PixelsPosition[(int)OutlineDivision.LeftColumn][i] = new Point(StartLine, i);
                PixelsPosition[(int)OutlineDivision.RightColumn][i] = new Point(LineSize, i);
            }
        }

        public override bool Collision(SnakeElement snake)
        {
            foreach(var element in PixelsPosition)
            {
                foreach(var point in element)
                {
                    if (point.Equals(snake.Body[0]))
                        return true;
                }
            }

            return false;
        }

        public void PrintOutlinePosition()
        {
            var queryPosition = from tab in PixelsPosition
                                from pixel in tab
                                let outlineDivision = (pixel.Y == 0) ? "TopLine : " : (pixel.Y == ColumnSize) ? "BottomLine" : (pixel.X == 0) ? "LeftColumn : " : "RightColumn"
                                group pixel by outlineDivision;

            foreach (var key in queryPosition)
            {
                Console.WriteLine(key.Key);
                foreach (var pixel in key)
                {
                    Console.WriteLine("\n  Point : \n" +
                                      "     PosX : " + pixel.X + "\n" +
                                      "     PosY : " + pixel.Y + "");
                }
            }
        }

    }
}
