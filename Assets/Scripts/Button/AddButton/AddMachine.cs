using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddMachine : MonoBehaviour
{
    public List<GameObject> gameObjects; // Kontrol edilecek GameObject listesi

    Button addButton;

    private void Start()
    {
        addButton = GameObject.Find("Add Machine").GetComponent<Button>();
    }

    public void MatchList()
    {
        gameObjects = PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List;
        CheckGameObjects();
    }

    private void CheckGameObjects()
    {
        int i ;
        for (i = 0; i < gameObjects.Count; i++)
        {
            GameObject go = gameObjects[i];

            if (!go.activeSelf) // E�er SetActive false ise
            {
                go.SetActive(true); // SetActive true yap
                break; // Di�er elemanlar� kontrol etme, d�ng�den ��k
            }
        }

        //MatchCMList.matchCMList.MatchList();
        MatchCMList.matchCMList.AddButtonClick();

        if (i == gameObjects.Count -1)
        {
            OtherFunction();// T�m elemanlar aktifse ba�ka bir fonksiyonu �a��r            
        }
    }

    private void OtherFunction()
    {
        addButton.GetComponent<EnoughMoney>().CanInteract = false;
        //addButton.GetComponent<ButtonActive>().DeActivateButton();
    }
}
