using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour
{
    public static StoryHandler instance;

    public int totalfixes = 10, fixesDone = 0;
    public StoryObject[] storyObjects;
    public StoryObject[] postStoryObjects;


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
            if (showedItemsCount < 3)
            {
                if (item.IsDisplayable())
                {
                    //print("!!!!!!!  object: " + item.name + " is being enabled");
                    item.gameObject.SetActive(true);
                    item.anim.Play("placeHolderStory_Show");
                    showedItemsCount++;
                   // print("=======> object: " + item.name + " is resolved");
                }
            }
            else
                break;
        }

        // checking for post-Story Objects
        if (showedItemsCount == 0)
        {
            foreach (StoryObject item in postStoryObjects)
            {
                if (item.IsDisplayable())
                {
                    item.gameObject.SetActive(true);
                    item.anim.Play("placeHolderStory_Show");
                    break;
                }
            }
        }
    }
}
