using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETerm2
{
    class RangedUnit:Unit
    {


        public int xPos
        {
            get { return xpos; }
            set { xpos = value; }
        }

        

        public int yPos
        {
            get { return ypos; }
            set { ypos = value; }
        }

        

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        

        public int Attackrange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

       

        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }

        public override void combat(int attack)//this method is called when a unit is in combate with abouther unit
        {
            health = health -attack;// this will take the health of the enemy unit and subtract it by the enemies attack


            if (health < 0)
            {
                death(); // this will call the method to return a boolean when the unit is dead
            }

        }
        public override bool death()
        {
            bool death = true;
            return death;
        }
      

        public override void moveToNewPos(int x, int y)
        {
            xpos = xpos + x;
            ypos = ypos + y;

        }

        public override bool rangeCal(int distance, int range)
        {
            if (distance <= range)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public override Unit closestUnit(Unit[] unit)//this will check for the closest unit by using pythagours as it loops through all the units in the game.
        {
            Unit closest = this;
            int distance;

            for (int i = 0; i < 20; i++)
            {
                if (unit[i].GetType() == typeof(MeleeUnit))
                {
                    RangedUnit munit = (RangedUnit)unit[i];
                    if (munit.faction != "")
                    {



                    }
                }
            }

            return closest;
        }

        public override string toString()// this displays all the information about the unit
        {
            return "Faction: " + faction + "\r\nDamage: " + attack + "\r\nAttackRange: " + attackRange + "\r\nHealth: " + health + "\r\nSpeed: " + speed + "\r\nY postion: " + xpos + "\r\nX postion: " + ypos;
        }

    }
}
