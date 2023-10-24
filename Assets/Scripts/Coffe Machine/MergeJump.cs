using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MergeJump : MonoBehaviour
{
    Vector3 pos;
    public Transform prevPos;

    private void Awake()
    {
        prevPos.position = transform.position;
    }

    public void Jump(int i)
    {
        int jumpObj = PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List.IndexOf(gameObject);
        pos = PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List[jumpObj - i].transform.position;
        //StartCoroutine(JumpAndContinue());
        transform.DOJump(transform.position + Vector3.up * 2, 2, 1, 2f);
        //if (transform.DOJump(transform.position + Vector3.up * 2, 2, 1, 0.3f).IsPlaying())
        //{
        //    Debug.Log("zýplama iþlemi baþarýlý");
        //}
    }
    //IEnumerator JumpAndContinue()
    //{
    //    transform.DOJump(transform.position + Vector3.up * 2, 2, 1, 2f);
    //    yield return new WaitForSeconds(2f); // Zýplama süresi kadar beklenir
    //                                         // Burada diðer satýrlar yer alýr
    //    Debug.Log("Zýplama tamamlandý!");
    //}

    public void BackPos()
    {
        transform.DOKill();
        transform.position = prevPos.position;
        Debug.Log(prevPos.position);
    }

}






//delegate void Merge();
//static event Merge merge;
//// Start is called before the first frame update
//void Awake()
//{
//    int beforObj1 = PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List.IndexOf(gameObject) - 1 ;

//    merge += () => PlatformsSpawnPointsList.platformsSpawnPointsList.spawnPoint_List[beforObj1].GetComponent<ActiveCM>().SelectionCM();

//    merge += MergeClick;
//}

//private void MergeClick()
//{
//    Debug.Log("merge click aaaa"); 
//}

//// Update is called once per frame
//void Update()
//{

//}