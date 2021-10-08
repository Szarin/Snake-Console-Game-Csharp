using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_project
{
    static class Game
    {
        static SnakeElement Snake = new SnakeElement();
        static SettingElements Elements = new SettingElements(Snake);
        public static bool IsLose = false;
        public static bool IsStarted = false;

        public static void GameStart()
        {
            Console.SetWindowSize(width: SettingElements.LineSize + 2, height: SettingElements.ColumnSize + 2);
            Display.PrintBoard();

            while (!IsLose)
            {
                Snake.HeadDirection();
                //foreach(var apple in Elements.Apples)
                    //Snake.OnCollisionApple(apple);
                Display.Update(Elements);
                Elements.Collision(Snake);
            }
        }

        public static void GameOver()
        {

                Console.Clear();
                IsLose = true;
        }
    }
}
