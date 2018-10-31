using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartTrigger : MonoBehaviour {

    Animator anim;
    Light lightSource;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        lightSource = gameObject.GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PartTrigger ct = other.attachedRigidbody.gameObject.GetComponent<PartTrigger>();
        if (ct != null)
        {
            anim.SetBool("hasCollider", true);
            lightSource.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PartTrigger ct = other.attachedRigidbody.gameObject.GetComponent<PartTrigger>();
        if (ct != null)
        {
            anim.SetBool("hasCollider", false);
            lightSource.enabled = false;
        }
    }
}
