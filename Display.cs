using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;
using static snake_project.SettingElements;

namespace snake_project
{

    static class Display
    {

        private static List<Point> garbages = new List<Point>();

        public static void PrintBoard()
        {
            CursorVisible = false;

            for (int i = StartLine + 1; i <= LineSize - 1; i++)
            {
                DrawPixel(i, StartColumn, "═");
                DrawPixel(i, ColumnSize, "═");
            }

            for (int i = StartColumn + 1; i <= ColumnSize - 1; i++)
            {
                DrawPixel(StartLine, i, "║");
                DrawPixel(LineSize, i, "║"); ;
            }

            DrawPixel(StartLine, StartColumn, "╔");
            DrawPixel(LineSize, StartColumn, "╗");
            DrawPixel(StartLine, ColumnSize, "╚");
            DrawPixel(LineSize, ColumnSize, "╝");
        }

        private static void GarbageCollector(SnakeElement snake)
        {
            foreach(var element in garbages) {
                DrawPixel(element.X - 1, element.Y - 1);
                Write(" ");

                DrawPixel(element.X, element.Y + 1);
                Write(" ");
                DrawPixel(element.X, element.Y);
                Write(" ");
                DrawPixel(element.X - 1, element.Y);
                DrawPixel(element.X, element.Y);
            }
        }

        /*private static void OldGarbageCollector()
        {
            Point lastElement = garbages.LastOrDefault();
            if (lastElement != null)
            {
                DrawPixel(lastElement.X - 1, lastElement.Y - 1);
                Write(" ");

                DrawPixel(lastElement.X, lastElement.Y + 1);
                Write("");
                DrawPixel(lastElement.X, lastElement.Y);
                Write(" ");
                DrawPixel(lastElement.X - 1, lastElement.Y);
                DrawPixel(lastElement.X, lastElement.Y);

            }
        }*/

        private static void GarbageHead(SnakeElement snake)
        {
            foreach(var element in garbages) {
                DrawPixel(element.X - 1, element.Y - 1);
                Write(" ");

                DrawPixel(element.X, element.Y + 1);
                Write(" ");
                DrawPixel(element.X, element.Y);
                Write(" ");
                DrawPixel(element.X - 1, element.Y);
                DrawPixel(element.X, element.Y);
            }
        }

        private static void DrawSnake(SnakeElement snake)
        {
            GarbageCollector(snake);
            garbages.RemoveRange(0, garbages.Count);

            ForegroundColor = ConsoleColor.Green;
            foreach (var element in snake.Body) { 
                DrawPixel(element.X, element.Y, "■");
                garbages.Add(element);
            }
            ForegroundColor = ConsoleColor.White;

        }

        private static void DrawApple(List<AppleElement> apples)
        {
            foreach(var apple in apples)
            {
                ForegroundColor = ConsoleColor.Red;
                DrawPixel(apple.Position.X, apple.Position.Y, "▲");
                ForegroundColor = ConsoleColor.White;
            }
        }

        private static void DrawPixel(int x, int y, string symbol = " ")
        {
            SetCursorPosition(x, y);
            Write(symbol);
        }

        public static void Update(SettingElements settingElements)
        {
            DrawSnake(settingElements.Snake);
            Thread.Sleep(100);
            DrawApple(settingElements.Apples);
        }
    }
}
