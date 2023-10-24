using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System;

public class CoffeJump : MonoBehaviour
{
    public float arrivalTime = 0.2f;
    public Transform target;
    Vector3 targetTemp;

    public float beforeJump = 2.95f;

    CoffeeMachineActivator coffeeMachineActivator;
    //Button mergeButton;

    //bool isClick = false;

    private void Awake()
    {
        GameObject[] conveyorBelts = GameObject.FindGameObjectsWithTag("ConveyorBelt");

        if (conveyorBelts.Length > 0)
            target = conveyorBelts[0].transform;

        targetTemp = target.position;
    }
    private void OnEnable()
    {
        JumpPos();
        Jump();
    }


    public void JumpPos()
    {
        if (transform.position.x > targetTemp.x)
            targetTemp = new Vector3(transform.position.x - 0.5f, transform.position.y, this.transform.position.z);    //  targetTemp.y + 0.1f
        else
            targetTemp = new Vector3(transform.position.x + 0.5f, transform.position.y, this.transform.position.z);    //  targetTemp.y + 0.1f
    }

    private void IsKnematic()
    {
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void Jump()
    {
        StartCoroutine(WaitCoroutine(beforeJump, () =>
        {
            IsKnematic();

            transform.DOMove(targetTemp, arrivalTime);

        }));
    }
    private IEnumerator WaitCoroutine(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}
