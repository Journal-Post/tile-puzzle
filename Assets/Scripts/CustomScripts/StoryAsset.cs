using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAsset : MonoBehaviour
{
    public bool isBrokenAsset = false;

    [Tooltip("Same as StoryObject.cs gameobject")]
    public string objectID = string.Empty;

    void Start()
    {
        //print("checking the object: " + gameObject.name);
        if (!isBrokenAsset)
        {
            if (PlayerPrefs.GetInt("fix" + objectID, 0) == 1)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("fix" + objectID, 0) == 1)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    
    
    
    }

   
}
