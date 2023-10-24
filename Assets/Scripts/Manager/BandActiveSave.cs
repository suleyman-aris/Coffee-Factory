using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandActiveSave : MonoBehaviour
{
    public int activeBandCount = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("bandActiveCount"))
        {
            activeBandCount = PlayerPrefs.GetInt("bandActiveCount");
            for (int i = 0; i < activeBandCount; i++)
            {
                BandListManager.bandList.Bands[i].SetActive(true);
            }
        }
    }

    private void OnApplicationQuit()
    {
        //activeBandCount = 0;
        //foreach (GameObject band in BandListManager.bandList.Bands)
        //{
        //    if (band.activeSelf)
        //    {
        //        activeBandCount++;
        //    }
        //}
        PlayerPrefs.SetInt("bandActiveCount", activeBandCount);
        PlayerPrefs.Save();
    }
}
