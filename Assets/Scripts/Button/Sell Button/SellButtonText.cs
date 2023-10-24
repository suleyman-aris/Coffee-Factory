using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButtonText : TextPrint
{
    private float sell;
    // Start is called before the first frame update
    void Start()
    {
        sell = CalculateCoffeMoney.calculateCoffeMoney.sell;
    }

    private void Update()
    {
        if (sell != CalculateCoffeMoney.calculateCoffeMoney.sell)
        {
            Equalize();
            //ButtonPrint(sell.ToString());
            ButtonPrint((int)sell);
        }
    }

    private void Equalize()
    {
        sell = CalculateCoffeMoney.calculateCoffeMoney.sell;
    }
}
