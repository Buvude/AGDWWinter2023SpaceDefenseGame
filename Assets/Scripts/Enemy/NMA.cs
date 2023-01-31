using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMA : MonoBehaviour
{
    public enum EnemyState { Searching, Chasing, Attacking, Dead}; //depending on the state the enemy is in, it will act differently
    private Vector3 CurrentTarget; 
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //TEMPORARY TEST FOR NAVMESH
        agent = GetComponent<NavMeshAgent>();
        CurrentTarget.Set(0f, 0f, 0f);
        UpdateTarget();//putting this as a method so it can be called whenever, but not constantly every frame. This might optimize the game a bit more
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateTarget()
    {
        agent.destination = CurrentTarget;
    }
}
