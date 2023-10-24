using System.Collections.Generic;
using UnityEngine;

public class MatchCMList : MonoBehaviour
{
    public static MatchCMList matchCMList;

    public List<GameObject> gameObjects;

    public Dictionary<int, List<GameObject>> levelObjects;

    private void Awake()
    {
        matchCMList = matchCMList == null ? this : matchCMList;
    }
    private void Start()
    {
        AddButtonClick();
    }

    public void AddButtonClick()
    {
        MatchList();
        ProcessGameObjects();
    }

    public void MatchList()
    {
        gameObjects = PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List;
        gameObjects = gameObjects.FindAll(go => go.activeSelf);
    }

    public void ProcessGameObjects()
    {
        if (gameObjects.Count > 0)
        {
            CreateList();
            CheckGameObjects();
        }
    }

    public void CreateList()
    {
        levelObjects = new Dictionary<int, List<GameObject>>();
        for (int i = 1; i <= gameObjects[0].transform.childCount ; i++)
        {
            levelObjects[i] = new List<GameObject>();
        }
    }

    public void CheckGameObjects()
    {
        foreach (GameObject go in gameObjects)
        {

            int childIndex = go.transform.GetComponent<ActiveCM>().activeChildIndex + 1;
            levelObjects[childIndex].Add(go);
        }
    }
}
