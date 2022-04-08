using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplayCarry : MonoBehaviour
{
    private static gameplayCarry instance;
    public int[] star;
    public int[] level;
    public int lvl;
    public int lvlGame;

    // Start is called before the first frame update
    void Start()
    {
        star = new int[3];
        level = new int[3];
        LoadPlayer();
        SavePlayer();   
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

    public static gameplayCarry Instance
    {
        get
        {
            return instance ?? (instance = GameObject.FindObjectOfType(typeof(gameplayCarry)) as gameplayCarry);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if(data != null)
        {
            lvl = data.level;

            for (int x = 0; x < 3; x++)
            {
                level[x] = data.lvl[x];
            }

            for (int x = 0; x < 3; x++)
            {
                star[x] = data.stars[x];
            }
        }
        else
        {
            SavePlayer();
        }
        
    }
}
