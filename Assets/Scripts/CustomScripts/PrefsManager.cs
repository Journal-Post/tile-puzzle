using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
   public static PrefsManager instance;

    public static string _stars = "starsGem";





    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public static void AddStars(int  starCount)
    {
        int newStars = (starCount + PlayerPrefs.GetInt(_stars,0));
        print("Stars added :: new stars are: " +  newStars);
        PlayerPrefs.SetInt(_stars, newStars);
    }
    public static int ShowStars()
    {
        return PlayerPrefs.GetInt(_stars, 0);
    }

}
