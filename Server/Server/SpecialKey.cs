using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class SpecialKeys
    {
        private static SpecialKeys instance;
        //Used to detect when keys are pressed.
        private static bool shift;
        private static bool ctrl;
        private static bool alt;
        private static bool up;
        private static bool down;
        private static bool left;
        private static bool right;
        private static bool del;
        private static bool backspace;
        private static bool space;
        private static bool win;

        private SpecialKeys()
        {
        }

        public static SpecialKeys SharedInstance
        {
            get
            {
                if (instance == null)
                { 
                    instance = new SpecialKeys();
                }
                return instance;
            }
            
        }

        public bool IsShiftPressed()
        {
            return shift;
        }

        public bool IsCtrlPressed()
        {
            return ctrl;
        }

        public bool IsAltPressed()
        {
            return alt;
        }

        public bool IsUpPressed()
        {
            return up;
        }

        public bool IsDownPressed()
        {
            return down;
        }

        public bool IsLeftPressed()
        {
            return left;
        }

        public bool IsRightPressed()
        {
            return right;
        }

        public bool IsDelPressed()
        {
            return del;
        }

        public bool IsBackspacePressed()
        {
            return backspace;
        }

        public bool IsSpacePressed()
        {
            return space;
        }

        public bool IsWinPressed()
        {
            return win;
        }

        public void SetShift(bool value)
        { 
           shift = value;
        }

        public void SetCtrl(bool value)
        { 
           ctrl = value;
        }

        public void SetAlt(bool value)
        { 
           alt = value;
        }

        public void SetUp(bool value)
        { 
           up = value;
        }

        public void SetDown(bool value)
        { 
           down = value;
        }

        public void SetLeft(bool value)
        { 
           left = value;
        }

        public void SetRight(bool value)
        { 
           right = value;
        }

        public void SetDel(bool value)
        { 
           del = value;
        }

        public void SetBackspace(bool value)
        { 
           backspace = value;
        }

        public void SetSpace(bool value)
        { 
           space = value;
        }

        public void SetWin(bool value)
        { 
           win = value;
        }
    }
}
