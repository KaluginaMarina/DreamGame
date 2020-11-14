using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Level
{
    public class GlobalSettings
    {
        public  static int level = 1 ;
        public  static int countObject = 100;

        public  static float x1 = -100;
        public  static float y1 = 30;
        public  static float x2 = 100;
        public  static float y2 = -50;

        public static List<GameObject> AllObjects = new List<GameObject>();
        public static List<GameObject> AllWear = new List<GameObject>();
        public static List<GameObject> BadGuys = new List<GameObject>();
        
        public static int WearCount = 0;
        
        public static bool IsGameOn = true;
        public static bool IsStart = false;

        public static int countWithCamera = 0;

    }
}