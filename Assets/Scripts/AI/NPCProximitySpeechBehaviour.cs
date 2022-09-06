using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCProximitySpeechBehaviour : MonoBehaviour
{
    private Canvas NPCConversationStartCanvas;
    private Canvas NPCConversationAnswerCanvas;
    private Button NPCConversationStartButton;
    private Button NPCConversationAnswerButton;

    [SerializeField] private string[] NPCLines;
    private int linesIndex; 

    private void Awake() 
    {
        NPCConversationStartCanvas = GameObject.Find("NPCConversationStartButton").GetComponent<Canvas>();
        NPCConversationAnswerCanvas = GameObject.Find("NPCConversationAnswerButton").GetComponent<Canvas>();
        NPCConversationStartButton = GameObject.Find("NPCConversationStartButton").GetComponent<Button>();
        NPCConversationAnswerButton = GameObject.Find("NPCConversationAnswerButton").GetComponent<Button>();
    }

    private void Start()
    {
        NPCConversationStartCanvas.enabled = false;
        NPCConversationAnswerCanvas.enabled = false;

        NPCConversationStartButton.onClick.AddListener(NPCConversationAnswer);
        NPCConversationAnswerButton.onClick.AddListener(NPCConversationAnswer);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enable talk UI");
            NPCConversationStartCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Disable talk UI");
            NPCConversationStartCanvas.enabled = false;
            NPCConversationAnswerCanvas.enabled = false;
        }
    }

    public void NPCConversationAnswer()
    {
        NPCConversationStartCanvas.enabled = false;

        linesIndex = Random.Range(0, NPCLines.Length);
        NPCConversationAnswerButton.GetComponentInChildren<Text>().text = NPCLines[linesIndex];

        NPCConversationAnswerCanvas.enabled = true;
    }
}
