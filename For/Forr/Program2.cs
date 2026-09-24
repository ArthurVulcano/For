using System;

public class Program2
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite um número inteiro:");
        int numero = int.Parse(Console.ReadLine());

        for (int i = 0; i <= numero; i += 2)
        {
           Console.WriteLine(i);
        }

    }
}