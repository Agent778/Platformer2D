using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    void Update()
    {
        Vector3 targetpos = target.transform.position;
        targetpos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime);
    }
}
