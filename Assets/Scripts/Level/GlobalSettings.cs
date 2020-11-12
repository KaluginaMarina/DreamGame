using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class GlobalSettings
    {
        public  static int level = 0;
        public  static  int countObject = 40;

        public  static double x1 = -30;
        public  static double y1 = 30;
        public  static double x2 = 50;
        public  static double y2 = -50;

        public static List<GameObject> AllObjects = new List<GameObject>();

    }
}