using System;
using System.Collections.Generic;
using System.Linq;

namespace welcome_to_jurassic_park
{
  class Program
  {

    // static List<Dinosaurs> AllDinosaurs = new List<Dinosaurs>();
    static DatabaseContext Db = new DatabaseContext();

    // static void SeedPark()
    // {
    //   AllDinosaurs.AddRange(new List<Dinosaurs> {
    //     new Dinosaurs {
    //     Name = "Velociraptor",
    //     DietType = "carnivore",
    //     DateAcquired = DateTime.Parse("12/2/1990"),
    //     Weight = 400,
    //     EnclosureNumber = 1
    //   },
    //     new Dinosaurs {
    //     Name = "Brontosaurus",
    //     DietType = "herbivore",
    //     DateAcquired = DateTime.Parse("12/1/2018"),
    //     Weight = 300,
    //     EnclosureNumber = 2
    //   },
    //     new Dinosaurs {
    //     Name = "T-Rex",
    //     DietType = "carnivore",
    //     DateAcquired = DateTime.Parse("12/2/2019"),
    //     Weight = 200,
    //     EnclosureNumber = 3
    //   },
    //     new Dinosaurs {
    //     Name = "Triceratops",
    //     DietType = "herbivore",
    //     DateAcquired = DateTime.Parse("12/3/2000"),
    //     Weight = 100,
    //     EnclosureNumber = 4
    //   }
    //   });

    static void ViewAllDinos(IEnumerable<Dinosaurs> AllDinosaurs)
    {
      Console.WriteLine("Here are all of the dinosaurs in Jurassic Park");
      Console.WriteLine("----------");
      foreach (var Dino in AllDinosaurs.OrderBy(dino => dino.DateAcquired))
      {
        Console.WriteLine($"We have a {Dino.Name}, which is a {Dino.DietType}.");
        Console.WriteLine($"We got her on {Dino.DateAcquired}. She weighs {Dino.Weight}lbs and is in Enclosure {Dino.EnclosureNumber}");
      }
    }
    static void DisplayAll()
    {
      ViewAllDinos(Db.Dinosaurs);
    }
    static void AddDinosaur()
    {
      Console.WriteLine("What type of dinosaur are you adding?");
      var dinoName = Console.ReadLine();
      Console.WriteLine($"Is {dinoName} a carnivore or herbivore?");
      var dinoDietType = Console.ReadLine();
      Console.WriteLine($"How many pounds does {dinoName} weigh?");
      var dinoWeight = Console.ReadLine();
      Console.WriteLine($"What enclosure will {dinoName} be in: 1, 2, 3, 4");
      var dinoEnclosureNumber = Console.ReadLine();

      var dino = new Dinosaurs();
      dino.Name = dinoName;
      dino.DietType = dinoDietType;
      dino.DateAcquired = DateTime.Now;
      dino.Weight = int.Parse(dinoWeight);
      dino.EnclosureNumber = int.Parse(dinoEnclosureNumber);

      Db.Dinosaurs.Add(dino);
      Db.SaveChanges();
    }
    static void RemoveDinoFromList()
    {
      Console.WriteLine("What is the name of the dinosaur you want to remove?");
      var dinoName = Console.ReadLine();
      var removeDino = Db.Dinosaurs.FirstOrDefault(dino => dino.Name == dinoName);
      if (removeDino != null)
      {
        Db.Dinosaurs.Remove(removeDino);
        Db.SaveChanges();
      }
    }
    static void TransferDinoPen()
    {
      Console.WriteLine("What's the name of the dinosaur you want to move?");
      var dinoName = Console.ReadLine();
      Console.WriteLine($"Which enclosure (1, 2, 3, or 4) would you like to put {dinoName} in?");
      var dinoEnclosure = Console.ReadLine();
      var transferDino = Db.Dinosaurs.FirstOrDefault(dino => dino.Name.ToLower() == dinoName.ToLower());
      transferDino.EnclosureNumber = int.Parse(dinoEnclosure);
      Db.SaveChanges();
    }
    static void GetDinoDiets()
    {

      Console.WriteLine("Which diet (carnivore/herbivore) would you like a summary of?");
      var dinoDietType = Console.ReadLine();
      var dinoDiets = Db.Dinosaurs.Count(dino => dino.DietType == dinoDietType);
      Console.WriteLine($"We have {dinoDiets} {dinoDietType}s");
    }
    static void GetHeavyDinos()
    {
      Console.WriteLine("These are the three heaviest dinosaurs.");
      ViewAllDinos(Db.Dinosaurs.OrderByDescending(dino => dino.Weight).Take(3));
    }
    static void UnknownCommand()
    {
      Console.WriteLine("I don't understand that, try another command.");
    }
    static void QuitProgram()
    {
      Console.WriteLine("You survived? I'm impressed. No idea when the helicopter is coming though...");
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park! Hold onto your butts.");
      Console.WriteLine("               __");
      Console.WriteLine("              / _)");
      Console.WriteLine("       .-^^^-/ /");
      Console.WriteLine("    __/       /");
      Console.WriteLine("   <__.|_|-|_|");
      Console.WriteLine("                   ");
      var input = "";
      while (input != "quit")
      {
        Console.WriteLine("Available Commands - |View|Add|Remove|Transfer|Heavy|Diet|Quit|");
        input = Console.ReadLine().ToLower();
        if (input == "view")
        {
          DisplayAll();
        }
        else if (input == "add")
        {
          AddDinosaur();
        }
        else if (input == "remove")
        {
          RemoveDinoFromList();
        }
        else if (input == "transfer")
        {
          TransferDinoPen();
        }
        else if (input == "diet")
        {
          GetDinoDiets();
        }
        else if (input == "heavy")
        {
          GetHeavyDinos();
        }
        else if (input == "quit")
        {
          QuitProgram();
        }
        else
        {
          UnknownCommand();
        }
      }
    }
  }
}