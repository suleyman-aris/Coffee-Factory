using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeList : MonoBehaviour
{
    public static CoffeList coffeList;

    public List<GameObject> Level_1_Coffe;

    private void Awake()
    {
        coffeList = coffeList == null ? this : coffeList;
    }
}
