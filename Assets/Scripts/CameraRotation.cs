using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float RotationSpeed;
    public int minAngle;
    public int maxAngle;
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);
        
        var newAngle = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngle > 180)
        {
            newAngle -= 360;
        }
        
        newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
        
        CameraAxisTransform.localEulerAngles = new Vector3(newAngle, 0, 0);
    }
}
