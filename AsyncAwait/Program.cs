// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*int count = 0;
count = await Method3();
Method4(count);
Console.WriteLine($"**** value of count = { count}");

void UseTraditionalThreading()
{
    Thread t1 = new Thread(new ThreadStart(Method1));
    Thread t2 = new Thread(new ThreadStart(Method2));

    t1.Start();
    t2.Start();
    Thread.Sleep(1000);
}



void Method1()
{
    for(int i = 0; i < 1000; i++)
    {
        Console.WriteLine($"METHOD 1: i={i}");
    }
}

void Method2()
{
    for(int i=0;i<100;i++)
    {
        Console.WriteLine($"METHOD 2: i={i}");
    }
}

async Task<int> Method3()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"METHOD 3: i={i}");
    }
    return i;
}

async void Method4()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"METHOD 4: i={i}");
    }
}*/

await SimpleTask();
File.WriteAllText(@"SomeFile.txt", "blah blah blah");
string contents = await ReadFile();
Console.WriteLine(contents);

async Task SimpleTask()
{
    Console.WriteLine("starting of the task");
    await Task.Delay(1000); //force a delay
    Console.WriteLine("task Complete");
}

async Task<string> ReadFile()
{
    using (StreamReader r = new StreamReader(@"SomeFile.txt"))
    {
        return await r.ReadToEndAsync();
    }
}