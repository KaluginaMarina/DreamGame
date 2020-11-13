using System;
using UnityEngine;
using static Level.GlobalSettings;

namespace DefaultNamespace
{
    public class Utils_RandPoint
    {
        private static System.Random rand = new System.Random();

        public static float RandX()
        {
            return (float) ((float) rand.Next((int) x1, (int) x2) * 0.95);
        }

        public static float RandY()
        {
            return (float) ((float) rand.Next((int) y2, (int) y1) * 0.95);
        }

        public static Vector2 RandDirection()
        {
            int randX = rand.Next(0, 15) * (rand.Next(-2, 2) > 0 ? -1 : 1);
            int randY = (15 - Math.Abs(randX)) * (rand.Next(-2, 2) > 0 ? -1 : 1);
            return new Vector2(randX, randY);
        }
    }
}