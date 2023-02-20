using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikProgram.Tools
{
    public static class StringHelper
    {
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string InsertCharacterInStringAtSpecifiedInterval(string InputString,
                                                                        int Interval,
                                                                        char InsertCharacter)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < InputString.Length; i = i + Interval)
            {
                int getMe = Interval;
                if (i + Interval > InputString.Length)
                    getMe = (InputString.Length - i);

                sb.Append(InputString.Substring(i, getMe));
                sb.Append(InsertCharacter);
            }

            if (sb[0] == InsertCharacter)
            {
                sb = sb.Remove(0, 1);
            }

            if (sb[sb.Length - 1] == InsertCharacter)
            {
                sb = sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        public static string TrimAndRemoveSpecifiedCharacterFromString(string InputString, char CharToRemove)
        {
            InputString = InputString.Trim();
            InputString = InputString.Replace(CharToRemove.ToString(), string.Empty);

            return (InputString);
        }
    }
}
