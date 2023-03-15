using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGV_Local
{
     
    public class AGV
    {
        //Variables de clase
        private int posX;
        private int posY;
        private int orient;
        private int FSensor;
        private bool BSensor;
        private bool LSensor;
        private bool RSensor;
        
        //Constructores
        public AGV()
        {
            posX = 0;
            posY = 0;
            orient = 0;
        }
        public AGV(int x, int y, int i)
        {
            posX = x;
            posY = y;
            orient = i;
        }

        //Movimientos
        public void RR()
        {
            if (orient > 2)
            {
                orient = 0;
            }
            else 
            {
                orient++;
            }
        }
        public void RL()
        {
            if (orient < 1)
            {
                orient = 3;
            }
            else
            {
                orient--;
            }
        }
        public void MovNorth()
        {
            posY--;
        }
        public void MovSouth()
        {
            posY++;
        }
        public void MovWest()
        {
            posX--;
        }
        public void MovEast()
        {
            posX++;
        }
        public void MovFW()
        {
            switch (orient)
            { 
                case 0:
                    MovNorth();
                    break;
                case 1:
                    MovEast();
                    break;
                case 2:
                    MovSouth();
                    break;
                case 3:
                    MovWest();
                    break;
                default:
                    break;
            }
      
        }
        public void MovBW()
        {
            switch (orient)
            {
                case 0:
                    MovSouth();
                    break;
                case 1:
                    MovWest();
                    break;
                case 2:
                    MovNorth();
                    break;
                case 3:
                    MovEast();
                    break;
                default:
                    break;
            }

        }

        //Modificadores puros
        public void setOrient(int p)
        {
            orient=p;
        }
        public void setPosX(int x)
        {
            posX = x;
        }
        public void setPosY(int y)
        {
            posY = y;
        }
        public void setFSensor(int dist)
        {
            FSensor = dist;
        }
        public void setBSensor(bool val)
        {
            BSensor = val;
        }
        public void setLSensor(bool val)
        {
            LSensor = val;
        }
        public void setRSensor(bool val)
        {
            RSensor = val;
        }

        //Consultores puros
        public int getOrientation()
        {
            return orient;
        }
        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {
            return posY;
        }
        public int getFSensor()
        {
            return FSensor;
        }
        public bool getBSensor()
        {
            return BSensor;
        }
        public bool getLSensor()
        {
            return LSensor;
        }
        public bool getRSensor()
        {
            return RSensor;
        }
        
    }
}
