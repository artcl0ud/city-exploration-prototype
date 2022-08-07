using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class TeleportTriggerInterior : MonoBehaviour
{
    ThirdPersonController thirdPersonController;
    TransitionFader transitionFader;
    
    public AudioClip doorOpen;
    public AudioClip doorClose;
    AudioSource audioSource;

    [SerializeField] GameObject player;
    [SerializeField] float xLocation;
    [SerializeField] float yLocation;
    [SerializeField] float zLocation;

    void Start()
    {
        thirdPersonController = GameObject.Find("PlayerArmature").GetComponent<ThirdPersonController>();
        transitionFader = GameObject.Find("BlackFadeInOut").GetComponent<TransitionFader>();
        audioSource = GetComponent<AudioSource>(); 
    }

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
        thirdPersonController.Disabled = true;
        yield return new WaitForSeconds(0.01f);
        transitionFader.FadeIn();
        audioSource.PlayOneShot(doorOpen, 0.7F);
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3 (xLocation, yLocation, zLocation);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(doorClose, 0.7F);
        transitionFader.FadeIn();
        yield return new WaitForSeconds(0.01f);
        thirdPersonController.Disabled = false;
    }
}