using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour
{
    public static StoryHandler instance;

    public int totalfixes = 10, fixesDone = 0;
    public StoryObject[] storyObjects;



    private void Awake()
    {
        instance = (instance == null) ? this : instance;
    }
    private void OnEnable()
    {
        RefreshPlaceHolders();
    }

    public void RefreshPlaceHolders()
    {
        int showedItemsCount = 0;
        foreach (StoryObject item in storyObjects)
        {
            if (showedItemsCount < 4)
            {
                if (item.IsDisplayable())
                {
                    print("!!!!!!!  object: " + item.name + " is being enabled");
                    item.gameObject.SetActive(true);
                    item.anim.Play("placeHolderStory_Show");
                    showedItemsCount++;
                    print("=======> object: " + item.name + " is resolved");
                }
            }
            else
                break;
        }
    }
}
