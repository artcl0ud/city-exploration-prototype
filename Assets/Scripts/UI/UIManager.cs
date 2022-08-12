using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        ResetGame();
    }
    
    void ResetGame()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }
}
