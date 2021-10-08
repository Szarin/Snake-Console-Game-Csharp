using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_project
{

    class SnakeEventHandler
    {

        private ConsoleKeyInfo keyInfo;
        private ConsoleKey key;

        public ConsoleKey Input()
        {
            if (Console.KeyAvailable)
            {
                Game.IsStarted = true;
                keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            }

            return key;
        }

    }

}