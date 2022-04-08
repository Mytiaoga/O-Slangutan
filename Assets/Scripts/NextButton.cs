using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    [SerializeField] GameObject Engine;
    Engine engineScript;

    private void Start()
    {
        engineScript = Engine.GetComponent<Engine>();
    }
    public void OnButtonPress()
    {
        engineScript.clickCheck = false;
        engineScript.GenerateNum();
        Debug.Log(engineScript.wrongCount + "<Wrong Counts");
        if (engineScript.correct)
        {
            engineScript.nextQuestion();
        }
        else
        {
            engineScript.wrongCount++;
            if (engineScript.level == 1)
            {
                engineScript.Question();
            }
            else if (engineScript.level == 2)
            {
                engineScript.Question();
            }
            else if (engineScript.level == 3)
            {
                engineScript.Question();
            }
        }
    }

}
