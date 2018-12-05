using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTrigger : MonoBehaviour {

    public bool partTrigger = false;
    Animator anim;
    public AudioClip getPart;

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
        AudioSource temp = GetComponent<AudioSource>();
        temp.clip = getPart;
        temp.Play();
        partTrigger = true;
        anim.SetInteger("parts", anim.GetInteger("parts") + 1);
    }
}
