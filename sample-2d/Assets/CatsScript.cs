using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float acc = 10;
    public float restorationPower = 1;
    public LogicScript logicScript;

    private bool isColliding = false;
    private bool isGameOver = false;
    private float invincibleTime = 1;
    private float timeSinceLastCollision = 0;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;


    // Start is called before the first frame update
    void Start()
    {
        float distance = 10;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;

        Debug.Log($"minX: {minX}, maxX: {maxX}, minY: {minY}, maxY: {maxY}");
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.rotation = 0;

        if (isGameOver)
        {
            return;
        }

        timeSinceLastCollision = timeSinceLastCollision += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity += Vector2.up * acc * Time.timeScale;
        }

        float restorationVelocity = myRigidBody.position.x * -1 * restorationPower * Time.timeScale;

        float velocityY = myRigidBody.velocity.y;


        if (!isColliding && myRigidBody.position.x != 0)
        {
            myRigidBody.velocity = new Vector2(restorationVelocity, velocityY);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0, velocityY);
        }

        if (myRigidBody.position.y > maxY)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Mathf.Min(velocityY, 0));
        }

        if (myRigidBody.position.y < minY)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Mathf.Max(velocityY, 0));
        }
    }

    void OnCollisionEnter2D()
    {
        isColliding = true;

        if (timeSinceLastCollision < invincibleTime)
        {
            return;
        }

        timeSinceLastCollision = 0;
        isGameOver = logicScript.collide();
    }

    void OnCollisionExit2D()
    {

        isColliding = false;
    }
}
