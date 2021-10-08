using System;
using System.Collections.Generic;
using System.Linq;

namespace snake_project
{
    internal class SnakeElement : SettingElements
    {
        public List<Point> Body { get; set; }
        private SnakeEventHandler _input = new SnakeEventHandler();

        public SnakeElement()
        {
            Body = new List<Point>() {
                new Point(LineSize / 2, ColumnSize / 2),
                new Point(LineSize / 2, ColumnSize / 2),
                new Point(LineSize / 2, ColumnSize / 2),
            };
        }

        public void HeadDirection()
        {
            FollowingBody();

            var input = _input.Input();
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    Body[0].Y--;
                    break;

                case ConsoleKey.DownArrow:
                    Body[0].Y++;
                    break;

                case ConsoleKey.LeftArrow:
                    Body[0].X--;
                    break; 

                case ConsoleKey.RightArrow:
                    Body[0].X++;
                    break;
            }

        }

        public void FollowingBody()
        {
            for (int i = Body.Count; i > 1; i--)
            {
                Body[i - 1].X = Body[i - 2].X;
                Body[i - 1].Y = Body[i - 2].Y;
            }
        }

        public override bool Collision(SnakeElement snake)
        {
            for(int i = 1; i < Body.Count; i++)
            {
                if(Body[0].Equals(Body[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void CreateBody()
        {
            Body.Add(new Point(Body.Last().X + 1, Body.Last().Y));
        }

        public override String ToString()
        {
            return "PosX : " + Body[0].X + "\n" +
                   "PosY : " + Body[0].Y + "\n";
        }

    }
}
