using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static Level.GlobalSettings;

[AddComponentMenu("Playground/Movement/Move With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
    [Header("Input keys")] public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    public GameObject generate;

    [Header("Movement")] [Tooltip("Speed of movement")]
    public float speed = 5f;

    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")] public bool orientToDirection = false;

    public GameObject GoodGuy;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    
    void Update()
    {
        if (!IsStart)
        {
            if (Input.anyKey)
            {
                IsStart = true;
                GoodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[3].text = "";
            }
        }
        
        if (IsGameOn)
        {
            // Moving with the arrow keys
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal != 0 && moveVertical != 0)
            {
                GoodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[2].text = "";
                IsStart = true;
            }
            
            var position = GoodGuy.transform.position;
            if (GoodGuy.transform.position.x < x1 + 1.5)
            {
                if (moveHorizontal < 0)
                {
                    moveHorizontal *= -1;
                }

                position.Set(x1, position.y, 0);
            }
            else if (GoodGuy.transform.position.x > x2 - 1.5)
            {
                if (moveHorizontal > 0)
                {
                    moveHorizontal *= -1;
                }

                position.Set(x2, position.y, 0);
            }

            if (GoodGuy.transform.position.y > y1)
            {
                if (moveVertical > 0)
                {
                    moveVertical *= -1;
                }

                position.Set(position.x, y1, 0);
            }
            else if (GoodGuy.transform.position.y < y2)
            {
                if (moveVertical < 0)
                {
                    moveVertical *= -1;
                }

                position.Set(position.x, y2, 0);
            }

            CheckWear();
            
            movement = new Vector2(moveHorizontal, moveVertical);
        }
        else
        {
            movement = new Vector2(0, 0);
        }
    }

    private void CheckWear()
    {
        foreach (var wear in AllWear)
        {
            var position = wear.transform.position;
            float x1 = position.x;
            var position1 = GoodGuy.transform.position;
            float x2 = position1.x;
            float y1 = position.y;
            float y2 = position1.y;
            if ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) < 1)
            {
                wear.transform.SetPositionAndRotation(new Vector2(-150, -150), Quaternion.identity);
                WearCount++;
                GoodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[1].text = "Найдено " + WearCount + "/" + AllWear.Count; 
                print(WearCount + "/" + AllWear.Count);

                if (WearCount == AllWear.Count)
                {
                    level++;
                    GoodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[2].text = "Уровень " + level;
                    print("Level " + level);
                    generate.GetComponents<Generate>()[0].RegenerateLevel();
                    IsStart = false;
                }
                
            }    
        }
    }


    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the force to the Rigidbody2d
        rigidbody2D.AddForce(movement * speed * 10f);
    }
}