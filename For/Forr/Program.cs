using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Selecione uma opção (a-j) ou 's' para sair:");
            Console.WriteLine("a) Exibir todos os números pares entre 0 e 100");
            Console.WriteLine("b) Pares entre 0 e um número informado");
            Console.WriteLine("c) Exibir cada letra de uma palavra em linha separada");
            Console.WriteLine("d) Soma de 1 até N");
            Console.WriteLine("e) Verificar se um número é primo");
            Console.WriteLine("f) Maior número de uma sequência");
            Console.WriteLine("g) Tabuada dos números de 5 até 10");
            Console.WriteLine("h) Exibir divisores de um número");
            Console.WriteLine("i) Exibir todos os números primos entre 1 e 100");
            Console.WriteLine("j) Soma dos números pares entre 1 e 100");
            Console.Write("Opção: ");
            var op = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrEmpty(op)) continue;
            if (op == "s") break;

            switch (op)
            {
                case "a": TaskA(); break;
                case "b": TaskB(); break;
                case "c": TaskC(); break;
                case "d": TaskD(); break;
                case "e": TaskE(); break;
                case "f": TaskF(); break;
                case "g": TaskG(); break;
                case "h": TaskH(); break;
                case "i": TaskI(); break;
                case "j": TaskJ(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine();
        }
    }

    static void TaskA()
    {
        for (int i = 0; i <= 100; i += 2)
            Console.WriteLine(i);
    }

    static void TaskB()
    {
        Console.Write("Digite um número inteiro positivo: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }
        for (int i = 0; i <= n; i += 2)
            Console.WriteLine(i);
    }

    static void TaskC()
    {
        Console.Write("Digite uma palavra: ");
        var s = Console.ReadLine() ?? string.Empty;
        foreach (var ch in s)
            Console.WriteLine(ch);
    }

    static void TaskD()
    {
        Console.Write("Digite um número inteiro positivo: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }
        long sum = 0;
        for (int i = 1; i <= n; i++) sum += i;
        Console.WriteLine($"Soma de 1 até {n} = {sum}");
    }

    static void TaskE()
    {
        Console.Write("Digite um número inteiro: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }
        if (IsPrime(n)) Console.WriteLine($"{n} é primo."); else Console.WriteLine($"{n} não é primo.");
    }

    static void TaskF()
    {
        Console.WriteLine("Digite uma sequência de números inteiros separados por espaço (ou enter no fim):");
        var line = Console.ReadLine() ?? string.Empty;
        var parts = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
        var nums = parts.Select(p => { int v; return int.TryParse(p, out v) ? (int?)v : null; }).Where(x => x.HasValue).Select(x => x!.Value).ToArray();
        if (nums.Length == 0)
        {
            Console.WriteLine("Nenhum número válido informado.");
            return;
        }
        Console.WriteLine($"Maior número: {nums.Max()}");
    }

    static void TaskG()
    {
        for (int n = 5; n <= 10; n++)
        {
            Console.WriteLine($"Tabuada do {n}:");
            for (int i = 1; i <= 10; i++)
                Console.WriteLine($"{n} x {i} = {n * i}");
            Console.WriteLine();
        }
    }

    static void TaskH()
    {
        Console.Write("Digite um número inteiro positivo: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }
        Console.WriteLine($"Divisores de {n}:");
        for (int i = 1; i <= n; i++) if (n % i == 0) Console.WriteLine(i);
    }

    static void TaskI()
    {
        for (int i = 2; i <= 100; i++) if (IsPrime(i)) Console.WriteLine(i);
    }

    static void TaskJ()
    {
        int sum = 0;
        for (int i = 1; i <= 100; i++) if (i % 2 == 0) sum += i;
        Console.WriteLine($"Soma dos pares entre 1 e 100 = {sum}");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0) return false;
        int r = (int)Math.Sqrt(n);
        for (int i = 3; i <= r; i += 2) if (n % i == 0) return false;
        return true;
    }
}
