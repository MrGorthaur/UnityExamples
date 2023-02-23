using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class Grab : MonoBehaviour
{
    TwoBoneIKConstraint grabConstraint;
    Transform _grabTarget;
    GameObject fruit;
   
    

    private void Start()
    {
        grabConstraint = GetComponentInChildren<TwoBoneIKConstraint>();
        _grabTarget = grabConstraint.data.target;
        fruit = GameObject.FindWithTag("fruit");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.EndsWith("(Clone)"))
        _grabTarget.position = other.transform.position;
        
    }


}