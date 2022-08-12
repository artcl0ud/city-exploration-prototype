using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoardTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider collision) 
    {
        //Invoke(Debug.Log("Final result: ball has arrived in trigger number " + collision.gameObject.name), 2f);
    }
}