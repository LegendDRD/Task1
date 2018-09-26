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
    public partial class Form1 : Form
    {
        MeleeUnit[] melee= new MeleeUnit[40]; // this delacres the size of the melee unit
        RangedUnit[] ranged = new RangedUnit[40];// this delcares the size of the ranged unit
        Button stopbtm = new Button();
        Button start = new Button();
        int currentTick = 0;
        bool ispaused = false;
        int x = 0;
        int y = 0;
        TextBox t = new TextBox();
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
           
            #region Stop button
            stopbtm = new Button();

                Point p = new Point(100, 0);


                stopbtm.Location = p;
                stopbtm.Width = 50;
                stopbtm.Height = 20;
                stopbtm.Text = "Stop";
                this.Controls.Add(stopbtm);

            
            stopbtm.Click += new EventHandler(button_Click);
            #endregion
            #region Start button

            start = new Button();

            Point p2 = new Point(150, 0);


            start.Location = p2;
            start.Width = 50;
            start.Height = 20;
            start.Text = "Start";
            this.Controls.Add(start);


            start.Click += new EventHandler(button_ClickStart1);
            #endregion
        }

        private void TimeTick_Tick(object sender, EventArgs e)
        {
           
            Map map = new Map(this);
            
            //melee[currentTick] = new MeleeUnit();
            //ranged[currentTick] = new RangedUnit();
           






            if (currentTick == 0)//makes a text box when the first tick starts
            {
                map.GeneratingMap(this);
                map.SpawnUnits(this);
                t = new TextBox();

                Point p = new Point(0, 0);

                t.ReadOnly = true;
                t.Location = p;
                t.Width = 100;
                t.Height = 50;
                this.Controls.Add(t);
            }

            if (ispaused == false)
            {
                //    if (melee[currentTick].combat()==false)
                //    {




                //    }
                //    if (melee[currentTick].combat() == true)
                //    {
                //        map.movement(x, y);
                //    }
                //    if (ranged[currentTick].combat() == false)
                //    {

                //        map.movement(x, y);


                //    }
                //    if (ranged[currentTick].combat() == true)
                //    {
                //        map.movement(x, y);
                //    }
                //    if (ranged[currentTick].rangeCal() <= 2)
                //    {
                //        map.movement(x, y);
                //    }
                //    if (melee[currentTick].Health <= 25)
                //    {
                //        map.movement(x, y);
                //    }
                //    if (ranged[currentTick].Health <= 25)
                //    {
                //        map.movement(x, y);
                //    }















                currentTick++;
            }
            t.Text = "Tick Timer: " + currentTick.ToString();// keeps adding to the ticker



        }

        public void button_Click(object sender, EventArgs args) //This button puases the whole game and timer
        {
            TimeTick.Stop();
            ispaused = true;
           
        }
        public void button_ClickStart1(object sender, EventArgs args) //This Starts the timer and the whole game
        {
            TimeTick.Start();
            ispaused = false;

        }

    }
    }
