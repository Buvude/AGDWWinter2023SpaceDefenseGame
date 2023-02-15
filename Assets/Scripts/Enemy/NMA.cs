using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMA : MonoBehaviour
{
    public float NMAspeed;
    public EnemyGoalPoin CurrentHome;//This will make the NMA "immune" to the hitbox on the EGP, so it can leave
    public enum EnemyState { Searching, Patrolling, Chasing, Attacking, Dead}; //depending on the state the enemy is in, it will act differently
    private Vector3 CurrentTarget; 
    private NavMeshAgent agent;
    public EnemyState CurrentState;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = NMAspeed;
        //TEMPORARY TEST FOR NAVMESH
        //make it so the spawn point is instatnly a "home" so that they don't search when spawned in

        /*CurrentTarget.Set(0f, 0f, 0f);*/
        /*UpdateTarget();*///putting this as a method so it can be called whenever, but not constantly every frame. This might optimize the game a bit more
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateTarget()
    {
        agent.destination = CurrentTarget;
    }
    public void UpdateTargetWithTarget(Vector3 NextTargetPossibly)
    {
        /*agent.destination = newPoint;*/
        CurrentTarget = NextTargetPossibly;
        UpdateTarget();
    }
    public void NewHome(EnemyGoalPoin EGP2)
    {
        CurrentHome = EGP2;
        CurrentState = EnemyState.Searching;
        
        //play animation then switch state to patrolling (after choosing new path)
    }

    public void StateSwitch()
    {
        switch (CurrentState)
        {
            case EnemyState.Searching:
                {
                    agent.speed = 0;
                    break;
                }
            case EnemyState.Patrolling:
                {
                    agent.speed = NMAspeed;
                    break;
                }
            case EnemyState.Chasing:
                {
                    agent.speed = NMAspeed;
                    //set destination to player
                    UpdateTarget();
                    break;
                }
                
            case EnemyState.Attacking:
                {
                    agent.speed = 0;
                    //attack player, and swith back to chasing after attack animation finishes if they are now out of range
                    break;
                }
                
            case EnemyState.Dead:
                agent.speed = 0;
                //destroy enemy and such.
                break;
            default:
                break;
        }
    }

    //for searching play ~5 second animation of searching, then change state to patrolling (after setting new goal point)
    //For patrolling move towards new goal point, switch to searching once arrive in trigger for goal point
    //at any point if the enemy sees the player, or is attacked, or see's another enemy that is chasing/attacking the player
    //they will exit whatever state they are in, and enter chasing, in which they move towards the player until within range.
    //once within range they will enter attacking mode, when they die they enter death mode.
    //Chasing and attacking mode will swap between one another, but never go back to searching or patrolling.
}
