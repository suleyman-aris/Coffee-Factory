using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetData()
    {
        List<GameObject> resetList = MatchCMList.matchCMList.gameObjects;
        for (int i = 0; i < resetList.Count; i++)
        {
            resetList[i].GetComponent<ActiveCM>().activeChildIndex = -1;
            //resetList[i].transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log(resetList[i].name);
        }
        //foreach (GameObject item in MatchCMList.matchCMList.gameObjects)
        //{
        //    item.GetComponent<ActiveCM>().activeChildIndex = -1;
        //    item.transform.GetChild(0).gameObject.SetActive(true);
            
        //}
        IncomeButtonReset();
        AddCMButtonReset();
        MergeButtonReset();
        CoffePriceReset();
        TotalMoneyReset();
        BandCountReset();
        QuitGame();
    }

    private void BandCountReset()
    {
        BandActiveSave resetBand = GameObject.Find("Band List Manager").GetComponent<BandActiveSave>();
        resetBand.activeBandCount = 1;
        //for (int i = 1; i < BandListManager.bandList.Bands.Count; i++)
        //{
        //    BandListManager.bandList.Bands[i].SetActive(false);
        //}
    }

    private void TotalMoneyReset()
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<MoneyManager>().totalMoney = 0;
    }

    private void CoffePriceReset()
    {
        CoffesMoney.coffesMoney.floatList[0] = 1;
        CoffesMoney.coffesMoney.floatList[1] = 5;
        CoffesMoney.coffesMoney.floatList[2] = 10;
        CoffesMoney.coffesMoney.floatList[3] = 25;
        CoffesMoney.coffesMoney.floatList[4] = 50;
    }

    private void MergeButtonReset()
    {
        GameObject mergeButton = GameObject.Find("Merge");
        mergeButton.GetComponent<EnoughMoney>().clickCount = 1;
    }

    private void AddCMButtonReset()
    {
        GameObject addCmButton = GameObject.Find("Add Machine");
        addCmButton.GetComponent<EnoughMoney>().clickCount = 1;
    }

    private void IncomeButtonReset()
    {
        GameObject incomeButton = GameObject.Find("Income");
        incomeButton.GetComponent<EnoughMoney>().clickCount = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
