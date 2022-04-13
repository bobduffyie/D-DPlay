using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dd.Engine
{
    public class Dice
    {
        Random rnd;
        public Dice()
        {
            rnd = new Random();
        }

        public  int Roll (int TypeOfDice, int NoDice, int Modifier)
        {
            int result = 0;
            for (int x=0; x < NoDice; x++)
            {
                result += rnd.Next(1, TypeOfDice+1);
            }
            return result + Modifier;
           
        }

        public  int Roll(int TypeOfDice, int NoDice)
        {
            return Roll(TypeOfDice, NoDice, 0);
        }

        public  int Roll(int TypeOfDice)
        {
            return Roll(TypeOfDice, 1, 0);
        }


        public float RandomFloat()
        {
                return Convert.ToSingle(rnd.NextDouble() );
        }


    }
}
