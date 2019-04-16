using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject projectile;
    public Transform firepoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player right clicks, create new projectile that will fire
        if (Input.GetMouseButtonDown(1))
        {
            
                // instantiate the prefab that was dragged into script and create instance as projectile
                projectile = Instantiate(projectilePrefab) as GameObject;
                projectile.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                projectile.transform.rotation = transform.rotation;
            
        }
    }
}
