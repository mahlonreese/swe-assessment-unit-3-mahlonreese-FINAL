using Microsoft.EntityFrameworkCore;

public class Queries
{
    /// Get the human with the primary key 2
    public static Human? Query1()
    {
        using (var context = new AssessDbContext())
        {
            var human = context.Humans.FirstOrDefault(h => h.HumanId == 2);
            //var human = context.Humans.First();
            return human;
        }
    }

    /// Get the first animal whose species is "fish"
    public static Animal? Query2()
    {
        using (var context = new AssessDbContext())
        {
            var animal = context.Animals
                .FirstOrDefault(animal => animal.AnimalSpecies == "fish");

            return animal;
        }
    }

    /// Get all the animals who belong to the human with primary key 5
    public static List<Animal> Query3()
    {
        using (var context = new AssessDbContext())
        {
            var animals = context.Animals
                .Where(animals => animals.HumanId == 5)
                .ToList();

            return animals;
        }

    }

    /// Get all animals born in a year greater than (but not equal to) 2015
    public static List<Animal> Query4()
    {
        using (var context = new AssessDbContext())
        {
            var animals = context.Animals
                .Where(animals => animals.BirthYear > 2015)
                .ToList();

            return animals;
        }
        

    }

    /// Get all the humans with first names that start with "J"
    public static List<Human> Query5()
    {
        using (var context = new AssessDbContext())
        {
            var humans = context.Humans
                .Where(h => h.FirstName.StartsWith("J"))
                .ToList();

            return humans;
        }
    }

    /// Get all the animals who don't have a birth year
    public static List<Animal> Query6()
    {
        using (var context = new AssessDbContext())
        {
            var animals = context.Animals
                .Where(animals => animals.BirthYear == null)
                .ToList();

            return animals;
        }
    }

    /// Get all the animals with species "fish" OR "rabbit"
    public static List<Animal> Query7()
    {
        using (var context = new AssessDbContext())
        {
            var animals = context.Animals
                .Where(a => a.AnimalSpecies == "fish" || a.AnimalSpecies == "rabbit")
                .ToList();

            return animals;
        }

    }

    /// Get all the humans who don't have an email address that contains "gmail"
    public static List<Human> Query8()
    {
        using (var context = new AssessDbContext())
        {
            var humans = context.Humans
                .Where(h => !h.Email.Contains("gmail"))
                .ToList();

            return humans;
        }
    }

    /// Print a directory of humans and their animals
    public static void PrintHumansAndAnimals()
    {
        using (var context = new AssessDbContext())
        {
            var humanAnimals = context.Humans
                .Include(h =>  h.Animal)
                .ToList();

            foreach (var human in humanAnimals)
            {
                Console.WriteLine($"{human.FirstName} {human.LastName}");

                if(human.Animal != null && human.Animal.Any())
                {
                    
                    foreach(var animal in human.Animal)
                    {
                        Console.WriteLine($" - {animal.Name}, {animal.AnimalSpecies}");
                    }
                }

            }
        }
            

    }

    /// Return a list of humans who have animals of a certain species
    public static List<Human> GetHumansByAnimalSpecies(string species)
    {
        using (var context = new AssessDbContext())
        {
            var animalSpecies = context.Humans
                .Where(a => a.Animal.Any(a => a.AnimalSpecies == species))
                .Select(a => new Human{  HumanId = a.HumanId, FirstName = a.FirstName })
                .ToList();
                
            
            return animalSpecies;
        }
             
    }
}