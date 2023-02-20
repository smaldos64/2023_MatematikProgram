using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MatematikProgram.NumberSystems;

namespace MatematikProgram.Tools
{
    public enum RadixNumber_ENUM
    {
        BINARY_NUMBER,
        OCTAL_NUMBER,
        DECIMAL_NUMBER,
        HEXADECIMAL_NUMBER,
        RADIX24_NUMBER,
        RADIX32_NUMBER,
        ROMER_NUMBER,
    }

    public class ConstRadixSystem
    {
        public int RadixValue { get; set; }
        public int RadixSpaceCounter { get; set; }
        public char RadixSpaceCharacter { get; set; }
        public Key[] ValidKeysArray;

        public ConstRadixSystem(int RadixValue, int RadixSpaceCounter,
                                char RadixSpaceCharacter, Key[] ValidKeysArray)
        {
            this.RadixValue = RadixValue;
            this.RadixSpaceCounter = RadixSpaceCounter;
            this.RadixSpaceCharacter = RadixSpaceCharacter;
            this.ValidKeysArray = ValidKeysArray;
        }

        public ConstRadixSystem()
        {

        }
    }

    public delegate string ConvertFromRadix10Int(int Radix10Number, char CharacterToInsert, int CharacterToInsertCouner);
    public delegate int ConvertToRadix10Int(string Radix10String, char CharacterToRemove);

    public class ConstRadixSystemAndDelegates
    {
        public ConstRadixSystem ConstRadixSystem_Object { get; set; }
        public ConvertToRadix10Int FunctionPointerToRadix10 { get; set; }
        public ConvertFromRadix10Int FunctionPointerFromRadix10 { get; set; }
        public TextBox TextBox_Object { get; set; }
        public string TextBox_Object_Name { get; set; }
        public string Label_Object_Name { get; set; }
        public string Label_Object_Text { get; set; }

        public ComboBox ComboBox_Object_RadixSpaceCounter { get; set; }
        public string ComboBox_Object_RadixSpaceCounter_Name { get; set; }
        public ComboBox ComboBox_Object_RadixSpaceCharacter { get; set; }
        public string ComboBox_Object_RadixSpaceCharacter_Name { get; set; }
        public Button Button_Object_Delete { get; set; }
        public string Button_Object_Delete_Name { get; set; }

        public int FirstLabelInGridRowPosition { get; set; }
        public int GridRowPosition { get; set; }

        public ConstRadixSystemAndDelegates(ConstRadixSystem ConstRadixSystem_Object,
                                            string TextBox_Object_Name,
                                            string Label_Object_Name,
                                            string Label_Object_Text,
                                            ConvertToRadix10Int FunctionPointerToRadix10,
                                            ConvertFromRadix10Int FunctionPointerFromRadix10)
        {
            this.ConstRadixSystem_Object = ConstRadixSystem_Object;
            this.TextBox_Object_Name = TextBox_Object_Name;
            this.Label_Object_Name = Label_Object_Name;
            this.Label_Object_Text = Label_Object_Text;
            this.FunctionPointerToRadix10 = FunctionPointerToRadix10;
            this.FunctionPointerFromRadix10 = FunctionPointerFromRadix10;
        }

        public ConstRadixSystemAndDelegates(ConstRadixSystem ConstRadixSystem_Object,
                                            string TextBox_Object_Name,
                                            string Label_Object_Name,
                                            string Label_Object_Text,
                                            string ComboBox_Object_RadixSpaceCharacter_Name,
                                            string ComboBox_Object_RadixSpaceCounter_Name,
                                            string Button_Object_Delete_Name,
                                            ConvertToRadix10Int FunctionPointerToRadix10,
                                            ConvertFromRadix10Int FunctionPointerFromRadix10)
        {
            this.ConstRadixSystem_Object = ConstRadixSystem_Object;
            this.TextBox_Object_Name = TextBox_Object_Name;
            this.Label_Object_Name = Label_Object_Name;
            this.Label_Object_Text = Label_Object_Text;
            this.FunctionPointerToRadix10 = FunctionPointerToRadix10;
            this.FunctionPointerFromRadix10 = FunctionPointerFromRadix10;

            this.ComboBox_Object_RadixSpaceCharacter_Name = ComboBox_Object_RadixSpaceCharacter_Name;
            this.ComboBox_Object_RadixSpaceCounter_Name = ComboBox_Object_RadixSpaceCounter_Name;
            this.Button_Object_Delete_Name = Button_Object_Delete_Name;
        }

        public ConstRadixSystemAndDelegates()
        {
            this.ConstRadixSystem_Object = new ConstRadixSystem();
        }
    }

    public class ConstRadixSystemAndDelegatesExtended
    {
        public ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object { get; set; }
        public RadixNumber RadixNumber_Object { get; set; }

        public ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object,
                                                    RadixNumber RadixNumber_Object)
        {
            this.ConstRadixSystemAndDelegates_Object = ConstRadixSystemAndDelegates_Object;
            this.RadixNumber_Object = RadixNumber_Object;
        }

