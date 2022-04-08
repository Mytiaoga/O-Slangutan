using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField] GameObject Engine;
    Engine engineScript;
    private void Start()
    {
        engineScript = Engine.GetComponent<Engine>();
    }
    public void OnButtonPress()
    {
        engineScript.Hint();
        
        engineScript.hintCount--;
    }
}
