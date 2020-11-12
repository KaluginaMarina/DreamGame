using System.Collections.Generic;
using UnityEngine;
using static Level.GlobalSettings;

public class Generate : MonoBehaviour
{
    public GameObject stone1Prefab;
    public GameObject stone2Prefab;
    public GameObject grassPrefab;
    public GameObject bushPrefab;

    private System.Random rand = new System.Random();

    float RandX()
    {
        return (float) ((rand.Next() % (x2 - x1) + x1) * 0.99);
    }

    float RandY()
    {
        return (float) ((rand.Next() % (y1 - y2) + y2) * 0.99);
    }

    bool checkPlace(float x, float y)
    {
        foreach (var obj in AllObjects)
        {
            if ((obj.transform.position.x - x) * (obj.transform.position.x - x) +
                (obj.transform.position.y - y) * (obj.transform.position.y - y) < 9)
            {
                return false;
            }
        }

        return true;
    }

    void GenerateObjects(GameObject gameObject)
    {
        countObject -= level;

        for (var c = 0; c < countObject / 4; ++c)
        {
            bool ok = false;
            float x = 0, y = 0;
            while (!ok)
            {
                x = RandX();
                y = RandY();
                ok = checkPlace(x, y);
            }

            AllObjects.Add(Instantiate(gameObject, new Vector2(x, y), Quaternion.identity));
        }
    }

// Start is called before the first frame update
    void Start()
    {
        GenerateObjects(stone1Prefab);
        GenerateObjects(stone2Prefab);
        GenerateObjects(grassPrefab);
        GenerateObjects(bushPrefab);
    }

// Update is called once per frame
    void Update()
    {
    }
}