using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    GameObject tray;
    private void Awake()
    {
        tray = GameObject.FindGameObjectWithTag("Tray").transform.GetChild(0).gameObject;
    }

    private void Update()
    {

        if (tray.GetComponent<TrayList>().gameObjectOnTray.Count >= 15)         //      Tepsi Dolduðunda kullanýlýr.
        {
            TrayFull();
        }
    }

    public void TrayFull()
    {
        tray.GetComponent<TrayList>().ListDeActive();
        tray.GetComponent<TrayList>().ListClear();
        MoneyManager.moneyManager.InreaseTotalMoney(CalculateCoffeMoney.calculateCoffeMoney.sell);
        tray.GetComponent<TrayList>().TrayListSell();
        tray.GetComponent<SortOnTray>().CoffeCountZero();
        transform.GetComponent<ParticleEffect>().MoneyEffect();
    }
}
