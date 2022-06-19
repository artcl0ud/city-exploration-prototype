using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoardTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
         Debug.Log("Collided with " + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider collision) 
    {
        IEnumerator DelayTriggerResult()
        {
            //TODO - Add coroutine/delay to detect in which trigger zone the ball stayed the last/longest to confirm that is the final result
            yield return new WaitForSeconds(.3f);
            Debug.Log("Ball has arrived in  trigger number " + collision.gameObject.name);
        }
        StartCoroutine(DelayTriggerResult());
    }
}