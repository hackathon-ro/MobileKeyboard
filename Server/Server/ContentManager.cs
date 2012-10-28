using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Server
{
    class ContentManager
    {
        //For mouseclick
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void DoLeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public static void DoRightClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }
        //

        public ContentManager()
        {
        }

        private static int xMouseMove;
        private static int yMouseMove;

        public static void ShowSymbol(char key)
        {
            //Simulate the basic keys that can be done with a simple SimulateKeyPress method
            //or with the SimulateTextEntry.
            switch (key) 
            {
                case 'A': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A);
                    break;

                case 'B': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B);
                    break;

                case 'C': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C);
                    break;

                case 'D': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                    break;

                case 'E': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
                    break;

                case 'F': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F);
                    break;

                case 'G': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G);
                    break;

                case 'H': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
                    break;

                case 'I': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I);
                    break;

                case 'J': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J);
                    break;

                case 'K': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K);
                    break;

                case 'L': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
                    break;

                case 'M': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M);
                    break;

                case 'N': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N);
                    break;

                case 'O': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O);
                    break;

                case 'P': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P);
                    break;

                case 'Q': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q);
                    break;

                case 'R': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R);
                    break;

                case 'S': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S);
                    break;

                case 'T': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T);
                    break;

                case 'U': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    break;

                case 'V': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V);
                    break;

                case 'W': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W);
                    break;

                case 'X': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X);
                    break;

                case 'Y': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y);
                    break;

                case 'Z': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z);
                    break;

                case '1': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1);
                    break;

                case '2': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_2);
                    break;

                case '3': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_3);
                    break;

                case '4': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_4);
                    break;

                case '5': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5);
                    break;

                case '6': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_6);
                    break;

                case '7': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_7);
                    break;

                case '8': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_8);
                    break;

                case '9': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_9);
                    break;

                case '0': InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_0);
                    break;

                case ';': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_1);
                    break;

                case '/': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_2);
                    break;

                case '`': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_3);
                    break;

                case '[': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_4);
                    break;

                case '\\': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_5);
                    break;

                case ']': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_6);
                    break;

                case '\'': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_7);
                    break;

                case '-': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_MINUS);
                    break;

                case '=': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_PLUS);
                    break;

                case ',': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_COMMA);
                    break;

                case '.': InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_PERIOD);
                    break;

                default: InputSimulator.SimulateTextEntry(key.ToString());
                    break;
            }
        }

        public static void ShowSpecialKey(char key)
        {
            //Taking care of the special keys. Some require being pressed over a long time.
            //Hardcoded.
            //Some keys must be Pressed in order to enable some short-cuts
            //eg. alt+tab; ctrl+c etc.
            switch (key) 
            {
                case 'S':
                    if (SpecialKeys.SharedInstance.IsShiftPressed())
                    {
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                        SpecialKeys.SharedInstance.SetShift(false);
                    }
                    else
                    {
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        SpecialKeys.SharedInstance.SetShift(true);
                    }
                    break;

                case 'C':
                    if (SpecialKeys.SharedInstance.IsCtrlPressed())
                    {
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
                        SpecialKeys.SharedInstance.SetCtrl(false);
                    }
                    else
                    {
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
                        SpecialKeys.SharedInstance.SetCtrl(true);
                    }
                    break;

                case 'A':
                    if (SpecialKeys.SharedInstance.IsAltPressed())
                    {
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
                        SpecialKeys.SharedInstance.SetAlt(false);
                    }
                    else
                    {
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
                        SpecialKeys.SharedInstance.SetAlt(true);
                    }
                    break;

                case 'U': InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);
                    break;

                case 'D': InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
                    break;

                case 'L': InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                    break;

                case 'R': InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
                    break;

                case 'd': InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE);
                    break;

                case 'B': InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);
                    break;

                case 's': InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
                    break;

                case 'W':
                    if (SpecialKeys.SharedInstance.IsWinPressed())
                    {
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.LWIN);
                        SpecialKeys.SharedInstance.SetWin(false);
                    }
                    else
                    {
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.LWIN);
                        SpecialKeys.SharedInstance.SetWin(true);
                    }
                    break;

                case 'E': InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                    break;

                case 'T': InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
                    break;

                case 'c': InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL);
                    break;

                case 'e': InputSimulator.SimulateKeyPress(VirtualKeyCode.ESCAPE);
                    break;

                case '1': InputSimulator.SimulateKeyPress(VirtualKeyCode.F1);
                    break;

                case '2': InputSimulator.SimulateKeyPress(VirtualKeyCode.F2);
                    break;

                case '3': InputSimulator.SimulateKeyPress(VirtualKeyCode.F3);
                    break;

                case '4': InputSimulator.SimulateKeyPress(VirtualKeyCode.F4);
                    break;

                case '5': InputSimulator.SimulateKeyPress(VirtualKeyCode.F5);
                    break;

                case '6': InputSimulator.SimulateKeyPress(VirtualKeyCode.F6);
                    break;

                case '7': InputSimulator.SimulateKeyPress(VirtualKeyCode.F7);
                    break;

                case '8': InputSimulator.SimulateKeyPress(VirtualKeyCode.F8);
                    break;

                case '9': InputSimulator.SimulateKeyPress(VirtualKeyCode.F9);
                    break;

                case '0': InputSimulator.SimulateKeyPress(VirtualKeyCode.F10);
                    break;

                case 'Z': InputSimulator.SimulateKeyPress(VirtualKeyCode.F11);
                    break;

                case 'Q': InputSimulator.SimulateKeyPress(VirtualKeyCode.F12);
                    break;

                case 'l': DoLeftClick(Cursor.Position.X,Cursor.Position.Y);
                    break;

                case 'r': DoRightClick(Cursor.Position.X, Cursor.Position.Y);
                    break;
            }                                
        }

        //For mouse movement.
        public static void MouseCommand(int x, int y)
        {
            if (x > 0) xMouseMove = 2;
            if (x < 0) xMouseMove = -2;
            if (x == 0) xMouseMove = 0;
            if (y > 0) yMouseMove = 2;
            if (y < 0) yMouseMove = -2;
            if (y == 0) yMouseMove = 0;
            Cursor.Position = new Point(Cursor.Position.X + xMouseMove, Cursor.Position.Y + yMouseMove);
            Thread.Sleep(5);
        }

    }
}
