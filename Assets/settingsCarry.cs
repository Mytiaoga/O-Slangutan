using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsCarry : MonoBehaviour
{
    private static settingsCarry instance;
    public float audioVolume;
    public bool sfx, bgm;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static settingsCarry Instance
    {
        get
        {
            return instance ?? (instance = GameObject.FindObjectOfType(typeof(settingsCarry)) as settingsCarry);
        }
    }
}
