// See https://aka.ms/new-console-template for more information

using System;
using System.Reflection.Metadata.Ecma335;

partial class Program
{
    // Declaration = new datatype
    delegate void Compute(int n1, int n2);
    delegate void Contractor(double budget);
    
    static void Main()
    {
        Action<string, bool> Work = new Action<string, bool>(
            (b, a) => Console.WriteLine($"{b} = {a}"));
            
        Work("coding in C#", true);

        Func<string, string> Print = (name) => $"my name is {name}";
        Console.WriteLine(Print("Bhavana"));

        Predicate<string> UpdateDb = new Predicate<string>((v) => {

            if (v == null) return true;
            else return false;
        });
        Console.WriteLine(UpdateDb(null));

    }

    

    private static void UsingGenericDelegates()
    {
        // ACTION Delegate
        Action<double> RajaRani = new Action<double>(
            (b) =>
            {
                Console.WriteLine($"arrangement fees = {b * 95 / 100}");
                Console.WriteLine($"Pandit fees = {b * 15 / 100}");
                Console.WriteLine($"catering = {b * 30 / 100}");
            });
        RajaRani += (s) => Console.WriteLine($"overall {s}");
        RajaRani(20000000);

        //FUNCTION Delegate
        Func<int, int, string> ModifiedCompute = (n1, n2) => $"add:{n1 + n2}";
        ModifiedCompute += (s, a) => $"sub = {s - a}";

        Console.WriteLine(ModifiedCompute(100, 200));

        //PREDICATE Delegate
        Predicate<int> anotherCompute = new Predicate<int>((v) =>
        {
            if (v == 0) return false;
            else return true;
        });
        Console.WriteLine(anotherCompute(1));
    }

    private static void Marriage()
    {
        Contractor RockyRaniMarriage = new Contractor((b) => Console.WriteLine($"Pandit Charges : {b * 20 / 100}"));
        RockyRaniMarriage += (a) => Console.WriteLine($"Catering Charges: {a * 50 / 100}");
        RockyRaniMarriage += (s) => Console.WriteLine($"mandapa decoration : {s * 5 / 100}");
        RockyRaniMarriage += (q) => Console.WriteLine($"Benz Car : {q * 15 / 100}");

        //invoke the delegate
        RockyRaniMarriage(100000000);
    }

    private static void UsingLambda()
    {
        //instantiation
        Compute objShortCompute = new Compute((a, b) => Console.WriteLine($"addition = {a + b}"));
        objShortCompute += (a, b) => Console.WriteLine($"subraction = {a - b}");
        objShortCompute += (s, t) => Console.WriteLine($"multiplication = {s * t}");
        objShortCompute += (o, p) => Console.WriteLine($"division = {o / p}");

        //Invocation
        objShortCompute(250, 5);
    }

    private static void DelegatesUsingLongCutMethod()
    {
        //instantiate
        Compute objCompute = new Compute(AddFn);

        objCompute += SubFn;
        objCompute += MulFn;
        objCompute += DivFn;

        //Invoke the delegate exactly like a function
        objCompute(100, 200);
    }

    static void AddFn(int n1, int n2)
    {
        Console.WriteLine($"Output of addition:{n1+n2}");
    }

    static void SubFn(int n1, int n2)
    {
        Console.WriteLine($"Output of subraction:{n1 - n2}");

    }

    static void MulFn(int n1, int n2)
    {
        Console.WriteLine($"Output of multiplication:{n1 * n2}");

    }
    static void DivFn(int n1, int n2)
    {
        Console.WriteLine($"Output of division:{n1 / n2}");

    }

}
