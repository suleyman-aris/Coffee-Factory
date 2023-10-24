using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePhone : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            int i = PlayerPrefs.GetInt(transform.name);
            if (i > 0)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<ActiveCM>().DeActivator();
                transform.GetChild(0).GetComponent<ActiveCM>().SaveCM(i - 1);
            }
        }

    }

    private void OnApplicationQuit()
    {
        if (transform.GetChild(0).gameObject.activeSelf == true)
        {
            PlayerPrefs.SetInt(transform.name, transform.GetChild(0).GetComponent<ActiveCM>().activeChildIndex + 1);
            PlayerPrefs.Save();
        }

    }


}
