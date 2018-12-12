using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartTrigger : MonoBehaviour {

    Animator anim;
    Light lightSource;
    MeshCollider collider;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        lightSource = gameObject.GetComponentInChildren<Light>();
        collider = gameObject.GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PartTrigger ct = other.attachedRigidbody.gameObject.GetComponent<PartTrigger>();
        if (ct != null)
        {
            anim.SetBool("hasCollider", true);
            ct.triggerPart();
            if(collider != null)
            {
               collider.enabled = false; 
            }
            
            lightSource.enabled = true;
            if(transform.parent != null){
                transform.parent.tag = "Untagged";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PartTrigger ct = other.attachedRigidbody.gameObject.GetComponent<PartTrigger>();
        if (ct != null)
        {
            anim.SetBool("hasCollider", false);
            lightSource.enabled = false;
            transform.parent.tag = "Untagged";
        }
    }
}
