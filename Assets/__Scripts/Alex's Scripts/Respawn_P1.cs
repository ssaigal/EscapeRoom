using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_P1 : MonoBehaviour
{
    [SerializeField] private GameObject respawn;

    private FPMovement stopMovement;
    public Rigidbody rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject g = GameObject.Find("Player");
        stopMovement = g.GetComponent<FPMovement> ();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Respawn")
        {   
            //animator.SetTrigger("FadeOut");
            stopMovement.speed = .5f;
            StartCoroutine(ExecuteAfterTime(.5f));
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = respawn.transform.position;
        //animator.SetTrigger("FadeIn");
        stopMovement.speed = 5;
    }
}