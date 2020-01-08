using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePersonLayer : MonoBehaviour {

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
            other.gameObject.layer = LayerMask.NameToLayer(gameObject.name);
            foreach (Transform tran in other.gameObject.GetComponentInChildren<Transform>())
            {
                tran.gameObject.layer = LayerMask.NameToLayer(gameObject.name);
            }           
        }
    }
}