        public ConstRadixSystemAndDelegatesExtended()
        {
            this.ConstRadixSystemAndDelegates_Object = new ConstRadixSystemAndDelegates();
            this.RadixNumber_Object = new RadixNumber();
        }
    }

    public class KeyToCharConverter
    {
        public int Value { get; set; }
        public int KeyValue { get; set; }
        public char KeyChar { get; set; }

        public KeyToCharConverter(int Value, int KeyValue, char KeyChar)
        {
            this.Value = Value;
            this.KeyValue = KeyValue;
            this.KeyChar = KeyChar;
        }
    }
    
    public class ConstNumberSystems
    {
        public static readonly int GridStartNumberSystemRow = 5;
        //public static readonly int LabelColumnPosition = 0;
        //public static readonly int LabelColumnSpanShort = 1;
        //public static readonly int LabelColumnSpan = 2;
        //public static readonly int TextBoxColumnPosition = 2;
        //public static readonly int TextBoxColumnSpanShort = 1;
        //public static readonly int TextBoxColumnSpan = 4;
        //public static readonly int TextBoxWidthShort = 100;
        //public static readonly int TextBoxWidth = 240;
        //public static readonly int TextBoxHeight = 23;

        public static readonly int ComboBoxRadixSpaceCounterColumn = 6;
        public static readonly int ComboBoxRadixSpaceCharacterColumn = 8;

        public static readonly int ButtonxRadixDeleteColumn = 9;
        public static readonly int ButtonxRadixDeleteColumnSpan = 2;
        public static readonly int ButtonxRadixDeleteHeight = 23;
        public static readonly int ButtonxRadixDeleteWidth = 70;

        //public static readonly int DynamicElementsRowHeight = 40;
        //public static readonly int ComboBoxRowHeight = 30;

        public static readonly int MinRadixSystemValue = 2;
        public static readonly int MaxRadixSystemValue = 32;
        public static readonly int MinRadixSystemSpaces = 0;
        public static readonly int MaxRadixSystemSpaces = 5;

        public static readonly int NumberOfControlsInGridRow = 5;

        public static readonly char[] RadixSystemSpaceCharacterArray =
        {
            '.',
            ',',
            ' ',
            '#',
            '%',
            '@',
            '/',
            '\\'
        };

        private static Key[] Radix2ValidKeysArray = { Key.D0, Key.D1 };
        private static Key[] Radix8ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7 };
        private static Key[] Radix10ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D2, Key.D3, Key.D4,
                                                       Key.D5, Key.D6, Key.D7, Key.D8, Key.D9};
        private static Key[] Radix16ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F};
        private static Key[] Radix24ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F,
                                                       Key.G, Key.H, Key.I, Key.J, Key.L, Key.M, Key.N, Key.O};
        private static Key[] Radix32ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F,
                                                       Key.G, Key.H, Key.I, Key.J, Key.K, Key.L, Key.M, Key.N,
                                                       Key.O, Key.P, Key.Q, Key.R, Key.S, Key.T, Key.U, Key.V};

        public static readonly ConstRadixSystem[] RadixSystemArray =
        {
            new ConstRadixSystem(RadixValue : 2, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix2ValidKeysArray),
            new ConstRadixSystem(RadixValue : 8, RadixSpaceCounter : 3, RadixSpaceCharacter : ' ', ValidKeysArray : Radix8ValidKeysArray),
            new ConstRadixSystem(RadixValue : 10, RadixSpaceCounter : 3, RadixSpaceCharacter : '.', ValidKeysArray : Radix10ValidKeysArray),
            new ConstRadixSystem(RadixValue : 16, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix16ValidKeysArray),
            new ConstRadixSystem(RadixValue : 24, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix24ValidKeysArray),
            new ConstRadixSystem(RadixValue : 32, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix32ValidKeysArray)
        };

        public static readonly ConstRadixSystemAndDelegates[] RadixSystemDelegatesAndControlsArray =
        {
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.BINARY_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtBinaryNumber",
                                             Label_Object_Name : "lblBinaryNumber",
                                             Label_Object_Text : "Binært tal (2 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.OCTAL_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtOctalNumber",
                                             Label_Object_Name : "lblOctalNumber",
                                             Label_Object_Text : "Oktalt tal (8 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            //new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
            //                                 RadixSystemArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER],
            //                                 //TextBox_Object : null,
            //                                 TextBox_Object_Name : "txtDecimalNumber",
            //                                 Label_Object_Name : "lblDecimalNumber",
            //                                 Label_Object_Text : "Decimaltal (10 tals system) : ",
            //                                 FunctionPointerToRadix10 : MainWindow.ConvertToRadix10IntFromRadix10String,
            //                                 FunctionPointerFromRadix10 : MainWindow.ConvertFromRadix10IntToRadix10String),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtHexadecimalNumber",
                                             Label_Object_Name : "lblHexadecimalNumber",
                                             Label_Object_Text : "Hexadecimalt tal (16 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.RADIX24_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtRadix24Number",
                                             Label_Object_Name : "lblRadixNumber",
                                             Label_Object_Text : "Radix 24 tal (24 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.RADIX32_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtRadix32Number",
                                             Label_Object_Name : "lblRadix32Number",
                                             Label_Object_Text : "Radix 32 tal (32 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null)
        };

        public static readonly ConstRadixSystemAndDelegatesExtended[] RadixSystemDelegatesAndControlsExtendedArray =
        {
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.BINARY_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.BINARY_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.OCTAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.OCTAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX24_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX24_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX32_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX32_NUMBER]))
        };

        public static readonly KeyToCharConverter[] KeyToCharConverterArray =
        {
            new KeyToCharConverter(Value : 0, KeyValue : (int)Key.D0, KeyChar: '0'),
            new KeyToCharConverter(Value : 1, KeyValue : (int)Key.D1, KeyChar: '1'),
            new KeyToCharConverter(Value : 2, KeyValue : (int)Key.D2, KeyChar: '2'),
            new KeyToCharConverter(Value : 3, KeyValue : (int)Key.D3, KeyChar: '3'),
            new KeyToCharConverter(Value : 4, KeyValue : (int)Key.D4, KeyChar: '4'),
            new KeyToCharConverter(Value : 5, KeyValue : (int)Key.D5, KeyChar: '5'),
            new KeyToCharConverter(Value : 6, KeyValue : (int)Key.D6, KeyChar: '6'),
            new KeyToCharConverter(Value : 7, KeyValue : (int)Key.D7, KeyChar: '7'),
            new KeyToCharConverter(Value : 8, KeyValue : (int)Key.D8, KeyChar: '8'),
            new KeyToCharConverter(Value : 9, KeyValue : (int)Key.D9, KeyChar: '9'),
            new KeyToCharConverter(Value : 10, KeyValue : (int)Key.A, KeyChar: 'A'),
            new KeyToCharConverter(Value : 11, KeyValue : (int)Key.B, KeyChar: 'B'),
            new KeyToCharConverter(Value : 12, KeyValue : (int)Key.C, KeyChar: 'C'),
            new KeyToCharConverter(Value : 13, KeyValue : (int)Key.D, KeyChar: 'D'),
            new KeyToCharConverter(Value : 14, KeyValue : (int)Key.E, KeyChar: 'E'),
            new KeyToCharConverter(Value : 15, KeyValue : (int)Key.F, KeyChar: 'F'),
            new KeyToCharConverter(Value : 16, KeyValue : (int)Key.G, KeyChar: 'G'),
            new KeyToCharConverter(Value : 17, KeyValue : (int)Key.H, KeyChar: 'H'),
            new KeyToCharConverter(Value : 18, KeyValue : (int)Key.I, KeyChar: 'I'),
            new KeyToCharConverter(Value : 19, KeyValue : (int)Key.J, KeyChar: 'J'),
            new KeyToCharConverter(Value : 20, KeyValue : (int)Key.K, KeyChar: 'K'),
            new KeyToCharConverter(Value : 21, KeyValue : (int)Key.L, KeyChar: 'L'),
            new KeyToCharConverter(Value : 22, KeyValue : (int)Key.M, KeyChar: 'M'),
            new KeyToCharConverter(Value : 23, KeyValue : (int)Key.N, KeyChar: 'N'),
            new KeyToCharConverter(Value : 24, KeyValue : (int)Key.O, KeyChar: 'O'),
            new KeyToCharConverter(Value : 25, KeyValue : (int)Key.P, KeyChar: 'P'),
            new KeyToCharConverter(Value : 26, KeyValue : (int)Key.Q, KeyChar: 'Q'),
            new KeyToCharConverter(Value : 27, KeyValue : (int)Key.R, KeyChar: 'R'),
            new KeyToCharConverter(Value : 28, KeyValue : (int)Key.S, KeyChar: 'S'),
            new KeyToCharConverter(Value : 29, KeyValue : (int)Key.T, KeyChar: 'T'),
            new KeyToCharConverter(Value : 30, KeyValue : (int)Key.U, KeyChar: 'U'),
            new KeyToCharConverter(Value : 31, KeyValue : (int)Key.V, KeyChar: 'V'),
            new KeyToCharConverter(Value : 32, KeyValue : (int)Key.W, KeyChar: 'W'),
            new KeyToCharConverter(Value : 33, KeyValue : (int)Key.X, KeyChar: 'X'),
            new KeyToCharConverter(Value : 34, KeyValue : (int)Key.Y, KeyChar: 'Y'),
            new KeyToCharConverter(Value : 35, KeyValue : (int)Key.Z, KeyChar: 'Z')
        };

        public static List<Key> MakeKeyArrayToRadixSystem(int RadixSystemValue)
        {
            int Counter;
            List<Key> KeyList = new List<Key>();

            for (Counter = 0; Counter < RadixSystemValue; Counter++)
            {
                KeyList.Add((Key)KeyToCharConverterArray[Counter].KeyValue);
            }

            return (KeyList);
        }
    }
}
