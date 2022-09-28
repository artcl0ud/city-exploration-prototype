using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StarterAssets;

public class TeleportTriggerSubgame : MonoBehaviour
{
    ThirdPersonController thirdPersonController;
    Transitions transitionFader;

    [SerializeField] Object scene;
    [SerializeField] GameObject player;

    private Canvas SubgameEnterCanvas;
    private Canvas SubgameExitCanvas;
    [SerializeField] public Button SubgameEnterButton;
    [SerializeField] public Button SubgameExitButton;

    [SerializeField] private float xExitLocation;
    [SerializeField] private float yExitLocation;
    [SerializeField] private float zExitLocation;

    void Awake()
    {
        SubgameEnterCanvas = GameObject.Find("SubgameEnterButton").GetComponent<Canvas>();
        SubgameExitCanvas = GameObject.Find("SubgameExitButton").GetComponent<Canvas>();
        SubgameEnterButton = GameObject.Find("SubgameEnterButton").GetComponent<Button>();
        SubgameExitButton = GameObject.Find("SubgameExitButton").GetComponent<Button>();
    }

    void Start() 
    {
        transitionFader = GameObject.Find("BlackFadeInOut").GetComponent<Transitions>();

        SubgameEnterCanvas.enabled = false;
        SubgameExitCanvas.enabled = false;

        SubgameEnterButton.onClick.AddListener(EnterSubgame);
        SubgameExitButton.onClick.AddListener(ExitSubgame);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enable UI Button");
            SubgameEnterCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Disable UI Button");
            SubgameEnterCanvas.enabled = false;
        }
    }

    ///MOUSELCICK LISTENERS

    public void EnterSubgame()
    {
        StartCoroutine("EnterSubgameDelay");
    }

    public void ExitSubgame()
    {
        StartCoroutine("ExitSubgameDelay");
    }

    ///COUROUTINES

    IEnumerator EnterSubgameDelay()
    {
        transitionFader.SetFadeInOut();
        yield return new WaitForSeconds(0.01f);
        SubgameEnterCanvas.enabled = false;
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(scene.name);
        yield return new WaitForSeconds(0.01f);
        SubgameExitCanvas.enabled = true;
        yield return new WaitForSeconds(0.01f);
        thirdPersonController.Disabled = true;
        transitionFader.SetFadeInOut();
    }

    IEnumerator ExitSubgameDelay()
    {
        transitionFader.SetFadeInOut();
        yield return new WaitForSeconds(0.01f);
        SubgameExitCanvas.enabled = false;
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene("InGame_Area_Main");
        yield return new WaitForSeconds(0.01f);
        player.transform.position = new Vector3 (xExitLocation, yExitLocation, zExitLocation);
        yield return new WaitForSeconds(0.01f);
        thirdPersonController.Disabled = false;
        transitionFader.SetFadeInOut();
    }
}