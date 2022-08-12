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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider collision) 
    {
        string finalResult = collision.gameObject.name;
        StartCoroutine("FinalResult");
    }

    IEnumerator FinalResult(string finalResult)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Final result: ball landed in " + finalResult);
    }

    ///METHODS

    private void MoveBall()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * ballMovementSpeed * Time.deltaTime);
    }
}
