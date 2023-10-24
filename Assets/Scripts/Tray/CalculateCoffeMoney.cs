using System;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCoffeMoney : MonoBehaviour
{
    public static CalculateCoffeMoney calculateCoffeMoney;

    public float sell = 0;
    private List<string> levelTags;

    private void Awake()
    {
        calculateCoffeMoney = calculateCoffeMoney == null ? this : calculateCoffeMoney;
    }

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
            CalculateSell(other.GetComponent<ActiveCoffe>().indexCoffe);
        }
    }

    public void SellZero()
    {
        AddMainMoney();
        sell = 0;
    }

    private void AddMainMoney()
    {
        // Ana Paraya eklenicek kýsým
    }

    private void CalculateSell(int indexCoffe)
    {
        sell += CoffesMoney.coffesMoney.floatList[indexCoffe];
    }

    public bool CheckLevel(Transform transform)
    {
        return levelTags.Contains(transform.tag);
    }
}
