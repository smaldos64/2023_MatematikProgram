using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatematikProgram.Tools
{
    public class KeyHelper
    {
        //public static bool IsKeyPressedValid(Key ThisKey)
        //{
        //    if (ThisKey >= Key.D0 && ThisKey <= Key.D9) ; // it`s number
        //    else if (ThisKey >= Key.NumPad0 && ThisKey <= Key.NumPad9) ; // it`s number
        //    else if (ThisKey == Key.Escape || ThisKey == Key.Tab || ThisKey == Key.CapsLock || ThisKey == Key.LeftShift || ThisKey == Key.LeftCtrl ||
        //        ThisKey == Key.LWin || ThisKey == Key.LeftAlt || ThisKey == Key.RightAlt || ThisKey == Key.RightCtrl || ThisKey == Key.RightShift ||
        //        ThisKey == Key.Left || ThisKey == Key.Up || ThisKey == Key.Down || ThisKey == Key.Right || ThisKey == Key.Return || ThisKey == Key.Delete ||
        //        ThisKey == Key.System || ThisKey == Key.OemComma || ThisKey == Key.OemMinus || ThisKey == Key.Subtract) ; // it`s a system key (add other key here if you want to allow)
        //    else
        //        return (false); // the key will suppressed

        //    return (true);
        //}

        public static bool IsKeyPressedValicControlKey(Key ThisKey)
        {
            if (ThisKey == Key.Escape || ThisKey == Key.Tab || ThisKey == Key.CapsLock || ThisKey == Key.LeftShift || ThisKey == Key.LeftCtrl ||
                ThisKey == Key.LWin || ThisKey == Key.LeftAlt || ThisKey == Key.RightAlt || ThisKey == Key.RightCtrl || ThisKey == Key.RightShift ||
                ThisKey == Key.Left || ThisKey == Key.Up || ThisKey == Key.Down || ThisKey == Key.Right || ThisKey == Key.Return || ThisKey == Key.Delete ||
                ThisKey == Key.System)  // it`s a system key (add other key here if you want to allow)
            {
                return (true);
            }
            else
            {
                return (false); // the key will suppressed
            }
        }

        public static bool IsKeyPressedValid(Key ThisKey)
        {
            if (ThisKey >= Key.D0 && ThisKey <= Key.D9) ; // it`s number
            else if (ThisKey >= Key.NumPad0 && ThisKey <= Key.NumPad9) ; // it`s number
            else if (ThisKey == Key.Escape || ThisKey == Key.Tab || ThisKey == Key.CapsLock || ThisKey == Key.LeftShift || ThisKey == Key.LeftCtrl ||
                ThisKey == Key.LWin || ThisKey == Key.LeftAlt || ThisKey == Key.RightAlt || ThisKey == Key.RightCtrl || ThisKey == Key.RightShift ||
                ThisKey == Key.Left || ThisKey == Key.Up || ThisKey == Key.Down || ThisKey == Key.Right || ThisKey == Key.Return || ThisKey == Key.Delete ||
                ThisKey == Key.System); // it`s a system key (add other key here if you want to allow)
            else
                return (false); // the key will suppressed

            return (true);
        }

        public static bool IsKeyPressedValidNumeric(string ControlText, Key ThisKey)
        {
            int SearchPositionMinus = -1;
            int SearchPositionComma = -1;
            int StringLength = ControlText.Length;

            SearchPositionMinus = ControlText.IndexOf("-");
            SearchPositionComma = ControlText.IndexOf(",");

            if ((Key.OemMinus == ThisKey) || (Key.Subtract == ThisKey))
            {
                if (-1 != SearchPositionMinus)
                {
                    return (false);
                }

                if (0 != StringLength)
                {
                    return (false);
                }
                return (true);
            }

            if (Key.OemComma == ThisKey) 
            {
                if (-1 != SearchPositionComma)
                {
                    return (false);
                }
                else
                {
                    return (true);
                }
            }

            return (IsKeyPressedValid(ThisKey));
        }

        public static bool IsKeyPressedValidPositive(string ControlText, Key ThisKey)
        {
            int SearchPositionComma = -1;
            int StringLength = ControlText.Length;

            SearchPositionComma = ControlText.IndexOf(",");

            if (Key.OemComma == ThisKey)
            {
                if (-1 != SearchPositionComma)
                {
                    return (false);
                }
                else
                {
                    return (true);
                }
            }

            return (IsKeyPressedValid(ThisKey));
        }

        public static bool IsKeyPressedValidInteger(string ControlText, Key ThisKey)
        {
            int SearchPositionMinus = -1;
            int StringLength = ControlText.Length;

            SearchPositionMinus = ControlText.IndexOf("-");
            
            if ((Key.OemMinus == ThisKey) || (Key.Subtract == ThisKey))
            {
                if (-1 != SearchPositionMinus)
                {
                    return (false);
                }

                if (0 != StringLength)
                {
                    return (false);
                }
                return (true);
            }
            
            return (IsKeyPressedValid(ThisKey));
        }

        public static bool IsKeyPressedValidPositiveInteger(string ControlText, Key ThisKey)
        {
             return (IsKeyPressedValid(ThisKey));
        }
    }
}
