using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalPoin : MonoBehaviour
{
    public List<EnemyGoalPoin> EGP = new List<EnemyGoalPoin>();
    // Start is called before the first frame update
    void Start()
    {
        //have a list of EGPs, for the enemy to select where to move randomly. At each EGP, the enemy will select from a valid EGP to go to next. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform NextPoint()
    {
        return EGP[((int)Random.Range(0f, EGP.Count - 1))].gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NMA>().NewHome(this);
        }
    }
    //add trigger area to trigger searching mode, and then set this EGP as their home.
}
