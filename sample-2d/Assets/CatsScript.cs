using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float acc = 10;
    public float restorationPower = 1;

    private bool isColliding = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.rotation = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity += Vector2.up * acc;
        }

        float restorationVelocity = myRigidBody.position.x * -1 * restorationPower;


        if (!isColliding && myRigidBody.position.x != 0)
        {
            myRigidBody.velocity = new Vector2(restorationVelocity, myRigidBody.velocity.y);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
        }
    }

    void OnCollisionEnter2D()
    {

        isColliding = true;

    }

    void OnCollisionExit2D()
    {

        isColliding = false;
    }
}
