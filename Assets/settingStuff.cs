using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingStuff : MonoBehaviour
{
    public float audioVolume;
    public AudioMixer audioMixer;
    public Slider sli;

    public Toggle sfx, bgm;

    settingsCarry sc;

    public GameObject clear;
    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.Find("settingsCarry").GetComponent<settingsCarry>();
        sli.value = sc.audioVolume;
        sfx.isOn = sc.sfx;
        bgm.isOn = sc.bgm;

    }

    // Update is called once per frame
    void Update()
    {
        if(sfx.isOn == true)
        {
            AudioSource _sfx = GameObject.Find("SFX").GetComponent<AudioSource>();
            _sfx.enabled = true;
        }
        else
        {
            AudioSource _sfx = GameObject.Find("SFX").GetComponent<AudioSource>();
            _sfx.enabled = false;
        }

        if(bgm.isOn == true)
        {
            AudioSource _bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
            _bgm.enabled = true;
        }
        else
        {
            AudioSource _bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
            _bgm.enabled = false;
        }
    }

    public void SetVolume(Slider s)
    {
        audioMixer.SetFloat("Volume", s.value);
        sc.audioVolume = s.value;
    }

    public void SetAudio()
    {
        sli.value = sc.audioVolume;
    }


    public void SetSFX()
    {
        sc.sfx = sfx.isOn;
    }
    
    public void SetBGM()
    {
        sc.bgm = bgm.isOn;
    }

    public void openClear()
    {
        clear.SetActive(true);
    }

    public void closeClear()
    {
        clear.SetActive(false);
    }

    public void DeletePlayer()
    {
        SaveSystem.DeletePlayer();
        clear.SetActive(false);
    }
}
