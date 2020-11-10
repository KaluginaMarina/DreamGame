using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    private int level = 0;
    private int countObject = 40;

    private double x1 = -27;
    private double y1 = 30;
    private double x2 = 50;
    private double y2 = -50;

    public GameObject stone1Prefab;
    public GameObject stone2Prefab;
    public GameObject grassPrefab;
    public GameObject bushPrefab;
    System.Random rand = new System.Random();
    float RandX()
    {
        return (float) (rand.Next() % (x2 - x1) + x1);
    }

    float RandY()
    {
        return (float) (rand.Next() % (y1 - y2) + y2);
    }

    // Start is called before the first frame update
    void Start()
    {
        var allObjects = new List<GameObject>();

        countObject -= level;
        
        for (var c = 0; c < countObject / 4; ++c)
        {
            var x = RandX();
            var y = RandY();
            Instantiate(stone1Prefab, new Vector2(x, y), Quaternion.identity);
        }

        for (var c = 0; c < countObject / 4; ++c)
        {
            var x = RandX();
            var y = RandY();
            Instantiate(stone2Prefab, new Vector2(x, y), Quaternion.identity);
        }

        for (var c = 0; c < countObject / 4; ++c)
        {
            var x = RandX();
            var y = RandY();
            Instantiate(grassPrefab, new Vector2(x, y), Quaternion.identity);
        }

        for (var c = 0; c < countObject / 4; ++c)
        {
            var x = RandX();
            var y = RandY();
            Instantiate(bushPrefab, new Vector2(x, y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}