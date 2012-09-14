using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace KomMee
{
    public static class Input
    {
        private const int kmUp = 0;
        private const int kmDown = 1;
        private const int kmLeft = 2;
        private const int kmRight = 3;
        private const int kmApply = 4;
        private const int kmCancel = 5;

        private static Dictionary<int, int> keymapping;

        public static void init()
        {
            Input.keymapping = new Dictionary<int, int>();
            
        }

        public static void up()
        {
        }

        public static void down()
        {
        }

        public static void left()
        {
        }

        public static void right()
        {
        }

        public static void apply()
        {
        }

        public static void cancel()
        {
        }

        public static void handleKeyboardEvent(int keyValue)
        {
            if (Input.keymapping.ContainsKey(keyValue))
            {
                int keymappingValue = Input.keymapping[keyValue];
                switch (keymappingValue)
                {
                    case Input.kmUp:
                        Input.up();
                        break;
                    case Input.kmDown:
                        Input.down();
                        break;
                    case Input.kmLeft:
                        Input.left();
                        break;
                    case Input.kmRight:
                        Input.right();
                        break;
                    case Input.kmApply:
                        Input.apply();
                        break;
                    case Input.kmCancel:
                        Input.cancel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
