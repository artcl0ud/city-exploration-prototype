using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTriggerArea : MonoBehaviour
{
    [SerializeField] Object scene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected, transitioning to" + scene.name);
            SceneManager.LoadScene(scene.name);
        }
    }
}
