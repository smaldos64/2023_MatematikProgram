using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MatematikProgram.Tools;

namespace MatematikProgram.NumberSystems
{
    public class RadixNumber : NumberSystem
    {
        public ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object { get; set; }

        public RadixNumber(ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object)
        {
            this.ConstRadixSystemAndDelegates_Object = ConstRadixSystemAndDelegates_Object;
        }

        public RadixNumber()
        {
            this.ConstRadixSystemAndDelegates_Object = new ConstRadixSystemAndDelegates();
        }

        public override bool IsKeyValid(Key ThisKey)
        {
            return (this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.ValidKeysArray.Contains(ThisKey) ||
                    KeyHelper.IsKeyPressedValicControlKey(ThisKey));
        }

        public override string ConvertFromRadix10(int Radix10Number)
        {
            string ReturnString = " ";

            if (null == this.ConstRadixSystemAndDelegates_Object.FunctionPointerFromRadix10)
            {
                ReturnString = base.ConvertFromRadix10(Radix10Number,
                    this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixValue,
                    this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCounter,
                    this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter);
            }
            else
            {
                ReturnString = this.ConstRadixSystemAndDelegates_Object.FunctionPointerFromRadix10(Radix10Number,
                    this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter,
                    this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCounter);
            }

            return (ReturnString);
        }

        public override int ConvertToRadix10(string RadixStringToConvert)
        {
            int Radix10Value = -1;

            if (null == this.ConstRadixSystemAndDelegates_Object.FunctionPointerToRadix10)
            {
                Radix10Value = base.ConvertToRadix10(RadixStringToConvert, 
                                                     this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixValue,
                                                     this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter);
            }
            else
            {
                Radix10Value = this.ConstRadixSystemAndDelegates_Object.FunctionPointerToRadix10(RadixStringToConvert,
                                                                                                 this.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter);
            }

            return (Radix10Value);
        }
    }
}
