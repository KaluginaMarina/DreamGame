using UnityEngine;
using static DefaultNamespace.Utils_RandPoint;

[AddComponentMenu("Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
    // These are the forces that will push the object every frame
    // don't forget they can be negative too!
    public Vector2 direction = new Vector2(1f, 0f);
    private int _frameCount = 50;
    private static System.Random rand = new System.Random();

    //is the push relative or absolute to the world?
    public bool relativeToRotation = true;


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (_frameCount-- < 0)
        {
            _frameCount = rand.Next(50, 200);    
            direction = RandDirection();
        }

        rigidbody2D.AddForce(direction * 6f);
    }


    //Draw an arrow to show the direction in which the object will move
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;

            Utils.DrawMoveArrowGizmo(transform.position, direction, extraAngle);
        }
    }
}