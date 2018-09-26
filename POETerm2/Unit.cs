using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETerm2
{
    abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected string faction;
        // priavte string image

       
        abstract public void moveToNewPos(int x, int y);
        abstract public void combat(int atack);
        abstract public bool rangeCal( int distance, int range);
        abstract public Unit closestUnit(Unit[] unit);
        abstract public bool death();
        abstract public string toString();

        
    }
}
