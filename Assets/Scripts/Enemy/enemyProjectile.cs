using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    public NMA Parent;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        print("spawned projectile");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
        //print("Trigger entered");
    }

    
}
