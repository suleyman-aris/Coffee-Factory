using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffePrice : MonoBehaviour
{
    public GameObject priceText;
    Vector3 insPos;
    int CMShort;

    private void Awake()
    {
        insPos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z + 2);

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform == transform.parent.GetChild(i))
            {
                CMShort = i;
                break;
            }
        }
    }

    public void CoffePriceText()
    {
        GameObject newTextPrice = Instantiate(priceText, transform.position, Quaternion.identity);
        int miktar = (int)CoffesMoney.coffesMoney.floatList[CMShort];
        if (miktar >= 1000000000)
        {
            newTextPrice.GetComponent<TextMesh>().text = "+" + (miktar / 1000000000) + " b";
        }
        else if (miktar >= 1000000)
        {
            newTextPrice.GetComponent<TextMesh>().text = "+" + (miktar / 1000000) + " m";
        }
        else if (miktar >= 1000)
        {
            newTextPrice.GetComponent<TextMesh>().text = "+" + (miktar / 1000) + " k";
        }
        else
        {
            newTextPrice.GetComponent<TextMesh>().text = "+" + miktar.ToString();
            Debug.Log(miktar);
        }
        newTextPrice.GetComponent<Rigidbody>().velocity = Vector3.up;

        Destroy(newTextPrice, 1.5f);
    }
}
