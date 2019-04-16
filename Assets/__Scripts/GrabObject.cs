using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{


    private Rigidbody rb;
    public Transform Player;
    public Transform frontofPlayer;
    private bool grabObject;
    private bool inRange;
    private bool bump;

    void Start()
    {
        //to enable proper physical movement of an object
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);
        if (dist <= 5f)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        
        if (grabObject)
        {
            if (bump)
            {
                rb.useGravity = true;
                transform.parent = null;
                grabObject = false;
                bump = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (grabObject)
        {
            bump = true;
            
        }
    }

    private void OnMouseDrag()
    {
        if (inRange )
        {
            rb.useGravity = false;
            transform.parent = frontofPlayer;
            rb.MovePosition(transform.parent.position);
            grabObject = true;
        }

    }
}



