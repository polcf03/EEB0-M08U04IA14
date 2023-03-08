using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGV_Local
{
   
    
    class TrajectoryManager
    {
        private bool wallDetected;
        private bool turnning;
        private int crazy;
        private int maxSteps;
        private int steps;
        private readonly Random _random = new Random();



        public TrajectoryManager()
        {
            wallDetected = false;
            turnning = false;
            crazy = 0;
            maxSteps = 100;
            steps = 0;
        }

        public string getAdvice(int Fs, bool Bs, bool Rs, bool Ls, int posX, int posY, int orient)
        {
            string advice = "surrender";


            if (posX < 1)
            {
                advice = "success";

            }
            else if (steps > maxSteps)
            {
                advice = "turnR";
                crazy = RandomNumber(1, 10);
                crazy--;
                wallDetected = false;
                steps = 0;
            }
            else if (crazy > 0)
            {
                advice = "turnR";
                crazy--;
            }

            else if (turnning == true)
            {
                advice = "movFW";
                turnning = false;
            }
            else if (wallDetected == false)
            {
                if (canGoFront(Fs) == true)
                {
                    advice = "movFW";
                }
                else
                {
                    advice = "turnR";
                    wallDetected = true;
                }
            }
            else
            {

                if (wallOnMyLeftSide(Ls) == false)
                {
                    advice = "turnL";
                    turnning = true;
                }
                else
                {
                    if (canGoFront(Fs) == true)
                    {
                        advice = "movFW";
                    }
                    else
                    {
                        advice = "turnR";
                    }

                }

            }

            steps++;

            return advice;
        }
        public void reset()
        {
            steps = 0;
            wallDetected = false;
            crazy = 0;
            turnning = false;
        }

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        } 
        private bool wallOnMyLeftSide(bool Ls)
        {


            return Ls;

        
        }
        private bool canGoFront(int Fs)
        {
            bool iCan=false;

            if (Fs > 0)
            {
                iCan = true;
            }

            return iCan;
        }


    }
}
