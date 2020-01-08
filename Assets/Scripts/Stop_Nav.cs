using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stop_Nav : MonoBehaviour {

    // Use this for initialization

    void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            Animation ani;
            ani = other.gameObject.GetComponent<Animation>();
            ani.CrossFade("walk", 0.5f);
            NavMeshAgent agent;
            agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = false;

            Destroy(other.gameObject);

        }
    }
}
