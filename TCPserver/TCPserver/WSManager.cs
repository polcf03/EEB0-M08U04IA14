using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace TCPserver
{
    public class WSManager
    {
        // Objects
        private readonly Random _random = new Random();

        // Class variables
        private int[,] WS = new int[10, 10];
        private int iterations;
        private AGV[] AGVlist = new AGV[10]{ new AGV(), new AGV(), new AGV() ,new AGV() ,new AGV() ,new AGV() ,new AGV(), new AGV(), new AGV(),new AGV()  }; 

        // Constructors
        public WSManager()
        {
            resetWS();
            iterations = 200;
        }
        public WSManager(int i)
        {
            resetWS();
            iterations = i;
        }

        public void newAgv(int AgvRef)
        {
            int x, y;
            do
            {
                x = RandomNumber(0, 10);
                y = RandomNumber(0, 10);
                if (WS[ x, y] == 99)
                {
                    WS[x,y] = AgvRef;
                    AGVlist[AgvRef - 1].setId(AgvRef);
                    AGVlist[AgvRef - 1].setPosX(x);
                    AGVlist[AgvRef - 1].setPosY(y);
                    AGVlist[AgvRef - 1].setOrient(RandomNumber(0, 4));
                }
            }
            while (WS[x, y] == 0);
        }
        public void removeAgv(int AgvRef)
        {
            int a = 0;
            WS[AGVlist[AgvRef - 1].getPosX(), AGVlist[AgvRef - 1].getPosY()] = 99;
            AGVlist[AgvRef - 1].setId(a);
            AGVlist[AgvRef - 1].setPosX(a);
            AGVlist[AgvRef - 1].setPosY(a);
            AGVlist[AgvRef - 1].setOrient(a);
        }
        public void removeallAgvs()
        {
            foreach( AGV i in AGVlist)
            {
                int a = 0;
                WS[i.getPosX(), i.getPosY()] = 99;
                i.setId(a);
                i.setPosX(a);
                i.setPosY(a);
                i.setOrient(a);
            }
        }

        // Private methods
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
            while (y > 0)
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
        public void resetWS()
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

        // Private access 
        private bool isFreeNorth(AGV AGVtomove)
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = AGVtomove.getPosX();
            AGVy = AGVtomove.getPosY();

            if (AGVy > 0)
            {
                if (WS[AGVx, AGVy - 1] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeSouth(AGV AGVtomove)
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = AGVtomove.getPosX();
            AGVy = AGVtomove.getPosY();

            if (AGVy < 9)
            {
                if (WS[AGVx, AGVy + 1] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeWest(AGV AGVtomove)
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = AGVtomove.getPosX();
            AGVy = AGVtomove.getPosY();

            if (AGVx > 0)
            {
                if (WS[AGVx - 1, AGVy] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeEast(AGV AGVtomove)
        {
            bool free = false;
            int AGVx, AGVy;
            AGVx = AGVtomove.getPosX();
            AGVy = AGVtomove.getPosY();

            if (AGVx < 9)
            {
                if (WS[AGVx + 1, AGVy] == 99)
                {
                    free = true;
                }
            }

            return free;
        }
        private bool isFreeFront(AGV Agvtomove)
        {
            bool free = false;

            switch (Agvtomove.getOrientation())
            {
                case 0:
                    free = isFreeNorth(Agvtomove);
                    break;
                case 1:
                    free = isFreeEast(Agvtomove);
                    break;
                case 2:
                    free = isFreeSouth(Agvtomove);
                    break;
                case 3:
                    free = isFreeWest(Agvtomove);
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeLeft(int Agvref)
        {
            bool free = false;
            AGV Agvtomove = AGVlist[Agvref - 1];
            switch (Agvtomove.getOrientation())
            {
                case 0:
                    free = isFreeWest(Agvtomove);
                    break;
                case 1:
                    free = isFreeNorth(Agvtomove);
                    break;
                case 2:
                    free = isFreeEast(Agvtomove);
                    break;
                case 3:
                    free = isFreeSouth(Agvtomove);
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeRight(int Agvref)
        {
            bool free = false;
            AGV Agvtomove = AGVlist[Agvref - 1];
            switch (Agvtomove.getOrientation())
            {
                case 0:
                    free = isFreeEast(Agvtomove);
                    break;
                case 1:
                    free = isFreeSouth(Agvtomove);
                    break;
                case 2:
                    free = isFreeWest(Agvtomove);
                    break;
                case 3:
                    free = isFreeNorth(Agvtomove);
                    break;
                default:
                    break;
            }
            return free;
        }
        private bool isFreeBack(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            bool free = false;

            switch (Agvtomove.getOrientation())
            {
                case 0:
                    free = isFreeSouth(Agvtomove);
                    break;
                case 1:
                    free = isFreeWest(Agvtomove);
                    break;
                case 2:
                    free = isFreeNorth(Agvtomove);
                    break;
                case 3:
                    free = isFreeEast(Agvtomove);
                    break;
                default:
                    break;
            }
            return free;
        }


        // Public methods
        public void generateWS(int mode, int iter)
        {
            resetWS();
            digWS(mode);
        }
        public void MNorthAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref-1];
            int AGVx, AGVy;
            AGVx = Agvtomove.getPosX();
            AGVy = Agvtomove.getPosY();


            if (isFreeNorth(Agvtomove))
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx, AGVy - 1] = Agvref;
                Agvtomove.MovNorth();
            }

        }
        public void MSouthAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            int AGVx, AGVy;
            AGVx = Agvtomove.getPosX();
            AGVy = Agvtomove.getPosY();


            if (isFreeSouth(Agvtomove))
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx, AGVy + 1] = Agvref;
                Agvtomove.MovSouth();
            }

        }
        public void MWestAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            int AGVx, AGVy;
            AGVx = Agvtomove.getPosX();
            AGVy = Agvtomove.getPosY();


            if (isFreeWest(Agvtomove))
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx - 1, AGVy] = Agvref;
                Agvtomove.MovWest();
            }

        }
        public void MEastAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            int AGVx, AGVy;
            AGVx = Agvtomove.getPosX();
            AGVy = Agvtomove.getPosY();


            if (isFreeEast(Agvtomove))
            {
                WS[AGVx, AGVy] = 99;
                WS[AGVx + 1, AGVy] = Agvref;
                Agvtomove.MovEast();
            }

        }
        public void MFwAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            switch (Agvtomove.getOrientation())
            {
                case 0:
                    MNorthAGV(Agvref);
                    break;
                case 1:
                    MEastAGV(Agvref);
                    break;
                case 2:
                    MSouthAGV(Agvref);
                    break;
                case 3:
                    MWestAGV(Agvref);
                    break;
                default:
                    break;
            }

        }
        public void MBwAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            switch (Agvtomove.getOrientation())
            {
                case 0:
                    MSouthAGV(Agvref);
                    break;
                case 1:
                    MWestAGV(Agvref);
                    break;
                case 2:
                    MNorthAGV(Agvref);
                    break;
                case 3:
                    MEastAGV(Agvref);
                    break;
                default:
                    break;
            }
        }
        public void RRAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            Agvtomove.RR();

        }
        public void RLAGV(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            Agvtomove.RL();

        }

        // Public access
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public int getValue(int i, int j)
        {
            return WS[i, j];
        }
        public int getAGVOrient(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            return Agvtomove.getOrientation();
        }


        public bool isBreakPossible(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            bool breakable;
            breakable = false;
            if (isFreeFront(Agvtomove) == false)
            {
                if (
                    
                    limitReached(Agvtomove) == false)
                {
                    breakable = true;
                }
            }
            return breakable;
        }
        private bool limitReached(AGV Agvtomove)
        {
            bool onLimit;
            onLimit = false;
            if (Agvtomove.getFSensor() == 0)
            {
                switch (Agvtomove.getOrientation())
                {
                    case 0:
                        if (Agvtomove.getPosY() == 0)
                        {
                            onLimit = true;
                        }
                        break;
                    case 1:
                        if (Agvtomove.getPosX() == 9)
                        {
                            onLimit = true;
                        }
                        break;
                    case 2:
                        if (Agvtomove.getPosY() == 9)
                        {
                            onLimit = true;
                        }
                        break;
                    case 3:
                        if (Agvtomove.getPosX() == 0)
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
        public void breakObstacle(int Agvref)
        {
            AGV Agvtomove = AGVlist[Agvref - 1];
            int targetX = 0;
            int targetY = 0;

            switch (Agvtomove.getOrientation())
            {
                case 0:
                    targetX = Agvtomove.getPosX();
                    targetY = Agvtomove.getPosY() - 1;
                    break;
                case 1:
                    targetX = Agvtomove.getPosX() + 1;
                    targetY = Agvtomove.getPosY();
                    break;
                case 2:
                    targetX = Agvtomove.getPosX();
                    targetY = Agvtomove.getPosY() + 1;
                    break;
                case 3:
                    targetX = Agvtomove.getPosX() - 1;
                    targetY = Agvtomove.getPosY();
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

