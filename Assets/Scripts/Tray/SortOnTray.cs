using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SortOnTray : MonoBehaviour
{
    public static SortOnTray sortOnTray;

    private List<string> levelTags;
    public List<GameObject> spawnPoints;
    public Transform coffeList;
    public int coffeCount;

    private void Awake()
    {
        sortOnTray = sortOnTray == null ? this : sortOnTray ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckLevel(other.transform))
        {
            coffeCount = (coffeCount == 15) ? 0 : coffeCount;
            Sort(other.gameObject);
            coffeCount++;
        }
    }

    private void Sort(GameObject gameobject)
    {
        gameobject.GetComponent<Collider>().enabled = false;
        gameobject.GetComponent<Rigidbody>().isKinematic = true;

        gameobject.transform.DOMove(spawnPoints[coffeCount].transform.position, 0.45f);
    }

    public void CoffeCountZero()
    {
        coffeCount = 0;
    }

    private void Start()
    {
        levelTags = new List<string>()
        {
            "Level_1",
            "Level_2",
            "Level_3",
            "Level_4",
            "Level_5"
        };
    }

    public bool CheckLevel(Transform transform)
    {
        return levelTags.Contains(transform.tag);
    }
}