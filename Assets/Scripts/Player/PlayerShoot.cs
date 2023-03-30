using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float range = 100f;

    public Camera playerCamera;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(projectile, transform.position, playerCamera.transform.rotation);
        }
        
    }
}
