using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dd.Engine
{
    public static class StaticDice
    {
        public static int Roll (int TypeOfDice, int NoDice, int Modifier)
        {
            Random rnd = new Random();
            int result = 0;
            for (int x=0; x < NoDice; x++)
            {
                result += rnd.Next(1, TypeOfDice);
            }
            return result + Modifier;
           
        }

        public static int Roll(int TypeOfDice, int NoDice)
        {
            return Roll(TypeOfDice, NoDice, 0);
        }

        public static int Roll(int TypeOfDice)
        {
            return Roll(TypeOfDice, 1, 0);
        }

    }
}
