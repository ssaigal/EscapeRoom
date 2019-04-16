using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    
    private bool cameraUp = false;
    private bool cameraDown = false;
    private Camera cameraview;
    public GameObject topDown;
    public GameObject thirdPerson;
    

   
    // Start is called before the first frame update
    void Start()
    {
        cameraview = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraUp)
        {
            topDownview();
        }

        if(cameraDown)
        {
            thirdPersonView();
        }
        

        if(Input.GetKey(KeyCode.Space))
        {
            cameraUp = true;
            cameraDown = false;
        }

        if (Input.GetKey(KeyCode.V))
        {
            cameraUp = false;
            cameraDown = true;
        }


    }

    void topDownview()
    {
        if (cameraUp)
        {

            Vector3 cameraCurrentPosition = cameraview.transform.position;
            Quaternion cameraCurrentRotation = cameraview.transform.rotation;
            
            cameraview.transform.position = Vector3.Lerp(cameraCurrentPosition, topDown.transform.position, Time.deltaTime * 2.0f);
            cameraview.transform.rotation = Quaternion.Lerp(cameraCurrentRotation, topDown.transform.rotation, Time.fixedDeltaTime * 2.0f);
        }
    }

    void thirdPersonView()
    {
        if (cameraDown)
        {
            Vector3 cameraCurrentPosition = cameraview.transform.position;
            Quaternion cameraCurrentRotation = cameraview.transform.rotation;

            cameraview.transform.position = Vector3.Lerp(cameraCurrentPosition, thirdPerson.transform.position, Time.deltaTime * 2.0f);
            cameraview.transform.rotation = Quaternion.Lerp(cameraCurrentRotation, thirdPerson.transform.rotation, Time.fixedDeltaTime * 2.0f);
        }
    }
}
