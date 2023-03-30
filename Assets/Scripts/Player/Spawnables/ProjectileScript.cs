using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Rigidbody projectileRB;
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileRB.velocity = transform.forward * 50;
    }
}
