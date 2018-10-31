using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTrigger : MonoBehaviour {

    public bool partTrigger = false;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void triggerPart()
    {
        partTrigger = true;
        anim.SetInteger("parts", anim.GetInteger("parts") + 1);
    }
}
