using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class Nav_toTarget : MonoBehaviour
{

    public GameObject TargetObject = null;
    private NavMeshAgent agent;


    void Start()
    {
     
        TargetObject =GameObject.FindGameObjectWithTag("Target");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(0.6f, 1.8f);
        if (TargetObject != null)
        {
            GetComponent<NavMeshAgent>().destination = TargetObject.transform.position;
        }
    }


    void Update()
    {
       
    }
}