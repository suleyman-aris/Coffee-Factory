using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCoffe : MonoBehaviour
{
    private void OnEnable()
    {
        transform.GetComponent<Collider>().enabled = true;
    }
    public int indexCoffe;
    public void EventCoffe(int index)
    {
        DeActivator();
        RgbActive();
        OneActive(index);

    }

    private void RgbActive()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Collider>().enabled = true;
   }

    private void OneActive(int index)
    {
        transform.GetChild(index).gameObject.SetActive(true);
        indexCoffe = index;
    }

    private void DeActivator()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
