using static Level.GlobalSettings;

namespace DefaultNamespace
{
    public class Utils_RandPoint
    {
        private static System.Random rand = new System.Random();
        
        public static float RandX()
        {
            return (float) ((rand.Next() % (x2 - x1) + x1) * 0.95);
        }

        public static float RandY()
        {
            return (float) ((rand.Next() % (y1 - y2) + y2) * 0.95);
        }
    }
}