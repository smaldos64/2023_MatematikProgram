using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikProgram.NumberSystems
{
    public class NumberSystemConverter
    {
        public int NumberValue { get; set; }
        public char NumberChar { get; set; }

        public NumberSystemConverter(int NumberValue, char NumberChar)
        {
            this.NumberValue = NumberValue;
            this.NumberChar = NumberChar;
        }
    }

    public class NumberSystemHelper
    {
        private static readonly NumberSystemConverter[] NumberSystemConverterArray =
        {
            new NumberSystemConverter(NumberValue : 0, NumberChar: '0'),
            new NumberSystemConverter(NumberValue : 1, NumberChar: '1'),
            new NumberSystemConverter(NumberValue : 2, NumberChar: '2'),
            new NumberSystemConverter(NumberValue : 3, NumberChar: '3'),
            new NumberSystemConverter(NumberValue : 4, NumberChar: '4'),
            new NumberSystemConverter(NumberValue : 5, NumberChar: '5'),
            new NumberSystemConverter(NumberValue : 6, NumberChar: '6'),
            new NumberSystemConverter(NumberValue : 7, NumberChar: '7'),
            new NumberSystemConverter(NumberValue : 8, NumberChar: '8'),
            new NumberSystemConverter(NumberValue : 9, NumberChar: '9'),
            new NumberSystemConverter(NumberValue : 10, NumberChar: 'A'),
            new NumberSystemConverter(NumberValue : 11, NumberChar: 'B'),
            new NumberSystemConverter(NumberValue : 12, NumberChar: 'C'),
            new NumberSystemConverter(NumberValue : 13, NumberChar: 'D'),
            new NumberSystemConverter(NumberValue : 14, NumberChar: 'E'),
            new NumberSystemConverter(NumberValue : 15, NumberChar: 'F'),
            new NumberSystemConverter(NumberValue : 16, NumberChar: 'G'),
            new NumberSystemConverter(NumberValue : 17, NumberChar: 'H'),
            new NumberSystemConverter(NumberValue : 18, NumberChar: 'I'),
            new NumberSystemConverter(NumberValue : 19, NumberChar: 'J'),
            new NumberSystemConverter(NumberValue : 20, NumberChar: 'K'),
            new NumberSystemConverter(NumberValue : 21, NumberChar: 'L'),
            new NumberSystemConverter(NumberValue : 22, NumberChar: 'M'),
            new NumberSystemConverter(NumberValue : 23, NumberChar: 'N'),
            new NumberSystemConverter(NumberValue : 24, NumberChar: 'O'),
            new NumberSystemConverter(NumberValue : 25, NumberChar: 'P'),
            new NumberSystemConverter(NumberValue : 26, NumberChar: 'Q'),
            new NumberSystemConverter(NumberValue : 27, NumberChar: 'R'),
            new NumberSystemConverter(NumberValue : 28, NumberChar: 'S'),
            new NumberSystemConverter(NumberValue : 29, NumberChar: 'T'),
            new NumberSystemConverter(NumberValue : 30, NumberChar: 'U'),
            new NumberSystemConverter(NumberValue : 31, NumberChar: 'V')
        };

        public static int MyNumberConverter(char InputChar)
        {
            int Counter = 0;

            InputChar = Char.ToUpper(InputChar);

            do
            {
                if (NumberSystemConverterArray[Counter].NumberChar == InputChar)
                {
                    return (NumberSystemConverterArray[Counter].NumberValue);
                }
                else
                {
                    Counter++;
                }
            } while (Counter < NumberSystemConverterArray.Length);

            return (-1);
        }

        public static char MyCharConverter(int InputNumber)
        {
            int Counter = 0;

            do
            {
                if (NumberSystemConverterArray[Counter].NumberValue == InputNumber)
                {
                    return (NumberSystemConverterArray[Counter].NumberChar);
                }
                else
                {
                    Counter++;
                }
            } while (Counter < NumberSystemConverterArray.Length);

            return ('Å');
        }
    }
}
