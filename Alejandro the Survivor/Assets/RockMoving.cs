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
        if (other.attachedRigidbody.gameObject.GetComponent<PartTrigger>() != null)
        {
            rockTrigger = true;
            anim.SetBool("Moved", true);
            meshCollider.enabled = false;
            sphereCollider.enabled = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        PartTrigger ct = other.attachedRigidbody.gameObject.GetComponent<PartTrigger>();
        if (ct != null)
        {
            rockTrigger = false;
        }
    }
}
