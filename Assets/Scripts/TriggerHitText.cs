using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHitText : MonoBehaviour
{

    public string resultText;
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        resultText = "(Game not completed.)";
        textElement.text = resultText;
    }
}
