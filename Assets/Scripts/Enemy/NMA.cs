using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMA : MonoBehaviour
{
    public enum EnemyState { Searching, Chasing, Attacking, Dead}; //depending on the state the enemy is in, it will act differently
    public Transform CurrentTarget; //setting this to the navmesh agent's goal in update so it can be changed
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = CurrentTarget.position;
    }
}
