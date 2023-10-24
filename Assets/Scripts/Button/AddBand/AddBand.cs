using System;
using System.Linq;
using UnityEngine;

public class AddBand : MonoBehaviour
{
    public float enoughMoney;
    bool canInteract;
    private void Start()
    {
        BandDeActive();
    }
    public void BandActive()
    {
        BandListManager.bandList.Bands.FirstOrDefault(band => !band.activeSelf)?.SetActive(true);  // listede ilk bulduðu bandý SetActive(true) yapýyor       
    }

    public void BandDeActive()
    {
        foreach (var band in BandListManager.bandList.Bands)
        {
            if (!band.activeSelf)
            {
                canInteract = true;
                break;
            }
            canInteract = false;
        }
    }

    private void Update()
    {
        if (MoneyManager.moneyManager.totalMoney >= enoughMoney && canInteract)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (MoneyManager.moneyManager.totalMoney < enoughMoney && canInteract)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
