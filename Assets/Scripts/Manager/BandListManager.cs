using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandListManager : MonoBehaviour
{
    public static BandListManager bandList;

    public List<GameObject> Bands;

    private void Awake()
    {
        bandList = bandList == null ? this : bandList;
    }
}
