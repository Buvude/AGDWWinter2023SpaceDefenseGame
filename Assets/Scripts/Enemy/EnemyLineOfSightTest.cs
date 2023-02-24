using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSightTest : MonoBehaviour
{
    public int distanceforLOS;
    internal NMA Mvmt;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Mvmt = this.gameObject.GetComponent<NMA>();
    }

    // Update is called once per frame
    void Update()
    {
        Targetable();
        /*HaveLineOfSight();*/
    }

    public bool Targetable()
    {
        Vector3 directionToTarget = transform.position - Target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        //if in range
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270&&HaveLineOfSight())
        {
            Debug.DrawLine(transform.position, Target.position, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, Target.position, Color.red);
        return false;
    }

    public bool HaveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = Target.position - transform.position;
        hit = new RaycastHit();
        hit.distance = distanceforLOS;
        
        if(Physics.Raycast(transform.position, direction, out hit, hit.distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.DrawRay(transform.position, direction, Color.black);
                return true;
            }
        }
        return false;
    }
}
