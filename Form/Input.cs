using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data;

namespace KomMee
{
    public static class Input
    {
        private static Dictionary<int, string> keymapping;
        private static View view;

        public static void init(View view)
        {
            Input.view = view;
            Input.keymapping = new Dictionary<int, string>();
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Up")), "Keymapping_Up");
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Down")), "Keymapping_Down");
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Left")), "Keymapping_Left");
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Right")), "Keymapping_Right");
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Apply")), "Keymapping_Apply");
            Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Cancel")), "Keymapping_Cancel");
        }

        public static void up()
        {
            Console.WriteLine("Input: Up-Event");
            view.KeyboardView.up();
        }

        public static void down()
        {
            Console.WriteLine("Input: Down-Event");
            view.KeyboardView.down();
        }

        public static void left()
        {
            Console.WriteLine("Input: Left-Event");
            view.KeyboardView.left();
        }

        public static void right()
        {
            Console.WriteLine("Input: Right-Event");
            view.KeyboardView.right();
        }

        public static void apply()
        {
            Console.WriteLine("Input: Apply-Event");
            view.KeyboardView.apply();
        }

        public static void cancel()
        {
            Console.WriteLine("Input: Cancel-Event");
            view.KeyboardView.cancel();
        }

        public static void handleKeyboardEvent(int keyValue)
        {
            if (Input.keymapping.ContainsKey(keyValue))
            {
                string keymappingValue = Input.keymapping[keyValue];
                switch (keymappingValue)
                {
                    case "Keymapping_Up":
                        Input.up();
                        break;
                    case "Keymapping_Down":
                        Input.down();
                        break;
                    case "Keymapping_Left":
                        Input.left();
                        break;
                    case "Keymapping_Right":
                        Input.right();
                        break;
                    case "Keymapping_Apply":
                        Input.apply();
                        break;
                    case "Keymapping_Cancel":
                        Input.cancel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
