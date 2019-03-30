using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // CHECKED / UNCHECKED 
            checked
            {
                int a = 362880;
                int b = Int32.MaxValue;
                int c = b + a;
            }

            unchecked
            {
                int x = 362880;
                int y = Int32.MaxValue;
                int z = x + y;
            }
            ////////////////////////////////

            // Casting  (implicitly & explicitly) Int32 value to different types 
            Int32 value_int32 = 0;
            Int64 value_int64 = 0;
            byte value_byte = 0;
            double value_double = 0;
            short value_short = 0;

            value_int64 = value_int32; // implicitly
            value_int64 = (Int64)value_int32; //explicitly

            value_byte = value_int32; // cannot convert implicitly type 'int' to 'byte'
            value_byte = (byte)value_int32;

            value_double = value_int32;
            value_double = (double)value_int32;

            value_short = value_int32; // cannot convert implicitly type 'int' to 'short'
            value_short = (short)value_int32;
            ////////////////////////////////////////////////////////
           
            // BOXING / UNBOXING
            //
            int i = 10; // creating a value type 
            object o = i; // boxing value type 'i' to reference type 'o', for this value type the memory is allocated in the heap, and the object "o" is the reference to this value type
            int j = (int) i; // unboxing 'i' from heap to value type 'j' that allocated in stack
 
            Console.ReadKey();
        }
    }
}
