using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public int[] lvl;
    public int[] star;
    public GameObject[] locks;
    public Button[] buttons;

    gameplayCarry gc;

    public Toggle[] sta = new Toggle[9];

    void Start()
    {
        lvl = new int[3];
        star = new int[3];
        //buttons = new Button[3];

        buttons[1].interactable = false;
        buttons[2].interactable = false;

        gc = GameObject.Find("gameplayCarry").GetComponent<gameplayCarry>();

        //foreach(int a in lvl)
        //{
        //    lvl[a] = gc.level[a];
        //    star[a] = gc.star[a];
        //}

        for(int x = 0; x < 3; x++)
        {
            lvl[x] = gc.level[x];
            star[x] = gc.star[x];
        }

        if(lvl[0] == 1)
        {
            locks[0].SetActive(false);
            buttons[1].interactable = true;
            if (star[0] >= 1)
            {
                sta[0].isOn = true;
                if(star[0] >= 2)
                {
                    sta[1].isOn = true;
                    if (star[0] >= 3)
                    {
                        sta[2].isOn = true;
                    }
                }
            }
        }

        if(lvl[1] == 2)
        {
           locks[1].SetActive(false);
            buttons[2].interactable = false;
            if (star[1] >= 1)
            {
                sta[3].isOn = true;
                if (star[1] >= 2)
                {
                    sta[4].isOn = true;
                    if (star[1] >= 3)
                    {
                        sta[5].isOn = true;
                    }
                }
            }
        }

        if(lvl[2] == 3)
        {
            if (star[2] >= 1)
            {
                sta[6].isOn = true;
                if (star[2] >= 2)
                {
                    sta[7].isOn = true;
                    if (star[2] >= 3)
                    {
                        sta[8].isOn = true;
                    }
                }
            }
        }
        
    }

    public void level1()
    {
        gc.lvlGame = 1;
    }
    public void level2()
    {
        gc.lvlGame = 2;
    }
    public void level3()
    {
        gc.lvlGame = 3;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
