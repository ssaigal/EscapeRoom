using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RoataionAxes
    {
        MouseXAndY = 0,
        MouseX = 1, // for looking side to side
        MouseY = 2 // for looking up and down
    }

    public RoataionAxes axes = RoataionAxes.MouseXAndY;
    public float horizontalSensitivity = 9.0f;
    public float verticalSensitivity = 9.0f;

    // max and min angles for looking up and down
    public float minimumAngle = -45.0f;
    public float maximumAngle = 45.0f;

    private float unityRotateX = 0; // X axis is where unity vertically rotates from, different from MouseX and is MouseY

    // Start is called before the first frame update
    void Start()
    {
        // stops mouse from being affected by other physics in scene
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal Mouse rotation;  Input.GetAxis("Mouse X") is the mouse input
        if (axes == RoataionAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        }
        else if (axes == RoataionAxes.MouseY)
        {
            unityRotateX -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            unityRotateX = Mathf.Clamp(unityRotateX, minimumAngle, maximumAngle);

            float unityRotateY = transform.localEulerAngles.y; // keeps player from spinning when looking up and down
            transform.localEulerAngles = new Vector3(unityRotateX, unityRotateY, 0);
        }
        else
        {
            unityRotateX -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            unityRotateX = Mathf.Clamp(unityRotateX, minimumAngle, maximumAngle);

            float delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float unityRotateY = transform.localEulerAngles.y + delta; // offsets Y position to get mouse to view diagonally and such

            transform.localEulerAngles = new Vector3(unityRotateX, unityRotateY, 0);
        }
    }
}
