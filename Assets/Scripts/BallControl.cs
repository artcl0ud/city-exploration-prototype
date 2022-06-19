using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
private Rigidbody enableBallGravity;
private float ballMovementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        enableBallGravity = GetComponent<Rigidbody>();
        enableBallGravity.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            enableBallGravity.useGravity = true;
            this.enabled = false;
        }
    }

    ///METHODS

    private void MoveBall()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * ballMovementSpeed * Time.deltaTime);
    }
}
