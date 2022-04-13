using System;
using dd.Engine;
using System.Diagnostics;


namespace ddcon
{
    class Program
    {
        static void Main(string[] args)
        {
            dd.Engine.Game game = new Game();
             Debug.Write("Adding Players");
            Character c = new Character(game.dice);

            c.Name = "Sir Blobby#1";
            c.Strength = 15;
            

            game.Players.Add(c);

            c = new Character();
            c.Name = "Sir Kieron#2";
            game.Players.Add(c);


            game.RollInitiative();


            



            Console.WriteLine("Finished. ");
   
        }
    }
}
