// DONE add intro
// DONE add properties for each dino:
//      name
//      DietType = carnivore or herbivore
//      DateAcquired = Default
//      Weight = in lbs
//      EnclosureNumber = pen dino is in

// TODO store list of dinos in park
// TODO store dinos in List<Dinosaur>
// TODO let user view all dinos ordered by DateAcquired
// TODO let user add a new dino
// TODO let user remove a dino by name
// TODO let user transfer a dino to a new pen
// TODO view the 3 heaviest dinos
// TODO let user view how many dinos of each DietType
// TODO let user quit program

using System;
using System.Collections.Generic;
using System.Linq;

namespace welcome_to_jurassic_park
{
  class Program
  {
    // static List<Dinosaurs> Dinos = new List<Dinosaurs>();
    // Dinos.Add("velociraptor", "carnivore", );
    static void UnknownCommand()
    {
      Console.WriteLine("I don't understand that, try again");
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park!");
      var input = "";
      while (input != "quit")
      {
        Console.WriteLine("Would you like to take the tour?");
        Console.WriteLine("Available Commands |yes|view|search|update| delete|quit|");
        input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
          //   StartTour();
        }
        else if (input == "view")
        {
          //   ViewAllDinos();
        }
        else if (input == "search")
        {
          //   SearchAllDinos();
        }
        else if (input == "update")
        {
          //   UpdateDinoList();
        }
        else if (input == "delete")
        {
          //   DeleteDinoFromList();
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