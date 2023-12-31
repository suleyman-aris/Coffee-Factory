using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MergeMachine : MonoBehaviour
{
    private Button mergeButton;
    private List<GameObject> firstLevelObjects;
    public bool mergeEnabled = false;
    private Button addButton;
    private int mergeİndex;

    // Start is called before the first frame update
    void Awake()
    {
        addButton = GameObject.Find("Add Machine").GetComponent<Button>();
        mergeButton = GameObject.Find("Merge").GetComponent<Button>();
        MergeEnabled();
        mergeButton.onClick.AddListener(MergeClick);
        addButton.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        //int lenght = MatchCMList.matchCMList.gameObjects.Count;
        mergeEnabled = false;
        for (mergeİndex = 1; mergeİndex < 5; mergeİndex++)
        {
            if (MatchCMList.matchCMList.levelObjects[mergeİndex].Count >= 3)
            {                
                mergeEnabled = true;                
                break;
            }
        }
        MergeEnabled();
    }

    public void MergeClick() 
    {
        firstLevelObjects = MatchCMList.matchCMList.levelObjects[mergeİndex];
        ChangeMachine(mergeİndex);
        MatchCMList.matchCMList.MatchList();
        MatchCMList.matchCMList.ProcessGameObjects();
        ButtonClicked();
    }

    private void MergeEnabled()
    {
        if (mergeEnabled)
            transform.GetComponent<EnoughMoney>().CanInteract = true;
        else
            transform.GetComponent<EnoughMoney>().CanInteract = false;
    }

    private void ChangeMachine(int machineLevel)
    {
        GameObject mergeMachine = firstLevelObjects[0];
        mergeMachine.GetComponent<ActiveCM>().SelectionCM();
        int index = MatchCMList.matchCMList.gameObjects.IndexOf(mergeMachine);  // Aktif CM'lerde kaçıncı indiste olduğunu buluyor
        AddButtonActive();
        for (int i = index + 1; i < MatchCMList.matchCMList.gameObjects.Count; i++)
        {
            MatchCMList.matchCMList.gameObjects[i]
                                   .GetComponent<ActiveCM>()
                                   .PreviousActiveChild();
        }
    }
    private void AddButtonActive()
    {
        addButton.GetComponent<EnoughMoney>().CanInteract = true;
    }

    private IEnumerator WaitCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Çalışmaktadır");
    }
}