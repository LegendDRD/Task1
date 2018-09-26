using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace POETerm2
{
    class Map
    {
        int c = 0;

        MeleeUnit[] melee = new MeleeUnit[40]; // This decleares the size of the melee unit array
        RangedUnit[] rangedUnit = new RangedUnit[40]; // This decleares the size of the range unit array
        TextBox t = new TextBox();
        int tracker=0;
        
        int count;
        Random r = new Random();
        Button[,] but = new Button[20,20];
        

        public Map(Form form) //This creates a text box when the class is called
        {
            t = new TextBox();

            Point p = new Point(700, 500);

            t.ReadOnly = true;
            t.Location = p;
            t.Width = 100;
            t.Height = 150;
            t.Multiline = true;
            
            form.Controls.Add(t);
        }

       public void GeneratingMap(Form form) //this generates the map with buttons
        {
            int Hor = 30;
            int ver = 30;
            
            
            
          
            int y =0;
            for (int x = 0; x < 20; x++) // this loops through 20 x postions and 20 y postions to create a 20 by 20 map of buttons
            {


                ver = 30;
                Hor = Hor + 30;
                for (y = 0; y < 20; y++)
                {
                    but[x, y] = new Button(); // this creates a button using the x and y postions
                    but[x, y].Size = new Size(30, 30);
                    but[x, y].Location = new Point(Hor, ver);
                    ver = ver + 30;
                    but[x, y].Text = "-";
                    form.Controls.Add(but[x, y]);
                    
                }
            }




        }
        public void SpawnUnits(Form form) // WHen this method is called it will spawn all the units with the button locations
        {
           
           
            
            bool chec = false;
            int randomunit;
            if (c==0) { 
            while (!chec)
            {
                melee[tracker] = new MeleeUnit();
                rangedUnit[tracker] = new RangedUnit();
                randomunit = r.Next(0, 2);

                int SpawnLocx = r.Next(1, 19);
                int SpawnLocy = r.Next(1, 19);
                    
                    but[SpawnLocx, SpawnLocy].ForeColor = Color.Red;
                    
                if (but[SpawnLocx, SpawnLocy].Text != "X" && but[SpawnLocx, SpawnLocy].Text != "}")
                {
                   
                    switch (randomunit) // THis switch will create a random melee unit and ranged unit on the red team.
                    {
                        case 0:

                            
                            melee[tracker].xPos = SpawnLocx; // This fills out all the imformation for each unit
                            melee[tracker].yPos = SpawnLocy;
                            melee[tracker].Attack = 10;
                            
                                melee[tracker].Attackrange = 1;
                            
                            melee[tracker].Faction = "Red";
                            melee[tracker].Health = 100;
                            melee[tracker].Speed = 1;
                            but[SpawnLocx, SpawnLocy].Text = "X";
                            but[SpawnLocx, SpawnLocy].Click += new EventHandler(button_Click);


                            break;
                        case 1:
                            

                            rangedUnit[tracker].xPos = SpawnLocx;
                            rangedUnit[tracker].yPos = SpawnLocy;
                            rangedUnit[tracker].Speed = 1;
                            rangedUnit[tracker].Health = 100;
                            rangedUnit[tracker].Faction = "Red";
                            rangedUnit[tracker].Attackrange = 3;
                            rangedUnit[tracker].Attack = 10;

                            but[SpawnLocx, SpawnLocy].Text = "}";
                            but[SpawnLocx, SpawnLocy].Click += new EventHandler(button_Click);
                            break;
                            
                    }



                    count++;
                    tracker++;
                }




                if (count == 10) // this will check if there are 10 units for the first team before it creates another 10 for the other team
                {
                    chec = true;
                }

            }
            chec = false;
            count = 0;
            while (!chec) // making a random blue unit
            {
                rangedUnit[tracker] = new RangedUnit();
                melee[tracker] = new MeleeUnit();



                int SpawnLocx = r.Next(1, 19);
                int SpawnLocy = r.Next(1, 19);
                    
                but[SpawnLocx, SpawnLocy].ForeColor = Color.Blue;

                

                    if (but[SpawnLocx, SpawnLocy].Text != "X" && but[SpawnLocx, SpawnLocy].Text != "}")
                    {
                        randomunit = r.Next(0, 2);
                        switch (randomunit)
                        {
                            case 0:

                                melee[tracker].xPos = SpawnLocx;
                                melee[tracker].yPos = SpawnLocy;
                                melee[tracker].Attack = 10;
                                melee[tracker].Attackrange = 1;
                                melee[tracker].Faction = "Blue";
                                melee[tracker].Health = 100;
                                melee[tracker].Speed = 1;

                                but[SpawnLocx, SpawnLocy].Text = "X";


                                but[SpawnLocx, SpawnLocy].Click += new EventHandler(button_Click);

                                break;
                            case 1:


                                rangedUnit[tracker].xPos = SpawnLocx;
                                rangedUnit[tracker].yPos = SpawnLocy;
                                rangedUnit[tracker].Speed = 1;
                                rangedUnit[tracker].Health = 100;
                                rangedUnit[tracker].Faction = "Blue";
                                rangedUnit[tracker].Attackrange = 3;
                                rangedUnit[tracker].Attack = 10;

                                but[SpawnLocx, SpawnLocy].Text = "}";

                                but[SpawnLocx, SpawnLocy].Click += new EventHandler(button_Click);
                                break;

                        }
                        count++;
                        tracker++;
                    }



                    if (count == 10)
                    {
                        chec = true;
                    }

                }
            }
            c++;
            
           

        }

     


        public void button_Click(object sender, EventArgs args)// finds the button clicked then finds the unit clicked on
        {
            
            int xp;
            xp =  ((((Button)sender).Location.X) /30) -2;
            int yp;
            yp = ((((Button)sender).Location.Y) / 30)-1;

            if (xp<=0)
            {
                xp = 0;
            }
            if (yp <= 0)
            {
                yp = 0;
            }

            for (int x =0;x<20;x++)
            {

                if (melee[x].xPos == xp && melee[x].yPos == yp)
                {

                    
                    t.Text = melee[x].toString();



                }
                else if(rangedUnit[x].xPos == xp && rangedUnit[x].yPos == yp) {

                   
                    t.Text = rangedUnit[x].toString();
                }

               
            }
          

        }

        public void movement(int x, int y)
        {


        }
        
    }
}
