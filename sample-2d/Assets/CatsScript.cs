using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float acc = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRigidBody.velocity += Vector2.up * acc;
        }
    }
}
