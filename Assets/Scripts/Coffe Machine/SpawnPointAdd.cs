using System.Linq;
using UnityEngine;

public class SpawnPointAdd : MonoBehaviour
{
    private void Awake()
    {
        SpawnPointsAdd();   
    }

    private void SpawnPointsAdd()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List.Add(transform.GetChild(i).transform.GetChild(0).gameObject);
        }
        //GameObject[] childObjects = transform.GetComponentsInChildren<GameObject>();
        //foreach (GameObject band in childObjects)
        //{
        //    PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List.Add(band.transform.GetChild(0).gameObject);
        //}
    }
}
