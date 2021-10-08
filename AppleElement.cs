using System;
using System.Collections.Generic;

namespace snake_project
{
    internal class AppleElement : SettingElements
    {
        public Point Position;
        private Random _generatePixel;

        public AppleElement()
        {
            _generatePixel = new Random();
            Position = new Point() { X = _generatePixel.Next(StartLine + 1, LineSize), Y = _generatePixel.Next(StartColumn + 1, ColumnSize) };
        }

        public override bool Collision(SnakeElement snake)
        {
            if(Position.Equals(snake.Body[0]))
            {
                return true;
            }
            return false;
        }

        /**
         * Better to implement IEquatable<T>
         * to possibly remove by the List<Apple> Apples -> Apples.Remove(apple);
         */
        public void Remove(List<AppleElement> apples)
        {
            for(int i = 0; i < apples.Count; i++) {
                if(this.Equals(apples[i]))
                {
                    apples.RemoveAt(i);
                }
            }
        }

        public override String ToString()
        {
            return "Apple\n" + 
                   "     PositionX : " + Position.X + "\n" +
                   "     PositionY : " + Position.Y ;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AppleElement))
                return false;

            AppleElement appleElement = (AppleElement)obj;
            return appleElement.Position.X == Position.X && appleElement.Position.Y == Position.Y;
        }
    }
}
