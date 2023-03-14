using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGV_Local
{

    
    public class WSManager
    {
        
        //Variables de la Clase
        private int[,] WS = new int[10, 10];

        private readonly Random _random = new Random();
        private int iterations;
        private AGV myAGV= new AGV();
        //Constructores
        public  WSManager()
        {
            resetWS();
            iterations = 200;
        }
        public WSManager(int i)
        {
            resetWS();
            iterations = i;
        }

        public void newAgv()
        {
            
        }

        //Métodos y Accesores privados
        private void digWS(int mode)
        {
            switch (mode)
            { 
                case 0:
                    diggUntilY0();
                    break;
                case 1:
                    digWithIter(iterations);
                    break;
                case 2:
                    diggUntilX0();
                    break;
                default:
                    break;
            
            }
        }
        private void diggUntilX0()
        {
            int direction, x, y, xini, yini;
            xini = 9;
            yini = RandomNumber(0, 10);
            x = xini;
            y = yini;
            while (x > 0)
            {
                direction = RandomNumber(0, 4);
                switch (direction)
                {
                    case 0:
                        if (y > 0)
                        {
                            y = y - 1;
                        }
                        break;
                    case 1:
                        if (x < 9)
                        {
                            x = x + 1;
                        }
                        break;
                    case 2:
                        if (y < 9)
                        {
                            y = y + 1;
                        }
                        break;
                    case 3:
                        if (x > 0)
                        {
                            x = x - 1;
                        }
                        break;
                    default:
                        break;

                }
                WS[x, y] = 99;
            }
            
        }
        private void digWithIter(int iter)
        {
            int direction, x, y, xini, yini;
            xini = RandomNumber(0, 10);
            yini = RandomNumber(0, 10);
            x = xini;
            y = yini;
            for (iter = 0; iter < iterations; iter++)
            {
                direction = RandomNumber(0, 4);
                switch (direction)
                {
                    case 0:
                        if (y > 0)
                        {
                            y = y - 1;
                        }
                        break;
                    case 1:
                        if (x < 9)
                        {
                            x = x + 1;
                        }
                        break;
                    case 2:
                        if (y < 9)
                        {
                            y = y + 1;
                        }
                        break;
                    case 3:
                        if (x > 0)
                        {
                            x = x - 1;
                        }
                        break;
                    default:
                        break;

                }
                WS[x, y] = 99;
            }
        }
        private void diggUntilY0()
        {
            int direction, x, y, xini, yini;
            xini = RandomNumber(0, 10);
            yini = 9;
            x = xini;
            y = yini;
            while (y>0)
            {
                direction = RandomNumber(0, 4);
                switch (direction)
                {
                    case 0:
                        if (y > 0)
                        {
                            y = y - 1;
                        }
                        break;
                    case 1:
                        if (x < 9)
                        {
                            x = x + 1;
                        }
                        break;
                    case 2:
                        if (y < 9)
                        {
                            y = y + 1;
                        }
                        break;
                    case 3:
                        if (x > 0)
                        {
                            x = x - 1;
                        }
                        break;
                    default:
                        break;

                }
                WS[x, y] = 99;
            }
        }
        private void resetWS()
        {
            int i, j;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    WS[i, j] = 0;

                }
            }
        }
        private bool isFreeNorth()
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();

            if (AGVy > 0)
            {
                if (WS[AGVx, AGVy - 1] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeSouth()
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();

            if (AGVy < 9)
            {
                if (WS[AGVx, AGVy + 1] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeWest()
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();

            if (AGVx > 0)
            {
                if (WS[AGVx - 1, AGVy] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeEast()
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();

            if (AGVx < 9)
            {
                if (WS[AGVx + 1, AGVy] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeFront()
        {
            bool free = false;

            switch (myAGV.getOrientation())
            {
                case 0:
                    free = isFreeNorth();
                    break;
                case 1:
                    free = isFreeEast();
                    break;
                case 2:
                    free = isFreeSouth();
                    break;
                case 3:
                    free = isFreeWest();
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeLeft()
        {
            bool free = false;

            switch (myAGV.getOrientation())
            {
                case 0:
                    free = isFreeWest();
                    break;
                case 1:
                    free = isFreeNorth();
                    break;
                case 2:
                    free = isFreeEast();
                    break;
                case 3:
                    free = isFreeSouth();
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeRight()
        {
            bool free = false;

            switch (myAGV.getOrientation())
            {
                case 0:
                    free = isFreeEast();
                    break;
                case 1:
                    free = isFreeSouth();
                    break;
                case 2:
                    free = isFreeWest();
                    break;
                case 3:
                    free = isFreeNorth();
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeBack()
        {
            bool free = false;

            switch (myAGV.getOrientation())
            {
                case 0:
                    free = isFreeSouth();
                    break;
                case 1:
                    free = isFreeWest();
                    break;
                case 2:
                    free = isFreeNorth();
                    break;
                case 3:
                    free = isFreeEast();
                    break;
                default:
                    break;
            }
            return free;
        }


        //Métodos y Accesores públicos
        public void generateWS(int mode, int iter)
        {
            resetWS();
            digWS(mode);
        }
        public void MNorthAGV()
        {
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();


            if (isFreeNorth())
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx, AGVy - 1] = 1;
                myAGV.MovNorth();
            }
            
        }
        public void MSouthAGV()
        {
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();


            if (isFreeSouth())
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx, AGVy + 1] = 1;
                myAGV.MovSouth();
            }
            
        }
        public void MWestAGV()
        {
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();


            if (isFreeWest())
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx - 1, AGVy] = 1;
                myAGV.MovWest();
            }
            
        }
        public void MEastAGV()
        {
            int AGVx, AGVy;
            AGVx = myAGV.getPosX();
            AGVy = myAGV.getPosY();


            if (isFreeEast())
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx + 1, AGVy] = 1;
                myAGV.MovEast();
            }
            
        }
        public void MFwAGV()
        {
            switch (myAGV.getOrientation())
            {
                case 0:
                    MNorthAGV();
                    break;
                case 1:
                    MEastAGV();
                    break;
                case 2:
                    MSouthAGV();
                    break;
                case 3:
                    MWestAGV();
                    break;
                default:
                    break;
            }

        }
        public void MBwAGV()
        {
            switch (myAGV.getOrientation())
            {
                case 0:
                    MSouthAGV();
                    break;
                case 1:
                    MWestAGV();
                    break;
                case 2:
                    MNorthAGV();
                    break;
                case 3:
                    MEastAGV();
                    break;
                default:
                    break;
            }
        }
        public void RRAGV()
        {
            myAGV.RR();
            
        }
        public void RLAGV()
        {
            myAGV.RL();
            
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        } 
        public int getValue(int i, int j)
        {
            return WS[i, j];
        }
        public int getAGVPosX()
        {
            return myAGV.getPosX();
        }
        public int getAGVPosY()
        {
            return myAGV.getPosY();
        }
        public int getAGVOrient()
        {
            return myAGV.getOrientation();
        }


        public bool isBreakPossible()
        {
            bool breakable;
            breakable = false;
            if (isFreeFront() == false)
            {
                if (limitReached() == false)
                {
                    breakable = true;
                }
            }
            return breakable;
        }

        private bool limitReached()
        {
            bool onLimit;
            onLimit = false;
            if (myAGV.getFSensor() == 0)
            {
                switch (myAGV.getOrientation())
                {
                    case 0:
                        if (myAGV.getPosY() == 0)
                        {
                            onLimit = true;
                        }
                        break;
                    case 1:
                        if (myAGV.getPosX() == 9)
                        {
                            onLimit = true;
                        }
                        break;
                    case 2:
                        if (myAGV.getPosY() == 9)
                        {
                            onLimit = true;
                        }
                        break;
                    case 3:
                        if (myAGV.getPosX() == 0)
                        {
                            onLimit = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            return onLimit;
        }

        public void breakObstacle()
        {
            int targetX=0;
            int targetY=0;

            switch (myAGV.getOrientation())
            {
                case 0:
                    targetX = myAGV.getPosX();
                    targetY = myAGV.getPosY() - 1;
                    break;
                case 1:
                    targetX = myAGV.getPosX()+1;
                    targetY = myAGV.getPosY();
                    break;
                case 2:
                    targetX = myAGV.getPosX();
                    targetY = myAGV.getPosY() + 1;
                    break;
                case 3:
                    targetX = myAGV.getPosX()-1;
                    targetY = myAGV.getPosY();
                    break;
                default:
                    break;
            }

            if (WS[targetX, targetY] == 0)
            {
                WS[targetX, targetY] = 99;
            }
            
        }
    }
}

