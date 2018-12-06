using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDetection : MonoBehaviour {

    public bool logTrigger = false;
    Animator anim;
    

	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        RockTrigger ct = other.attachedRigidbody.gameObject.GetComponent<RockTrigger>();
        if (ct != null)
        {
            logTrigger = true;
            anim.SetBool("Moved", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        RockTrigger ct = other.attachedRigidbody.gameObject.GetComponent<RockTrigger>();
        if (ct != null)
        {

        }
    }
}
