using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace snake_project
{
    /*class Board : SettingElements
    {
        static private ElementType[,] _board;
        public enum ElementType { Empty, ESnakeElement, EAppleElements, EOutlineElements, ErrorElement };

        public Board()
        {
            _board = new ElementType[LineSize + 1, ColumnSize + 1];
        }


        public static ElementType GetType(int x, int y)
        {
            object obj = default;
            SnakeElement snakeElement = (SnakeElement)obj;
            if(Grid[x,y].GetType() == typeof(SnakeElement))
            {
                return ElementType.ESnakeElement;
            }

            if (Grid[x, y].GetType() == typeof(AppleElement))
            {
                return ElementType.EAppleElements;
            }

            if (Grid[x, y].GetType() == typeof(OutlineElements))
            {
                return ElementType.EOutlineElements;
            }

            return ElementType.ErrorElement;
        }

        public void Update()
        {
            foreach(var element in Apples)
            {
                //board[1] = ElementType.EAppleElements;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0; i < LineSize; i++) { 
                for(int j = 0; j < ColumnSize; j++) {
                    stringBuilder.Append($"{Grid[i, j]}, ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }*/
}
