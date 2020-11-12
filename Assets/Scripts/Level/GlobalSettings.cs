using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class GlobalSettings
    {
        public  static int level = 0;
        public  static  int countObject = 100;

        public  static double x1 = -100;
        public  static double y1 = 30;
        public  static double x2 = 100;
        public  static double y2 = -50;

        public static List<GameObject> AllObjects = new List<GameObject>();
        public static List<GameObject> AllWear = new List<GameObject>();
        
    }
}