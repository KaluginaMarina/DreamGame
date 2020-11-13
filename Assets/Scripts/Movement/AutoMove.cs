using System;
using UnityEngine;
using static DefaultNamespace.Utils_RandPoint;
using static Level.GlobalSettings;

[AddComponentMenu("Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
    public Vector2 direction = new Vector2(1f, 0f);
    public GameObject BadGuy;
    public GameObject GoodGuy;

    private int _frameCount = 50;
    private static System.Random rand = new System.Random();

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (_frameCount-- < 0)
        {
            _frameCount = rand.Next(50, 200);
            direction = RandDirection();
        }
        
        if (CheckGoodGuy(15))
        {
            var position1 = GoodGuy.transform.position;
            var position2 = BadGuy.transform.position;
            direction.x = -(position2.x - position1.x) * 2;
            direction.y = -(position2.y - position1.y) * 2;
        }

        var position = BadGuy.transform.position;
        if (BadGuy.transform.position.x < x1 + 1.5)
        {
            if (direction.x < 0) direction.x = 0;
            position.Set(x1, position.y, 0);
        }
        else if (BadGuy.transform.position.x > x2 - 1.5)
        {
            if (direction.x > 0) direction.x = 0;
            position.Set(x2, position.y, 0);
        }

        if (BadGuy.transform.position.y > y1)
        {
            if (direction.y > 0) direction.y = 0;
            position.Set(position.x, y1, 0);
        }
        else if (BadGuy.transform.position.y < y2)
        {
            if (direction.y < 0) direction.y = 0;
            position.Set(position.x, y2, 0);
        }
        
        rigidbody2D.AddForce(direction * 6f);
    }

    public bool CheckGoodGuy(int d)
    {
        var position1 = GoodGuy.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        var position = BadGuy.transform.position;
        float x2 = position.x;
        float y2 = position.y;
        
        return ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) < d * d);
    }

    //Draw an arrow to show the direction in which the object will move
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            Utils.DrawMoveArrowGizmo(transform.position, direction, 0);
        }
    }
}