using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour
{
    public Transform Target;
    private float desiredRot;
    public float rotSpeed = 250;
    public float damping = 10;

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.z;
    }

    private void Update()
    {
        var desiredRotQ = Quaternion.Euler(Target.transform.eulerAngles.x, Target.transform.eulerAngles.y, Target.transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

}
