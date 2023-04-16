namespace HelloWorld;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Two of everything.
        int i1, i2;
        string s1, s2;
        int[] a1, a2;

         // Assign a value to the first.
        i1 = 2;
        s1 = "Hello";
        a1 = new int[] { 1, 2, 4 };

        // Copy to the second.
        i2 = i1;
        s2 = s1;
        a2 = a1;

         // Make changes.
        i2 = 4;
        a2[0] = -1;
        s2 = "Bird";

        Console.WriteLine(a1[0]);
        Console.WriteLine(s1);
    }
}
