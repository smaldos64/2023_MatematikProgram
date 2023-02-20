using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MatematikProgram.Tools;

namespace MatematikProgram.NumberSystems
{
    public abstract class NumberSystem
    {
        public abstract bool IsKeyValid(Key ThisKey);

        public abstract string ConvertFromRadix10(int Radix10Number);

        public virtual string ConvertFromRadix10(int NumberToConvert, int RadixValue, int RadixSpaceCounter,
                                                 char RadixSeperationCharacter)
        {
            int NumberCalculated = 0;
            int Carry = 0;
            string OutputString = "";
            int StringCounter = 0;

            do
            {
                StringCounter++;
                NumberCalculated = NumberToConvert / RadixValue;
                Carry = NumberToConvert % RadixValue;
                OutputString += NumberSystemHelper.MyCharConverter(Carry);

                if (0 != RadixSpaceCounter)
                {
                    if ( (0 == StringCounter % RadixSpaceCounter) && (NumberCalculated > 0) )
                    {
                        OutputString += RadixSeperationCharacter;
                    }
                }
                NumberToConvert = NumberCalculated;
            } while (NumberCalculated > 0);

            return (StringHelper.ReverseString(OutputString));
        }

        public abstract int ConvertToRadix10(string RadixStringToConvert);

        public virtual int ConvertToRadix10(string RadixStringToConvert, int RadixValue, char CharacterToRemove)
        {
            int Radix10Value = 0;

            RadixStringToConvert = StringHelper.ReverseString(RadixStringToConvert);
            RadixStringToConvert = StringHelper.TrimAndRemoveSpecifiedCharacterFromString(RadixStringToConvert, CharacterToRemove);

            for (int Counter = 0; Counter < RadixStringToConvert.Length; Counter++)
            {
                Radix10Value += (int)Math.Pow(RadixValue, Counter) * NumberSystemHelper.MyNumberConverter(RadixStringToConvert[Counter]);
            }

            return (Radix10Value);
        }
    }
}
