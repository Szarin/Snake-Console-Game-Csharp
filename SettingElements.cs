using System.Collections.Generic;

namespace snake_project
{

    class SettingElements
    {
        public static int[,] Grid = new int[40, 20];
        public static int LineSize = Grid.GetLength(0) - 1;
        public static int ColumnSize = Grid.GetLength(1) - 1;
        public static int StartLine = 1, StartColumn = 1;

        public SnakeElement Snake;
        public List<AppleElement> Apples = new List<AppleElement>();
        public OutlineElements Outline { get; init; }

        private const int _nbApples = 3;

        public SettingElements()
        {
        }

        public SettingElements(SnakeElement snake)
        {
            Snake = snake;

            //Apples = new List<AppleElement>();
            for(int i = 0; i < _nbApples; i++)
            {
                Apples.Add(new AppleElement());
            }

            Outline = new OutlineElements();
        }

        public virtual bool Collision(SnakeElement snake)
        {
            foreach (var apple in Apples)
            {
                if (apple.Collision(snake))
                {
                    apple.Remove(Apples);
                    Apples.Add(new AppleElement());
                    Snake.CreateBody();
                    return true;
                }
                    
            }

            if(Outline.Collision(snake) || snake.Collision(snake))
            {
                if(Game.IsStarted != false) {
                Game.GameOver();
                return true;
                }
            }

            return false;
        }

    }

}
