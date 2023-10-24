using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayList : MonoBehaviour
{
    private List<string> levelTags;
    public List<GameObject> gameObjectOnTray;
    private void Start()
    {
        levelTags = new List<string>()
        {
            "Level_1",
            "Level_2",
            "Level_3",
            "Level_4",
            "Level_5"
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckLevel(other.transform))
        {
            AddList(other.gameObject);
        }
    }

    private bool CheckLevel(Transform transform)
    {
        return levelTags.Contains(transform.tag);
    }

    public void AddList(GameObject triggerObject)
    {
        gameObjectOnTray.Add(triggerObject);
    }

    public void ListDeActive()
    {
        foreach (var item in gameObjectOnTray)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void TrayListSell()
    {
        CalculateCoffeMoney.calculateCoffeMoney.SellZero();
        
        //Ana Paraya ekleyecek fonksiyon yazýlacak
    }

    public void ListClear()
    {
        gameObjectOnTray.Clear();
    }
}
