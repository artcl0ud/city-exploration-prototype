using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHitText : MonoBehaviour
{

    public string resultText;
    public Text textElement;
    public EnterBoardTrigger receiveBoardTrigger = new EnterBoardTrigger();

    // Start is called before the first frame update
    void Start()
    {
        receiveBoardTrigger.GetComponent<EnterBoardTrigger>();
        resultText = "(Game not completed.)";
        textElement.text = resultText;
    }

    void Update()
    {
        //resultText = receiveBoardTrigger.OnTriggerEnter(Collider collision);
    }
}
