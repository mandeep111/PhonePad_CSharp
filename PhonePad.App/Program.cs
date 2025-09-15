using System;
using Net.Turing.Phone;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePadUtility.Process("33#"));                // E
        Console.WriteLine(OldPhonePadUtility.Process("227*#"));              // B
        Console.WriteLine(OldPhonePadUtility.Process("4433555 555666#"));    // HELLO
        Console.WriteLine(OldPhonePadUtility.Process("8 88777444666*664#")); // TURING
    }
}
