using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float range = 100f;

    public Camera playerCamera;

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
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red);
            
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
                enemy = null;
            }
        }
    }
}
