using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Level
{
    public class GlobalSettings
    {
        public static int level = 1;
        public static int countObject = 100;

        public static float x1 = -100;
        public static float y1 = 30;
        public static float x2 = 100;
        public static float y2 = -50;

        public static List<GameObject> AllObjects = new List<GameObject>();
        public static List<GameObject> AllWear = new List<GameObject>();
        public static List<GameObject> BadGuys = new List<GameObject>();
        public static List<GameObject> Cameras = new List<GameObject>();

        public static int WearCount = 0;

        public static bool IsGameOn = true;
        public static bool IsStart = false;
        public static bool BeginingGame = true;

        public static int CountWithCamera = 0;

        public static String[] Texts = {
            "Это был тяжелый день, надо сесть и обдумать все ошибки...",
            "Главное, не закрывать глаза, иначе я усну...",
            "Главное не закрывать...",
            "Главное не...",
            "",
            "Хрррррр... Хррррр....",
            "",
            "Мне часто снится один кошмар...",
            "В нем я оказываюсь без одежды на улице...",
            "Мне приходится прятаться от прохожих за кустами и искать потерянную одежду...",
            "",
            "Только не опять....",
            ""
        };
    }
}