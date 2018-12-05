using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoving : MonoBehaviour {

    public bool rockTrigger = false;
    Rigidbody rigidbody;
    MeshCollider meshCollider;
    SphereCollider sphereCollider;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        meshCollider = gameObject.GetComponent<MeshCollider>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        RockTrigger ct = other.attachedRigidbody.gameObject.GetComponent<RockTrigger>();
        if (ct != null)
        {
            rockTrigger = true;
            meshCollider.enabled = false;
            sphereCollider.enabled = false;
            anim.SetBool("MoveTrigger", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        RockTrigger ct = other.attachedRigidbody.gameObject.GetComponent<RockTrigger>();
        if (ct != null)
        {
            rockTrigger = false;
        }
    }
}
