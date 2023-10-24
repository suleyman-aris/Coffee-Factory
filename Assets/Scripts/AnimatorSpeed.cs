using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeed : MonoBehaviour
{
    public void CoffeActivator()
    {
        transform.parent.GetComponent<CoffeeMachineActivator>().CoffeActivator();
    }
}
