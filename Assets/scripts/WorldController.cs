using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private float rotateSpeedValue;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Input.touchCount < 2)
        {
            SpeedValueCheck();

            transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeedValue, Input.GetAxis("Mouse X") * -rotateSpeedValue, 0, Space.World);
        }
    }

    private void SpeedValueCheck()
    {
        float z_value = Camera.main.transform.localPosition.z;

        rotateSpeedValue = (rotateSpeed - (z_value / 10)) / 4;
    }
}