using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{

    public UnityEvent startEvents, DelayEvent;
    void Start()
    {
        startEvents.Invoke();
    }

    public void DelayEvents(float f)
    {
        StartCoroutine(EventDelayer(f));
    }
    IEnumerator EventDelayer(float f)
    {
        yield return new WaitForSeconds(f);
        DelayEvent.Invoke();
    }
    
}
