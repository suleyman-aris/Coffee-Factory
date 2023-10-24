using System.Linq;
using UnityEngine;

public class BandPanelControl : MonoBehaviour
{
    private void Start()
    {
        BandDeActive();
        PanelIndexActive();
    }
    public void PanelActivator()
    {
        BandDeActive();
        PanelIndexActive();
    }

    private void BandDeActive()
    {
        foreach (GameObject item in BandPanelActive.panelActive.panelList)
        {
            item.SetActive(false);
        }
    }
    public void PanelIndexActive()
    {
        int activeCount = BandListManager.bandList.Bands.Count(obj => obj.activeSelf);
        Debug.Log("Band Panel Active count" + activeCount);
        if (activeCount <= 2)
        {
            BandPanelActive.panelActive.panelList[activeCount - 1].SetActive(true);
            Debug.Log("BAnd Panel " + (activeCount - 1));
        }

    }
}
