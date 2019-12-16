using System;
using System.Collections.Generic;
using System.Linq;

namespace welcome_to_jurassic_park
{
  class Program
  {
    static DatabaseContext Db = new DatabaseContext();

    static void DisplayListOfDinos(IEnumerable<Dinosaurs> dinos)
    {
      Console.WriteLine("Here are all of the dinosaurs in Jurassic Park");
      Console.WriteLine("----------");
      foreach (var dino in dinos)
      {
        Console.WriteLine($"We have a {dino.Name}, which is a {dino.DietType}.");
        Console.WriteLine($"We got her on {dino.DateAcquired}. She weighs {dino.Weight}lbs and is in Enclosure {dino.EnclosureNumber}");
      }
    }
    static void DisplayAll()
    {
      DisplayListOfDinos(Db.Dinosaurs);
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
      DisplayListOfDinos(Db.Dinosaurs.OrderByDescending(dino => dino.Weight).Take(3));
    }
    static void UnknownCommand()
    {
      Console.WriteLine("I don't understand that, try another command.");
    }

    static void HatchDinosaur()
    {
      string[] names = { "Malcolm", "Muldoon", "Grant", "Ellie",
                          "Hammond", "Tim", "Lex", "Nedry",
                          "Dodgson", "Wu", "Arnold"};

      string[] diet = { "carnivore", "herbivore" };
      Console.WriteLine("The egg is incubating...");

      var dino = new Dinosaurs();
      Random random = new Random();
      dino.Name = names[random.Next(0, 10)];
      dino.DietType = diet[random.Next(0, 2)];
      dino.DateAcquired = DateTime.Now;
      dino.Weight = random.Next(0, 1000);
      dino.EnclosureNumber = 1;

      Console.WriteLine($"The newly hatched dinosaur is named {dino.Name}. She weighs {dino.Weight}lbs and is a {dino.DietType}!");

      Db.Dinosaurs.Add(dino);
      Db.SaveChanges();
    }
    static void ReleaseEnclosure()
    {
      Console.WriteLine("Which enclosure would you like to release?");
      var dinoEnclosureNumber = Console.ReadLine();
      var releaseDino = Db.Dinosaurs.FirstOrDefault(dino => dino.EnclosureNumber == int.Parse(dinoEnclosureNumber));
      releaseDino.EnclosureNumber = default;

      Db.SaveChanges();
    }

    static void NeedsASheep()
    {
      Console.WriteLine("Jurassic Park's lightest carnivore is:");
      DisplayListOfDinos(Db.Dinosaurs.OrderBy(dino => dino.DietType).ThenBy(dino => dino.Weight).Take(1));
      Db.SaveChanges();
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
        Console.WriteLine("Available Commands - |View|Add|Remove|Transfer|Heavy|Hatch|Sheep|Release|Diet|Quit|");
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
        else if (input == "release")
        {
          ReleaseEnclosure();
        }
        else if (input == "hatch")
        {
          HatchDinosaur();
        }
        else if (input == "sheep")
        {
          NeedsASheep();
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