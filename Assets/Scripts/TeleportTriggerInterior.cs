using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTriggerInterior : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float xLocation;
    [SerializeField] float yLocation;
    [SerializeField] float zLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected, warping player to specified coordinates...");
            StartCoroutine("Teleport");
        }
    }

    IEnumerator Teleport()
    {
        //Disable PlayerController
        yield return new WaitForSeconds(0.01f);
        player.transform.position = new Vector3 (xLocation, yLocation, zLocation);
        yield return new WaitForSeconds(0.01f);
        //Enable PlayerController
    }
}