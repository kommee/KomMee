using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data;
using System.Windows.Forms;

namespace KomMee
{
    public static class Input
    {
        private static Dictionary<int, string> keymapping;
        private static MenuState menuState;
        private static View view;
        private static IViewContainer currentIViewContaier;

        public static MenuState MenuState
        {
            get { return Input.menuState; }
        }

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
            Input.menuState = MenuState.ViewMessage;
        }

        public static void showMessage(Message message)
        {
            Input.currentIViewContaier = message.ViewContainer;
            Input.currentIViewContaier.createViewForReading(Input.view.MessageViewContainer);
        }

        public static void setNewMenuState(MenuState menuState)
        {
            switch (menuState)
            {
                case MenuState.None:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { KeyboardButtons.ApplicationClose, KeyboardButtons.MenuContactDelete, KeyboardButtons.MenuContactEdit,
                        KeyboardButtons.MenuContactNew, KeyboardButtons.MenuMessageNew, KeyboardButtons.MenuMessageRecv, KeyboardButtons.MenuMessageSent});
                    break;
                case MenuState.ViewMessage:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.AnswerMessage:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.DeleteMessage:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.NewMessage:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.ChoseReceiver:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.ChoseMessageType:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.AddNewContact:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.EditContact:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.DeleteContact:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                case MenuState.AddMessageTypeToContact:
                    Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
                    break;
                default:
                    break;
            }
            Input.menuState = menuState;
        }

        public static void setViewForAnswer(IViewContainer viewContainer)
        {
            Input.clearViewContainer();
            viewContainer.createViewForAnswer(Input.view.MessageViewContainer);
        }

        public static void clearViewContainer()
        {
            Panel MessageViewContainer = Input.view.MessageViewContainer;
            foreach (Control ctrl in MessageViewContainer.Controls)
            {
                MessageViewContainer.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }

        public static void userInputUp()
        {
            Console.WriteLine("Input: Up-Event");
            if (Input.MenuState == KomMee.MenuState.ViewMessage)
                view.UpperLeftControl.up();
            else
                view.KeyboardView.up();
        }

        public static void userInputDown()
        {
            Console.WriteLine("Input: Down-Event");
            if (Input.MenuState == KomMee.MenuState.ViewMessage)
                view.UpperLeftControl.down();
            else
                view.KeyboardView.down();
        }

        public static void userInputLeft()
        {
            Console.WriteLine("Input: Left-Event");
            view.KeyboardView.left();
        }

        public static void userInputRight()
        {
            Console.WriteLine("Input: Right-Event");
            view.KeyboardView.right();
        }

        public static void userInputApply()
        {
            Console.WriteLine("Input: Apply-Event");
            view.KeyboardView.apply();
        }

        public static void userInputCancel()
        {
            Console.WriteLine("Input: Cancel-Event");
            view.KeyboardView.cancel();
        }

        public static void handleUserInput(int keyValue)
        {
            if (Input.keymapping.ContainsKey(keyValue))
            {
                string keymappingValue = Input.keymapping[keyValue];
                switch (keymappingValue)
                {
                    case "Keymapping_Up":
                        Input.userInputUp();
                        break;
                    case "Keymapping_Down":
                        Input.userInputDown();
                        break;
                    case "Keymapping_Left":
                        Input.userInputLeft();
                        break;
                    case "Keymapping_Right":
                        Input.userInputRight();
                        break;
                    case "Keymapping_Apply":
                        Input.userInputApply();
                        break;
                    case "Keymapping_Cancel":
                        Input.userInputCancel();
                        break;
                    default:
                        break;
                }
            }
        }

        internal static void handleKeyboardEvent(KeyboardViewEventArgs keyboardViewEventArgs)
        {
            switch (Input.MenuState)
            {
                case MenuState.ViewMessage:
                    break;
                case MenuState.AnswerMessage:
                    break;
                case MenuState.DeleteMessage:
                    break;
                case MenuState.NewMessage:
                    break;
                case MenuState.ChoseReceiver:
                    break;
                case MenuState.ChoseMessageType:
                    break;
                case MenuState.AddNewContact:
                    break;
                case MenuState.EditContact:
                    break;
                case MenuState.DeleteContact:
                    break;
                case MenuState.AddMessageTypeToContact:
                    break;
                default:
                    break;
            }
        }
    }
}
