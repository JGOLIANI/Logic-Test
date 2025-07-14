using logic_test;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Network net = new Network(8);

            net.Connect(1, 2);
            net.Connect(3, 5);
            net.Connect(5, 6);
            net.Connect(6, 7);

            Console.WriteLine(net.Query(1, 2));
            Console.WriteLine(net.Query(3, 7));
            Console.WriteLine(net.Query(5, 5));
            Console.WriteLine(net.Query(1, 3));
            Console.WriteLine(net.Query(5, 9));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
