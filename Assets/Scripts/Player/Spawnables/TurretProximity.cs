using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProximity : MonoBehaviour
{
    public TurretScript turretScript;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        turretScript = transform.parent.gameObject.GetComponent<TurretScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            turretScript.targeting = true;
            turretScript.enemiesInProx.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            turretScript.targeting = false;
            turretScript.enemiesInProx.Remove(other.gameObject);
        }
    }
}
