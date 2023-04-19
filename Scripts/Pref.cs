using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    public static int BestScore { get =>PlayerPrefs.GetInt(PrefKey.BestScore.ToString(),0); 
                                  set{
            int old = PlayerPrefs.GetInt(PrefKey.BestScore.ToString(), 0);
            if (old==0||old<value)
            {
                PlayerPrefs.SetInt(PrefKey.BestScore.ToString(), value);
            }

    } }
}
