namespace the_variable_shop;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Variable Shop!");

        byte aByte = 255;
        Console.WriteLine("aByte: " + aByte);

        short aShort = 32767;
        Console.WriteLine("aShort: " + aShort);

        int aInt = 2147483647;
        Console.WriteLine("aInt: " + aInt);

        long aLong = 9223372036854775807;
        Console.WriteLine("aLong: " + aLong);

        sbyte sByte = 127;
        Console.WriteLine("sByte: " + sByte);

        ushort uShort = 65535;
        Console.WriteLine("uShort: " + uShort);

        uint uInt = 4294967295;
        Console.WriteLine("uInt: " + uInt);

        ulong uLong = 0;
        Console.WriteLine("uLong: " + uLong);

        char aLetter = 'a';
        Console.WriteLine("aLetter: " + aLetter);

        string aString = "Welcome to the Variable Shop!";
        Console.WriteLine("aString: " + aString);

        double aDouble = 3.5623;
        Console.WriteLine("aDouble: " + aDouble);

        float aFloat = 3.5623f;
        Console.WriteLine("aFloat: " + aFloat);

        decimal aDecimal = 3.5623m;
        Console.WriteLine("aDecimal: " + aDecimal);

        bool aBool = true;
        Console.WriteLine("aBool: " + aBool);
    }
}
