using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsSpawnPointsList : MonoBehaviour
{
    public static PlatformsSpawnPointsList platformsSpawnPointsList;

    public List<GameObject> spawnPoint_List;

    private void Awake()
    {
        platformsSpawnPointsList = platformsSpawnPointsList == null ? this : platformsSpawnPointsList;
    }
}