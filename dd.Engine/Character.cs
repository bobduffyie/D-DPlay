using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace dd.Engine
{
    public class Character 
    {
        public Character()
        {
            Dice = new Dice();
            foreach (AbilityEnum ae in (AbilityEnum[])Enum.GetValues(typeof(AbilityEnum)))
            {
                Ability a = new Ability();
                a.Name = ae.ToString();
                Abilities.Add(ae, a);
            }
        }

        public Character(Dice BaseDice)
        {
            Dice = BaseDice;
            foreach (AbilityEnum ae in (AbilityEnum[])Enum.GetValues(typeof(AbilityEnum)))
            {
                Ability a = new Ability();
                a.Name = ae.ToString();
                Abilities.Add(ae, a);
            }


        }

        public Dice Dice; /* Could also be private */
        public string Name { get; set; }
        public int Number { get; set; }
        public int Height { get; set; } /* Hieght in cm */
        public int Age { get; set; }    /* Age in Years */
        public int HP { get; set; }
        public int MaxHP { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution{ get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int Initiative = 0;

        /* https://www.tutorialsteacher.com/csharp/csharp-hashtable */
        /* Sample Dictionary Object,. Similar to Hash and KeyNamePair*/
        public Dictionary<AbilityEnum, Ability> Abilities = new Dictionary<AbilityEnum, Ability>();

        /*public Hashtable Abilities2 = new Hashtable();*/

       
        public enum AbilityEnum
        {
            Strength =0,
            Dexterity=1,
            Constitution=2,
            Intelligence=3,
            Wisdom=4,
            Charisma=5
        }          



        public int RollInitiative()
        {
            int result;
            int dexModifier = Abilities[AbilityEnum.Dexterity].Modifier;

            result = Dice.Roll(20,1,dexModifier);
            Initiative = result;
            return result;
        }


    }
}



