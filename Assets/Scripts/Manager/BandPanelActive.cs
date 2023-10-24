using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandPanelActive : MonoBehaviour
{
    public static BandPanelActive panelActive;

    public List<GameObject> panelList;

    private void Awake()
    {
        panelActive = panelActive == null ? this : panelActive;
    }
}
