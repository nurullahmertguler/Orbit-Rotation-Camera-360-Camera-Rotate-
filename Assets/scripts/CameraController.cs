using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    
    float sensivity = 17;

    private void Update()
    {
        

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;


            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference);
        }
        float fov = Camera.main.transform.localPosition.z;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensivity;
        fov = Mathf.Clamp(fov, -0, 40);
        
        Camera.main.transform.localPosition = new Vector3(0, fov / 5 * -1, fov);

        Camera.main.transform.LookAt(hit.point);

        transform.LookAt(target.transform.position);

        SendRaycast();

    }

    private void Zoom(float difference)
    {
        Debug.Log(difference);

        float pos_z = Camera.main.transform.localPosition.z;
        pos_z += difference * .05f;
        pos_z = Mathf.Clamp(pos_z, -0, 40);

        Camera.main.transform.localPosition = new Vector3(0, pos_z / 5 * -1, pos_z);
    }

    public float rayDist = 10;
    RaycastHit hit;
    private void SendRaycast()
    {
        Ray ray = new Ray(transform.position, (target.transform.position - transform.position));

        Physics.Raycast(ray , out hit,rayDist);

        Debug.DrawRay(ray.origin , ray.direction * rayDist, Color.green);

        //Debug.Log(hit.point);
    }

}
