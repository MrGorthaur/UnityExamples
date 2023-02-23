using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]Transform endPoint;
    float _speed =2f;

private void OnTriggerStay(Collider other) {
    other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,endPoint.position,_speed * Time.deltaTime);
   }
}
