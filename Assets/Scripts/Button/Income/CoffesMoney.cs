using UnityEngine;
using System.Collections.Generic;

public class CoffesMoney : MonoBehaviour
{
    public static CoffesMoney coffesMoney;

    public List<float> floatList = new List<float> { 1f, 5f, 10f, 25f, 50f };
    List<float> tempList = new List<float> { 1f, 5f, 10f, 25f, 50f };

    private void Awake()
    {
        coffesMoney = coffesMoney == null ? this : coffesMoney;
        if (PlayerPrefs.HasKey("floatListFirst"))
        {
            floatList[0] = PlayerPrefs.GetFloat("floatListFirst");
            floatList[1] = PlayerPrefs.GetFloat("floatListSecond");
            floatList[2] = PlayerPrefs.GetFloat("floatListThird");
            floatList[3] = PlayerPrefs.GetFloat("floatListFourth");
            floatList[4] = PlayerPrefs.GetFloat("floatListFifth");
            
        }

    }

    private void Start()
    {
        transform.GetComponent<EnoughMoney>().CanInteract = true;
    }

    public void MultiplyListValues(float multiplier)
    {
        for (int i = 0; i < floatList.Count; i++)
        {
            floatList[i] = Mathf.RoundToInt(floatList[i] + tempList[i]);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("floatListFirst", floatList[0]);
        PlayerPrefs.SetFloat("floatListSecond", floatList[1]);
        PlayerPrefs.SetFloat("floatListThird", floatList[2]);
        PlayerPrefs.SetFloat("floatListFourth", floatList[3]);
        PlayerPrefs.SetFloat("floatListFifth", floatList[4]);
        PlayerPrefs.Save();
    }
}
