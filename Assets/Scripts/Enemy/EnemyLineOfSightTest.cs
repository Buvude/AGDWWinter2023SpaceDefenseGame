using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSightTest : MonoBehaviour
{
    public int distanceforLOS, distanceforFiring, range1, range2;
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
        /*if(Mvmt.CurrentState != NMA.EnemyState.Dead&& Mvmt.CurrentState != NMA.EnemyState.Attacking&& Mvmt.CurrentState != NMA.EnemyState.Chasing)
        {
            Targetable();
        }
        else if (WithinRange()&&Mvmt.CurrentState==NMA.EnemyState.Chasing)
        {
            Mvmt.CurrentState = NMA.EnemyState.Attacking;
            Mvmt.StateSwitch();
        }
        else if(!WithinRange()&& Mvmt.CurrentState == NMA.EnemyState.Attacking)
        {
            Mvmt.CurrentState = NMA.EnemyState.Attacking;
            Mvmt.StateSwitch();
        }*/

        switch (Mvmt.CurrentState)
        {
            case NMA.EnemyState.Searching:
                Targetable();
                break;
            case NMA.EnemyState.Paused:
                break;
            case NMA.EnemyState.Patrolling:
                Targetable();
                break;
            case NMA.EnemyState.Chasing:
                if (WithinRange())
                {
                    Mvmt.CurrentState = NMA.EnemyState.Attacking;
                    Mvmt.StateSwitch();
                }
                break;
            case NMA.EnemyState.Attacking:
                print("made it to attacking");
                /*if (!WithinRange())
                {
                    Mvmt.CurrentState = NMA.EnemyState.Chasing;
                    Mvmt.StateSwitch();
                }*/
                break;
            case NMA.EnemyState.Dead:
                break;
            default:
                break;
        }
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
        else
        {
            Debug.DrawLine(transform.position, Target.position, Color.red);
        }

        return false;
    }

    public bool HaveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = Target.position - transform.position;
        hit = new RaycastHit();
        hit.distance = distanceforLOS;
        if(Physics.Raycast(transform.position, direction, out hit, hit.distance,~LayerMask.NameToLayer("Default")))
        {
            if (hit.transform.CompareTag("Player")&&Mvmt.CurrentState!=NMA.EnemyState.Attacking&& Mvmt.CurrentState != NMA.EnemyState.Dead&& Mvmt.CurrentState != NMA.EnemyState.Chasing)
            {
                //Debug.DrawRay(transform.position, direction, Color.green);
                Mvmt.CurrentState = NMA.EnemyState.Chasing;
                Mvmt.StateSwitch();
                return true;
            }
        }
        return false;
    }
    public bool WithinRange()
    {
        print("Made it to withinRange");
        /*RaycastHit hit;
        Vector3 direction = Target.position - transform.position;
        hit = new RaycastHit();
        hit.distance = distanceforFiring;*/
        if (Targetable()&& /*Physics.Raycast(transform.position, direction, out hit, hit.distance)*/Vector3.Distance(transform.position, Target.position)<=distanceforFiring)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
