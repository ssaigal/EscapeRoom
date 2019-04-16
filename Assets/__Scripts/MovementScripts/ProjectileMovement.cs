using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private GameObject explosionAnimation;

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosionAnimation =Instantiate(explosionPrefab, transform.position, Quaternion.identity);

       
        
        Destroy(gameObject);

        // Destroy the animation object after 2 seconds
        Destroy(explosionAnimation, 2);

    }


}
