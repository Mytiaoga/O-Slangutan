using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds_sfx : MonoBehaviour
{
    private static sounds_sfx instance;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aud.Play();
        }
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

    public static sounds_sfx Instance
    {
        get
        {
            return instance ?? (instance = GameObject.FindObjectOfType(typeof(sounds_sfx)) as sounds_sfx);
        }
    }
}
