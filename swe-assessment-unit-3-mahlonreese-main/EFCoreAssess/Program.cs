// Un-comment the lines below to test your code by hand.

Console.WriteLine(Queries.Query1());

Console.WriteLine(Queries.Query2());

OutputList(Queries.Query3());

OutputList(Queries.Query4());

OutputList(Queries.Query5());

OutputList(Queries.Query6());

OutputList(Queries.Query7());

OutputList(Queries.Query8());

Queries.PrintHumansAndAnimals();

OutputList(Queries.GetHumansByAnimalSpecies("dog"));


Thread.Sleep(new TimeSpan(0, 0, 30));

static void OutputList<T>(List<T> list)
{
    Console.WriteLine("[");
    foreach (var item in list)
    {
        Console.WriteLine($"{item},");
    }
    Console.WriteLine("]");
}