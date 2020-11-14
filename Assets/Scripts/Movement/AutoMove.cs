using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static DefaultNamespace.Utils_RandPoint;
using static Level.GlobalSettings;

[AddComponentMenu("Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
    public Vector2 direction = new Vector2(1f, 0f);
    public GameObject badGuy;
    public GameObject goodGuy;
    public GameObject camera;
    public GameObject generate;
    
    private bool withCamera = false;
    private int _frameCount = 50;
    private static System.Random rand = new System.Random();

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (!IsGameOn && Input.anyKey && CountWithCamera >= BadGuys.Count - 1)
        {
            level = 1;
            goodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[2].text = "";
            goodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[3].text = "";
            
            generate.GetComponents<Generate>()[0].RegenerateLevel();
        }
        
        if (IsGameOn && IsStart)
        {
            if (_frameCount-- < 0)
            {
                _frameCount = rand.Next(50, 200);
                direction = RandDirection();
            }

            if (CheckGoodGuyDistance(15) && !CheckGoodGuyPlace())
            {
                var position1 = goodGuy.transform.position;
                var position2 = badGuy.transform.position;
                direction.x = -(position2.x - position1.x) * 2;
                direction.y = -(position2.y - position1.y) * 2;
            }

            if (CheckGoodGuyDistance(4) && !CheckGoodGuyPlace())
            {
                goodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[2].text = "Game Over";
                IsGameOn = false;
                IsStart = false;
                var position2 = badGuy.transform.position;
                Instantiate(camera, new Vector2((float) (position2.x), (float) (position2.y-0.3)), Quaternion.identity);
                print("Game Over");
                withCamera = true;
            }

            var position = badGuy.transform.position;
            if (badGuy.transform.position.x < x1 + 1.5)
            {
                if (direction.x < 0) direction.x = 0;
                position.Set(x1, position.y, 0);
            }
            else if (badGuy.transform.position.x > x2 - 1.5)
            {
                if (direction.x > 0) direction.x = 0;
                position.Set(x2, position.y, 0);
            }

            if (badGuy.transform.position.y > y1)
            {
                if (direction.y > 0) direction.y = 0;
                position.Set(position.x, y1, 0);
            }
            else if (badGuy.transform.position.y < y2)
            {
                if (direction.y < 0) direction.y = 0;
                position.Set(position.x, y2, 0);
            }

            rigidbody2D.AddForce(direction * 6f);
        }
        else if (!IsGameOn)
        {
            if (!CheckGoodGuyDistance(4))
            {
                var position1 = goodGuy.transform.position;
                var position2 = badGuy.transform.position;
                direction.x = -(position2.x - position1.x) * 2;
                direction.y = -(position2.y - position1.y) * 2;
                rigidbody2D.AddForce(direction * 6f);
            }
            else
            {
                if (!withCamera)
                {
                    var position2 = badGuy.transform.position;
                    Cameras.Add(Instantiate(camera, new Vector2((float) (position2.x + 0.05), (float) (position2.y + 0.05)),
                        Quaternion.identity));
                    withCamera = true;
                    CountWithCamera++;
                    if (CountWithCamera == BadGuys.Count - 1)
                    {
                        goodGuy.GetComponentsInChildren<UnityEngine.UI.Text>()[3].text = "Нажмите любую клавишу, чтобы играть заново.";
                    }
                }
            }
        }
    }

    private bool CheckGoodGuyDistance(int d)
    {
        var position1 = goodGuy.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        var position = badGuy.transform.position;
        float x2 = position.x;
        float y2 = position.y;

        return ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) < d * d);
    }

    private bool CheckGoodGuyPlace()
    {
        float d = 1.5f;
        var position = goodGuy.transform.position;
        float x = position.x;
        float y = position.y;
        foreach (var obj in AllObjects)
        {
            if ((obj.transform.position.x - x) * (obj.transform.position.x - x) +
                (obj.transform.position.y - y) * (obj.transform.position.y - y) < d * d)
            {
                return true;
            }
        }
        return false;
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