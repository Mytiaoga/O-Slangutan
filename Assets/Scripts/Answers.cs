using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    [SerializeField] GameObject Engine;
    Engine engineScript;

    private void Start()
    {
        engineScript = Engine.GetComponent<Engine>();
    }

    public void OnButtonPress()
    {
        if (engineScript.gameStart)
        {
            engineScript.clickCheck = true;
            if (this.gameObject.name == "ChoiceBox")
            {
                engineScript.button = 1;
                Debug.Log("Clicked 1");
            }
            if (this.gameObject.name == "ChoiceBox (1)")
            {
                engineScript.button = 2;
                Debug.Log("Clicked 2");
            }
            if (this.gameObject.name == "ChoiceBox (2)")
            {
                engineScript.button = 3;
                Debug.Log("Clicked 3");
            }
            if (this.gameObject.name == "Button")
            {
                Debug.Log("Clicked");
            }
        }
        else
        {
            engineScript.introQ++;
            if (engineScript.introQ > 5)
            {
                engineScript.gameStart = true;
                engineScript.nextQuestion();
            }
        }
        
    }
}
