using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAsset : MonoBehaviour
{


    void Start()
    {
        print("checking the object: " + gameObject.name);
        if (PlayerPrefs.GetInt("fix" + this.gameObject.name, 0) == 1)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

   
}
