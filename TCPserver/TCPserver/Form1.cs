using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TCPserver;

namespace TCPserver
{
    public partial class Form1 : Form
    {
        // Objects
        private Graphics blackBoard;
        private WSManager myWS;
        private TrajectoryManager myTrManager;
        private TCPServerComManager myTCPserverComManager;
        private readonly Random _random = new Random();

        // Class variables
        private int WSSizeX;
        private int WSSizeY;

        // Constructor
        public Form1()
        {
            InitializeComponent();

            myWS = new WSManager(80);
            myTrManager = new TrajectoryManager();
            myTCPserverComManager = new TCPServerComManager();

            blackBoard = panelWS.CreateGraphics();

            WSSizeX = 10;
            WSSizeY = 10;
            this.Width = 440;
            this.Height = 480;
        }

        // Controls
        private void Orders(object sender, CommandEventArgs e)
        {
            string txt;
            txt = e.Command;
            switch (txt)
            {
                
            }
        }


        // Random num  
        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Draw functions and methods
        private void refreshAll()
        {
            refreshWS();
        }
        private void refreshWS()
        {
            clearWS();
            fillWS();
        }

        private void fillWS()
        {

            int i, j, incX, incY;


            incX = panelWS.Size.Width / WSSizeX;
            incY = panelWS.Size.Height / WSSizeY;

            for (i = 0; i < WSSizeX; i++)
            {
                for (j = 0; j < WSSizeY; j++)
                {
                    switch (myWS.getValue(i, j))
                    {
                        case 0:
                            drawObstacle(i, j);
                            break;
                        case 1:
                            drawAGV(i, j, myWS.getAGVOrient());
                            break;
                        default:
                            break;
                    }

                }

            }

        }
        private void drawAGV(int i, int j, int o)
        {
            int incX, incY, drawOffset;


            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();

            Point[] AGVPoints = { p1, p2, p3 };

            incX = panelWS.Size.Width / WSSizeX;
            incY = panelWS.Size.Height / WSSizeY;
            drawOffset = 5;
            switch (o)
            {
                case 0:
                    AGVPoints[0] = new Point(incX * i + incX / 2, incY * j + drawOffset);
                    AGVPoints[1] = new Point(incX * i - drawOffset + incX, incY * j + incY - drawOffset);
                    AGVPoints[2] = new Point(incX * i + drawOffset, incY * j + incY - drawOffset);
                    break;
                case 1:
                    AGVPoints[0] = new Point(incX * i + drawOffset, incY * j + drawOffset);
                    AGVPoints[1] = new Point(incX * i - drawOffset + incX, incY * j + incY / 2);
                    AGVPoints[2] = new Point(incX * i + drawOffset, incY * j + incY - drawOffset);
                    break;
                case 2:
                    AGVPoints[0] = new Point(incX * i + drawOffset, incY * j + drawOffset);
                    AGVPoints[1] = new Point(incX * i + incX - drawOffset, incY * j + drawOffset);
                    AGVPoints[2] = new Point(incX * i + incX / 2, incY * j + incY - drawOffset);
                    break;
                case 3:
                    AGVPoints[0] = new Point(incX * i + drawOffset, incY * j + incY / 2);
                    AGVPoints[1] = new Point(incX * i + incX - drawOffset, incY * j + drawOffset);
                    AGVPoints[2] = new Point(incX * i - drawOffset + incX, incY * j + incY - drawOffset);
                    break;
                default:
                    break;

            }

            blackBoard.FillPolygon(new SolidBrush(Color.WhiteSmoke), AGVPoints);
        }
        private void drawObstacle(int i, int j)
        {
            int incX, incY, drawOffset;


            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();
            Point p4 = new Point();

            Point[] obstaclePoints = { p1, p2, p3, p4 };

            incX = panelWS.Size.Width / WSSizeX;
            incY = panelWS.Size.Height / WSSizeY;
            drawOffset = 5;

            obstaclePoints[0] = new Point(incX * i + drawOffset, incY * j + drawOffset);
            obstaclePoints[1] = new Point(incX * i + incX - drawOffset, incY * j + drawOffset);
            obstaclePoints[2] = new Point(incX * i - drawOffset + incX, incY * j + incY - drawOffset);
            obstaclePoints[3] = new Point(incX * i + drawOffset, incY * j + incY - drawOffset);


            blackBoard.FillPolygon(new SolidBrush(Color.Red), obstaclePoints);
        }

        private void clearWS()
        {

            int i, j, incX, incY;

            Pen linePen = new Pen(Color.White);
            Point lineHIn = new Point();
            Point lineHEnd = new Point();
            Point lineVIn = new Point();
            Point lineVEnd = new Point();

            incX = panelWS.Size.Width / WSSizeX;
            incY = panelWS.Size.Height / WSSizeY;

            blackBoard.Clear(Color.DarkSlateBlue);

            lineHIn.X = 0;
            lineHEnd.X = panelWS.Size.Width;
            lineVIn.Y = 0;
            lineVEnd.Y = panelWS.Size.Height;

            for (i = 0; i < (WSSizeX); i++)
            {
                lineHIn.Y = i * incY;
                lineHEnd.Y = i * incY;

                blackBoard.DrawLine(linePen, lineHIn, lineHEnd);
            }

            for (j = 0; j < (WSSizeY); j++)
            {

                lineVIn.X = j * incX;
                lineVEnd.X = j * incX;

                blackBoard.DrawLine(linePen, lineVIn, lineVEnd);

            }

        }

        // Events
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshAll();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            clearWS();
        }


    }
}
