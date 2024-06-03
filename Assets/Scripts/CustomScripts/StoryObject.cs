using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryObject : MonoBehaviour
{
    public string objectId;
    public int starsRequired = 2;
    int starsAvailable = 0;
    public Text starsTxt;
    public Animator anim;
    public bool doneStatus = false, isBonusFix = false;

    public GameObject[] dependableBrokens, dependableFixed;


    [ContextMenu("set Start Values")]
    public void Start()
    {
        anim = GetComponent<Animator>();
        objectId = this.gameObject.name;
    }

    private void OnEnable()
    {
        starsAvailable = PrefsManager.ShowStars();    
    }

    public bool IsDisplayable()
    {
        if (objectId == null) objectId = this.gameObject.name;

        if (PlayerPrefs.GetInt("fix" + objectId, 0) == 0)
            return true;
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Function to be worked on clicking the fix Object
    /// </summary>
    public void CheckToFix()
    {
        if (starsAvailable >= starsRequired)
        {
            StartCoroutine(FixObject());
        }
        else
        {
            // unclickable Animation
            anim.Play("placeHolderStory_Cancel");
        }
    }
    IEnumerator FixObject()
    {
        // disablity bool
        PlayerPrefs.SetInt("fix" + objectId, 1);

        // hide Animation
        anim.Play("placeHolderStory_Hide");

        // remove the broken objects
        foreach (GameObject item in dependableBrokens)
        {
            item.GetComponent<Animator>().enabled = true;
        }
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject item in dependableBrokens)
        {
            item.SetActive(false);
        }

        // show the fixed objects
        foreach (GameObject item in dependableFixed)
        {
            item.SetActive(true);
        }

        // repopulate list of placeholders in storyHandler
        StoryHandler.instance.RefreshPlaceHolders();
    }
}
