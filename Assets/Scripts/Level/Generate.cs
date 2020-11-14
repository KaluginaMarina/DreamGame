using System.Collections.Generic;
using static DefaultNamespace.Utils_RandPoint;
using UnityEngine;
using UnityEngine.Serialization;
using static Level.GlobalSettings;

public class Generate : MonoBehaviour
{
    public GameObject badGuy;
    public GameObject goodGuy;

    public GameObject stone1Prefab;
    public GameObject stone2Prefab;
    public GameObject grassPrefab;
    public GameObject bushPrefab;


    public GameObject hat;
    public GameObject blouse;
    public GameObject coat;
    public GameObject pants;
    public GameObject scarf;

    bool checkPlace(float x, float y, float d)
    {
        foreach (var obj in AllObjects)
        {
            if ((obj.transform.position.x - x) * (obj.transform.position.x - x) +
                (obj.transform.position.y - y) * (obj.transform.position.y - y) < d * d)
            {
                return false;
            }
        }

        foreach (var wear in AllWear)
        {
            if ((wear.transform.position.x - x) * (wear.transform.position.x - x) +
                (wear.transform.position.y - y) * (wear.transform.position.y - y) < d * d)
            {
                return false;
            }
        }

        return true;
    }

    void GenerateObjects(GameObject gameObject)
    {
        for (var c = 0; c < countObject / 4; ++c)
        {
            bool ok = false;
            float x = RandX(), y = RandY();
            while (!ok)
            {
                x = RandX();
                y = RandY();
                ok = checkPlace(x, y, 3);
            }

            AllObjects.Add(Instantiate(gameObject, new Vector2(x, y), Quaternion.identity));
        }
    }

    void GenerateWear(GameObject wear)
    {
        float x = RandX(), y = RandY();
        while (!checkPlace(x, y, 2))
        {
            x = RandX();
            y = RandY();
        }

        AllWear.Add(Instantiate(wear, new Vector2(x, y), Quaternion.identity));
        ;
    }

    void GenerateBadGuys()
    {
        for (var i = 0; i < 10 * level; ++i)
        {
            float x = RandX(), y = RandY();
            while (!CheckGoodGuyDistance(x, y, 10))
            {
                x = RandX();
                y = RandY();
            }

            BadGuys.Add(Instantiate(badGuy, new Vector2(x, y), Quaternion.identity));
        }
    }

    private bool CheckGoodGuyDistance(float x2, float y2, int d)
    {
        var position1 = goodGuy.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;

        return ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) > d * d);
    }

// Start is called before the first frame update
    void Start()
    {
        GenerateObjects(stone1Prefab);
        GenerateObjects(stone2Prefab);
        GenerateObjects(grassPrefab);
        GenerateObjects(bushPrefab);
        GenerateWear(hat);
        GenerateWear(coat);
        GenerateWear(scarf);
        GenerateWear(pants);
        GenerateWear(blouse);
        GenerateBadGuys();
    }

    public void RegenerateLevel()
    {
        foreach (var wear in AllWear)
        {
            Destroy(wear);
        }

        foreach (var obj in AllObjects)
        {
            Destroy(obj);
        }

        foreach (var badGuy in BadGuys)
        {
            Destroy(badGuy);
        }

        AllWear = new List<GameObject>();
        AllObjects = new List<GameObject>();
        BadGuys = new List<GameObject>();
        WearCount = 0;

        goodGuy.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
        Start();
    }

// Update is called once per frame
    void Update()
    {
    }
}