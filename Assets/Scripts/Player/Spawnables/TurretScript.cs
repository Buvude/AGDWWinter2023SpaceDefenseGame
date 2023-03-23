using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public bool targeting;
    public List<GameObject> enemiesInProx;
    public float shortestDistance;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targeting)
        {
            for (int i = 0; i < enemiesInProx.Count; i++)
            {
                distance = Vector3.Distance(enemiesInProx[i].transform.position, transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, enemiesInProx[i].transform.rotation, 1);
                    //Vector3 target = Vector3.RotateTowards(transform.forward, enemiesInProx[i].transform.position, 1, 1);
                    //transform.rotation = Quaternion.LookRotation(target);
                    transform.LookAt(enemiesInProx[i].transform);
                }
            }
        }
    }
}
