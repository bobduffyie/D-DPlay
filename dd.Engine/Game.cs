using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace dd.Engine
{
    public  class Game
    {
        public int GameID = 1;
        public List<Character> Players = new List<Character> { };
        public Dice dice = new Dice();

        public Game()
        {
           
        }



        public void RollInitiative()
        {
            foreach (Character c in Players) 
            {
                int result = c.RollInitiative();

            }


        }


    }
}
