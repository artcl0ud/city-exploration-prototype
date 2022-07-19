using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneTransition : MonoBehaviour
{
    string sceneToLoad = "InGame_LuckyHit";

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected, transitioning...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
