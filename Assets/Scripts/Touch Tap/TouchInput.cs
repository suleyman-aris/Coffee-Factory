using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private float time = 3f;

    public List<GameObject> cmList;
    public List<GameObject> coffeList;
    public List<GameObject> ConveyorBeltList;

    public float waitCoffe = 2.05f;
    public float animSpeed = 1f;

    private float arriveTime = 0.1f;
    private float beforeJump = 1.475f;
    private float conveyorBandSpeed = 1.5f;
    private bool isTimerRunning;


    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            time += Time.deltaTime;
            if (time > 2.0f)
            {
                isTimerRunning = false;
                time = 3f;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isTimerRunning = true;
                time = 0;
                conveyorBandSpeed = 1.25f;
                beforeJump = 1.475f;
                arriveTime = 0.5f;
                waitCoffe = 2.05f;
                animSpeed = 2;

                ActiveCMNow();
                ActiveCoffeNow();
                CMWaitCoffe();
                CoffeJumpWait();
                ConveyorBeltSpeed();
                AnimationSpeed();
                Vibrate();
            }

        }
        if (time == 3f)
        {
            conveyorBandSpeed = 0.5f;
            beforeJump = 2.95f;
            arriveTime = 1.5f;
            waitCoffe = 4.1f;
            animSpeed = 1f;

            ActiveCMNow();
            ActiveCoffeNow();
            CMWaitCoffe();
            CoffeJumpWait();
            ConveyorBeltSpeed();
            AnimationSpeed();
        }
    }
    public void Vibrate()
    {
        if (Application.platform == RuntimePlatform.Android )
        {
            Vibrator.Vibrate(50);
        }
    }

    private void AnimationSpeed()
    {
        foreach (GameObject obj in coffeList)
        {
            if (obj.CompareTag("CM_1"))
            {
                //Debug.Log("Animation Speed  " + obj.GetComponent<Animator>().speed);
                obj.GetComponent<Animator>().speed = animSpeed;

                obj.transform.GetChild(2).GetComponent<Animator>().speed = animSpeed;
            }
            else if (obj.CompareTag("CM_2"))
            {
                obj.transform.GetChild(1).GetComponent<Animator>().speed = animSpeed;
            }
            else if (obj.CompareTag("CM_3"))
            {
                obj.transform.GetChild(1).GetComponent<Animator>().speed = animSpeed;
                obj.transform.GetChild(2).GetComponent<Animator>().speed = animSpeed;
            }
            else if (obj.CompareTag("CM_4"))
            {
                obj.transform.GetChild(1).GetComponent<Animator>().speed = animSpeed;
                obj.transform.GetChild(2).GetComponent<Animator>().speed = animSpeed;
            }
            else if (obj.CompareTag("CM_5"))
            {
                obj.GetComponent<Animator>().speed = 0.6f;
                obj.transform.GetChild(3).GetComponent<Animator>().speed = animSpeed;
                obj.transform.GetChild(4).GetComponent<Animator>().speed = animSpeed;
            }
        }
    }

    private void ConveyorBeltSpeed()
    {
        foreach (GameObject band in BandListManager.bandList.Bands)
        {
            if (band.activeSelf)
            {
                band.GetComponent<ConveyorBeltController>().speed = conveyorBandSpeed;
            }
        }
    }

    private void CoffeJumpWait()
    {
        foreach (GameObject obj in CoffeList.coffeList.Level_1_Coffe)
        {
            obj.GetComponent<CoffeJump>().beforeJump = beforeJump;
            obj.GetComponent<CoffeJump>().arrivalTime = arriveTime;
        }

    }

    private void CMWaitCoffe()
    {
        foreach (GameObject obj in coffeList)
        {
            obj.GetComponent<CoffeeMachineActivator>().waitCoffe = waitCoffe;
        }
    }

    private void ActiveCoffeNow()
    {
        coffeList.Clear();
        foreach (GameObject obj in cmList)
        {
            if (obj != null && obj.activeSelf)
            {
                Transform parentTransform = obj.transform;


                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    GameObject childObject = parentTransform.GetChild(i).gameObject;


                    if (childObject.activeSelf)
                    {
                        coffeList.Add(childObject);
                    }
                }
            }
        }
    }

    private void ActiveCMNow()
    {
        cmList = MatchCMList.matchCMList.gameObjects;
    }
}
