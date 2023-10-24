using UnityEngine;

public class ActiveCM : MonoBehaviour
{
    public GameObject parentObject;
    public int activeChildIndex = 0;

    private void Awake()
    {
        parentObject = this.gameObject;
    }

    private void Start()
    {
        FindAvtiveCM();
    }

    public void FindAvtiveCM()          
    {
        activeChildIndex = FindActiveChildIndex(parentObject);
    }

    private int FindActiveChildIndex(GameObject parent)
    {
        int activeIndex = 0;

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child.activeSelf)
            {
                activeIndex = i;
                break;
            }
        }

        return activeIndex;
    }

    public void DeActivator()
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void SaveCM(int saveCM)
    {
        transform.GetChild(saveCM).gameObject.SetActive(true);
    }

    public void SelectionCM()   //Merge edilen makinanýn deðiþimi
    {
        parentObject.transform.GetChild(activeChildIndex).gameObject.SetActive(false);
        parentObject.transform.GetChild(activeChildIndex + 1).gameObject.SetActive(true);
        activeChildIndex += 1;
        transform.GetComponent<ParticleEffect>().PlayParticleEffect();
    }

    public void PreviousActiveChild()// Merge edilen makinadan sonraki kahve makinalarýnýn deðiþimidir
    {
        int thisObjectIndex = MatchCMList.matchCMList.gameObjects.IndexOf(parentObject);
        DeActivator();
        if (MatchCMList.matchCMList.gameObjects.Count > thisObjectIndex + 2)        // 2 3
        {
            activeChildIndex = MatchCMList.matchCMList.gameObjects[thisObjectIndex + 2].transform.GetComponent<ActiveCM>().activeChildIndex;
            parentObject.transform.GetChild(activeChildIndex).gameObject.SetActive(true);
            //FindAvtiveCM();
        }
        else
        {
            activeChildIndex = 0;
            parentObject.transform.GetChild(0).gameObject.SetActive(true);
            parentObject.SetActive(false);
        }
            
    }

}
