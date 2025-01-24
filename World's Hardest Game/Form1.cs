using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World_s_Hardest_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;

        bool wPressed = false;
        bool sPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;
        bool active = true;

        int playerSpeed = 5;
        int BallSpeed = 10;

        Rectangle player1 = new Rectangle(120, 270, 15, 15);
        Rectangle downWall = new Rectangle(100, 300, 400, 5);
        Rectangle rightWall = new Rectangle(500, 105, 5, 200);
        Rectangle upWall = new Rectangle(150,55,400,5);
        Rectangle leftWall = new Rectangle(150, 55, 5, 200);
        Rectangle endWall = new Rectangle(550, 55, 5, 50);
        Rectangle endDownWall = new Rectangle(500,105,55,5);
        Rectangle startLeftWall = new Rectangle(100,250,5,50);
        Rectangle startUpWall = new Rectangle(100,250,50,5);
        Rectangle startZone = new Rectangle(105, 255, 50, 50);
        Rectangle endZone = new Rectangle(500, 55, 50, 50);
        Rectangle Ball = new Rectangle(200, 80, 10, 10);
        Rectangle Ball2 = new Rectangle(250, 80, 10, 10);

       
        Brush Blue = new SolidBrush(Color.Blue);
        Brush black = new SolidBrush(Color.Black);
        Brush green = new SolidBrush(Color.Green);

        List<Rectangle> balls = new List<Rectangle>();
        List<int> Speed = new List<int>();
        
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (active == true)
            {
                Active();
            }
            
            if (leftPressed == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (rightPressed == true && player1.X < 1000)
            {
                player1.X += playerSpeed;
            }
            if (upPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }
            if (downPressed == true && player1.Y < 1000)
            {
                player1.Y += playerSpeed;
            }
            Ball.Y = Ball.Y + BallSpeed;
            Ball2.Y = Ball2.Y + BallSpeed;
            if (Ball.Y < 55)
            {
                Ball.Y = 55;
            }
            for (int i = 0; i < balls.Count; i++)
            {
                if (Ball.IntersectsWith(upWall))
                {
                    Speed[0] = Speed[0] * -1;
                }
                if (Ball.IntersectsWith(downWall))
                {
                    Speed[0] = Speed[0] * -1;
                }
                if (Ball2.IntersectsWith(upWall))
                {
                    Speed[1] = Speed[1] * -1;
                }
                if (Ball2.IntersectsWith(downWall))
                {
                    Speed[1] = Speed[1] * -1;
                }
            }
            if (player1.IntersectsWith(downWall))
            {
                player1.Y = player1.Y - playerSpeed;
            }
            if (player1.IntersectsWith(rightWall))
            {
                player1.X = player1.X - playerSpeed;
            }
            if (player1.IntersectsWith(upWall))
            {
                player1.Y = player1.Y + playerSpeed;
            }
            if (player1.IntersectsWith(leftWall))
            {
                player1.X = player1.X + playerSpeed;
            }
            if (player1.IntersectsWith(endWall))
            {
                player1.X = player1.X - playerSpeed;
            }
            if (player1.IntersectsWith(endDownWall))
            {
                player1.Y = player1.Y - playerSpeed;
            }
            if (player1.IntersectsWith(startUpWall))
            {
                player1.Y = player1.Y + playerSpeed;
            }
            if (player1.IntersectsWith(startLeftWall))
            {
                player1.X = player1.X + playerSpeed;
            }
            if (player1.IntersectsWith(endZone))
            {
                label1.Text = "YOU HAVE WON";
            }
            
                balls.Add(Ball);
            
             for (int i = 0; i < balls.Count; i++)
            {
                
                if (player1.IntersectsWith(balls[i]))
                {
                    player1.X = 120;
                    player1.Y = 270;
                }
            }
                

                    Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(green, startZone);
            e.Graphics.FillRectangle(green, endZone);
            e.Graphics.FillRectangle(black, downWall);
            e.Graphics.FillRectangle(Blue, player1);
            e.Graphics.FillRectangle(black, upWall);
            e.Graphics.FillRectangle(black, rightWall);
            e.Graphics.FillRectangle(black, leftWall);
            e.Graphics.FillRectangle(black, endWall);
            e.Graphics.FillRectangle(black, endDownWall);
            e.Graphics.FillRectangle(black,startLeftWall);
            e.Graphics.FillRectangle(black,startUpWall);
            e.Graphics.FillRectangle(black, Ball);
            e.Graphics.FillRectangle(black, Ball2);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;

            }
        }
        public void Active()
        {
            balls.Add(Ball);
            balls.Add(Ball2);
            Speed.Add(BallSpeed);
            Speed.Add(BallSpeed);
            active = false;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            {
                // this checks what keys are pressed 
                switch (e.KeyCode)
                {
                    case Keys.W:
                        wPressed = true;
                        break;
                    case Keys.S:
                        sPressed = true;
                        break;
                    case Keys.Up:
                        upPressed = true;
                        break;
                    case Keys.Down:
                        downPressed = true;
                        break;
                    case Keys.Left:
                        leftPressed = true;
                        break;
                    case Keys.Right:
                        rightPressed = true;
                        break;
                    case Keys.A:
                        aPressed = true;
                        break;
                    case Keys.D:
                        dPressed = true;
                        break;
                }
            }
        }
    }
}
