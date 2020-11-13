using UnityEngine;
using static Level.GlobalSettings;

namespace DefaultNamespace
{
    public class Utils_RandPoint
    {
        private static System.Random rand = new System.Random();
        
        public static float RandX()
        {
            return (float) ((float) rand.Next( (int) x1, (int) x2) * 0.95);
        }

        public static float RandY()
        {
            return (float) ((float) rand.Next( (int) y2, (int) y1) * 0.95);
        }
    }
}