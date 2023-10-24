using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineActivator : MonoBehaviour
{
    private List<Transform> activePozisyon = new List<Transform>();
    List<GameObject> objList;
    private GameObject obje;


    public float waitCoffe = 4.1f;

    List<GameObject> tempList = new List<GameObject>();


    public void PosList()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Debug.Log(transform.GetChild(0).childCount +" "+i+" positionlist");
            activePozisyon.Add(transform.GetChild(0).GetChild(i).transform);
        }
    }
    public void MatchList()
    {
        objList = CoffeList.coffeList.Level_1_Coffe;
    }

    public void CoffeActivator()
    {
        if (objList == null || activePozisyon == null)
        {
            MatchList();
            PosList();
        }

        tempList.Clear();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            int index = this.transform.parent.GetComponent<ActiveCM>().activeChildIndex;
            obje = objList[0];
            obje.GetComponent<ActiveCoffe>().EventCoffe(index);


            obje.transform.position = activePozisyon[i].position;
            transform.GetComponent<CoffePrice>().CoffePriceText();

            objList.RemoveAt(0);

            CoffeList.coffeList.Level_1_Coffe.Add(obje); //Bu Satýrý Test Et

            obje.GetComponent<Rigidbody>().isKinematic = true;
            obje.SetActive(true);

            tempList.Add(obje);
        }
    
    }
    private void OnDisable()
    {
        if (tempList != null)
        {
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i] != null)
                {
                    tempList[i].SetActive(false);
                }
                
            }
        }
    }
}
