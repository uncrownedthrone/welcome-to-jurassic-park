// DONE add intro
// DONE add properties for each dino:
//      Name
//      DietType = carnivore or herbivore
//      DateAcquired = Default
//      Weight = in lbs
//      EnclosureNumber = pen dino is in
// DONE let user quit program
// DONE store list of dinos in park
// DONE store dinos in List<Dinosaur>
// TODO let user view all dinos in park

// TODO let user view all dinos ordered by DateAcquired
// TODO let user add a new dino
// TODO let user remove a dino by name
// TODO let user transfer a dino to a new pen
// TODO view the 3 heaviest dinos
// TODO let user view how many dinos of each DietType

using System;
using System.Collections.Generic;
using System.Linq;

namespace welcome_to_jurassic_park
{
  class Program
  {

    static List<Dinosaurs> AllDinosaurs = new List<Dinosaurs>();
    static void StartTour()
    {
      Console.WriteLine("StartTour selected");
    }

    static void SeedPark()
    {
      AllDinosaurs.AddRange(new List<Dinosaurs> {
        new Dinosaurs {
        Name = "Velociraptor",
        DietType = "Carnivore",
        DateAcquired = DateTime.Now,
        Weight = 40,
        EnclosureNumber = 1
      },
        new Dinosaurs {
        Name = "Brontosaurus",
        DietType = "Herbivore",
        DateAcquired = DateTime.Now,
        Weight = 30,
        EnclosureNumber = 2
      },
        new Dinosaurs {
        Name = "T-Rex",
        DietType = "Carnivore",
        DateAcquired = DateTime.Now,
        Weight = 20,
        EnclosureNumber = 3
      },
        new Dinosaurs {
        Name = "Triceratops",
        DietType = "Carnivore",
        DateAcquired = DateTime.Now,
        Weight = 10,
        EnclosureNumber = 4
      }
      });
    }

    static void ViewAllDinos(IEnumerable<Dinosaurs> AllDinosaurs)
    {
      Console.WriteLine("Here are all of the dinosaurs in Jurassic Park");
      Console.WriteLine("----------");
      foreach (var Dino in AllDinosaurs)
      {
        Console.WriteLine($"We have a {Dino.Name}, which is a {Dino.DietType}.");
        Console.WriteLine($"We got her on {Dino.DateAcquired}. She weighs {Dino.Weight} and is in Enclosure {Dino.EnclosureNumber}");
      }
    }

    static void DisplayAll()
    {
      ViewAllDinos(AllDinosaurs);
    }

    static void AddDinosaur()
    {
      Console.WriteLine("AddDinosaur was selected");
    }

    static void SearchAllDinos()
    {
      Console.WriteLine("SearchAllDinos selected");
    }

    static void UpdateDinoList()
    {
      Console.WriteLine("UpdateDinoList selected");
    }

    static void DeleteDinoFromList()
    {
      Console.WriteLine("DeleteDinoFromList selected");
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
      SeedPark();
      Console.WriteLine("Welcome to Jurassic Park!");
      var input = "";
      while (input != "quit")
      {
        Console.WriteLine("Would you like to take the tour?");
        Console.WriteLine("Commands |yes|view|search|update|delete|quit|");
        input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
          StartTour();
        }
        else if (input == "view")
        {
          DisplayAll();
        }
        else if (input == "add")
        {
          AddDinosaur();
        }
        else if (input == "search")
        {
          // SearchAllDinos();
        }
        else if (input == "update")
        {
          // UpdateDinoList();
        }
        else if (input == "delete")
        {
          // DeleteDinoFromList();
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

// Console.WriteLine("Hold onto your butts.");