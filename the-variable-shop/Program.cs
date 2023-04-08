namespace the_variable_shop;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Variable Shop!");

        byte aByte = 255;
        aByte = 0;
        Console.WriteLine("aByte: " + aByte);

        short aShort = 32767;
        aShort = -32768;
        Console.WriteLine("aShort: " + aShort);

        int aInt = 2147483647;
        aInt = -2147483648;
        Console.WriteLine("aInt: " + aInt);

        long aLong = 9223372036854775807;
        aLong = -9223372036854775808;
        Console.WriteLine("aLong: " + aLong);

        sbyte sByte = 127;
        sByte = -128;
        Console.WriteLine("sByte: " + sByte);

        ushort uShort = 65535;
        uShort = 0;
        Console.WriteLine("uShort: " + uShort);

        uint uInt = 4294967295;
        uInt = 0;
        Console.WriteLine("uInt: " + uInt);

        ulong uLong = 0;
        uLong = 18_446_744_073_709_551_615;
        Console.WriteLine("uLong: " + uLong);

        char aLetter = 'a';
        aLetter = 'z';
        Console.WriteLine("aLetter: " + aLetter);

        string aString = "Welcome to the Variable Shop!";
        aString = "Variable Shop Returns Better Than Ever!";
        Console.WriteLine("aString: " + aString);

        double aDouble = 3.5623;
        aDouble = -3.5623;
        Console.WriteLine("aDouble: " + aDouble);

        float aFloat = 3.5623f;
        aFloat = -3.5623f;
        Console.WriteLine("aFloat: " + aFloat);

        decimal aDecimal = 3.5623m;
        aDecimal = -3.5623m;
        Console.WriteLine("aDecimal: " + aDecimal);

        bool aBool = true;
        aBool = false;
        Console.WriteLine("aBool: " + aBool);
    }
}
