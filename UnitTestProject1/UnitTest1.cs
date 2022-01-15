using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using dd.Engine;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void StaticRollD6()
        {
            int maxRoll = 0;
            for (int x = 0; x < 100; x++)
            {
                int result = StaticDice.Roll(6, 1, 0);
                if (result > maxRoll) { maxRoll = result; }
                Console.WriteLine(result);
            }
            Assert.AreEqual(6, maxRoll);

        }


        [TestMethod]
        public void RollD6()
        {
            int maxRoll = 0;
            Dice dice = new Dice();
            for (int x = 0; x < 100; x++)
            {
                int result = dice.Roll(6, 1, 0);
                if (result > maxRoll) { maxRoll = result; }
                Console.WriteLine(result);
            }
            Assert.AreEqual(6, maxRoll);

        }



        [TestMethod]
        public void Character()
        {
            Character c = new Character();

            Console.WriteLine(c.Abilities.Values.Count);
            Console.WriteLine(c.Abilities[dd.Engine.Character.AbilityEnum.Strength].Name);


        }



        [TestMethod]
        public void Initiative()
        {
            Game game = new Game();
            /* Add 5 Players */
            for (int x = 0; x < 5; x++)
            {
                Character p = new Character(game.dice);
                p.Name = (x + 1).ToString();
                p.Number = x;
                game.Players.Add(p);
            }

            /* Roll Initiative */
            game.RollInitiative();

            /* Show Initiaitve for Each Player */
            foreach (Character p in game.Players)
            {
                Console.WriteLine(p.Initiative);
            }


            /* Can Also use a TupleList as per https://stackoverflow.com/questions/5716423/c-sharp-sortable-collection-which-allows-duplicate-keys */
            Console.WriteLine("Order Players by Initative Using Linq and IEnumerable");

            IEnumerable<Character> query = game.Players.OrderByDescending(x => x.Initiative);
            foreach (Character p in query)
            {
                Console.WriteLine(p.Number.ToString() + " Goes Next");
            }


            /* Manuallly Sort. Not recommended */
            Console.WriteLine("Sort Players Very Basic Way Sort. Very slow! ");
            int currentPlayer=0;
            int currentInitiative = 0;
            List<int> iList = new List<int> { };

            while (iList.Count < game.Players.Count)
            {
                currentInitiative = 0;
                for (int x = 0; x < game.Players.Count; x++)
                {
                    if (game.Players[x].Initiative > currentInitiative && (iList.Contains(x) ==false))
                    {
                        currentPlayer = x;
                        currentInitiative = game.Players[x].Initiative;
                    }
                }
                iList.Add(currentPlayer);
            }
            foreach(int x in iList)
            {
                Console.WriteLine(x.ToString() + " Goes Next");
            }



            /* By Using a Seperate Hashtable or Dictionary and OrderBy */
            Console.WriteLine("Using Dictionary or HashTable. Also uses Linq Extensions");
            Dictionary<int, int> initList = new Dictionary<int, int>();
            for (int x = 0; x < game.Players.Count; x++)
            {
                initList.Add(x, game.Players[x].Initiative);
            }
            foreach (KeyValuePair<int, int>player in initList.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine(player.Key.ToString() + " Goes Next");
            }
        }

    }
}
