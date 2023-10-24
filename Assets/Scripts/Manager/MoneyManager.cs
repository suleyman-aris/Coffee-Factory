using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : TextPrint
{
    public long totalMoney = 0;

    public static MoneyManager moneyManager;

    private void Awake()
    {
        moneyManager = moneyManager == null ? this : moneyManager;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            string i = PlayerPrefs.GetString(transform.name);
            InreaseTotalMoney(System.Convert.ToInt64(i));
        }

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    public void InreaseTotalMoney(float otherMoney)
    {
        totalMoney += (long)otherMoney;
        //string moneyText =  totalMoney.ToString();
        ButtonPrint(totalMoney);
    }

    public void DecreaseTotalMoney(float otherMoney)
    {
        totalMoney -= (long)otherMoney;
        string moneyText = totalMoney.ToString();
        ButtonPrint(totalMoney);
    }

}
