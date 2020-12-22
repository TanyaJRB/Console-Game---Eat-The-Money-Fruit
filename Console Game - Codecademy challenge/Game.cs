using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Game___Codecademy_challenge
{
    class Game : Super_Game
    {
        public new static void UpdatePosition(string keypressed, out int xchange, out int ychange)
        {
            switch (keypressed)
            {
                case "DownArrow":
                    xchange = 0;
                    ychange = 1;
                    break;
                case "UpArrow":
                    xchange = 0;
                    ychange = -1;
                    break;
                case "RightArrow":
                    xchange = 1;
                    ychange = 0;
                    break;
                case "LeftArrow":
                    xchange = -1;
                    ychange = 0;
                    break;
                default:
                    xchange = 0;
                    ychange = 0;
                    break;
            }
        }

        public new static char UpdateCursor(string keypressed)
        {
            char cursor = 'o';

            switch (keypressed)
            {
                case "DownArrow":
                    cursor = 'v';
                    break;
                case "UpArrow":
                    cursor = '^';
                    break;
                case "RightArrow":
                    cursor = '>';
                    break;
                case "LeftArrow":
                    cursor = '<';
                    break;
                default:
                    break;
            }

            return cursor;
        }

        public new static int KeepInBounds(int coordinate, int maxvalue)
        {
            int finalcoord;

            if (coordinate >= maxvalue)
            {
                finalcoord = 0;
            }
            else if (coordinate < 0)
            {
                finalcoord = maxvalue - 1;
            }
            else { finalcoord = coordinate; }

            return finalcoord;
        }

        public new static bool DidScore(int xplayer, int yplayer, int xfruit, int yfruit)
        {
            if (xplayer == xfruit && yplayer == yfruit)
            {
                return true;
            }
            else { return false; }
        }
    }
}
