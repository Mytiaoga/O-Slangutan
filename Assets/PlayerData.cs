using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    //For Player
    public int level;
    public int[] stars;
    public bool[] locked;
    public int[] lvl;

    //For Settings
    public PlayerData (gameplayCarry gc)
    {
        stars = new int[3];
        lvl = new int[3];
        //foreach (int m in gc.star)
        //{
        //    stars[m] = m;
        //    //Debug.Log(m);
        //}

        for (int x = 0; x < 3; x++)
        {
            lvl[x] = gc.level[x];
        }

        for (int x = 0; x < 3; x++)
        {
            stars[x] = gc.star[x];
        }

        //foreach (int m in gc.level)
        //{
        //    //Debug.Log(m);
        //    lvl[m] = m;
        //}
        

        level = gc.lvl;
        
        //foreach(bool m in gc.locks)
        //{
        //    locked[n] = m;
        //    ++n;
        //}
    }
}
