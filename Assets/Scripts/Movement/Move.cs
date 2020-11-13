using UnityEngine;
using UnityEngine.Serialization;
using static Level.GlobalSettings;

[AddComponentMenu("Playground/Movement/Move With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
    [Header("Input keys")] public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")] [Tooltip("Speed of movement")]
    public float speed = 5f;

    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")] public bool orientToDirection = false;

    public GameObject GoodGuy;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;


    // Update gets called every frame
    void Update()
    {
        if (IsGameOn)
        {
            // Moving with the arrow keys
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

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

            movement = new Vector2(moveHorizontal, moveVertical);
        }
        else
        {
            movement = new Vector2(0, 0);
        }
    }


    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the force to the Rigidbody2d
        rigidbody2D.AddForce(movement * speed * 10f);
    }
}