using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public BallControl IsEnabled;
    private Rigidbody enableBallGravity;

    private float ballMovementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        IsEnabled = GameObject.Find("Ball").GetComponent<BallControl>();
        enableBallGravity = GetComponent<Rigidbody>();
        enableBallGravity.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        DropBall();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("End result: ball landed and stayed in" + other.gameObject.name);
    }

    ///METHODS

    private void MoveBall()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * ballMovementSpeed * Time.deltaTime);
    }

    private void DropBall()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            enableBallGravity.useGravity = true;
            this.enabled = false;
        }
    }
}
