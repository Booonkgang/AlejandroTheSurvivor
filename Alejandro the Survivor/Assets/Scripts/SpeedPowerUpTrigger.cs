using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpTrigger : MonoBehaviour {

    BoxCollider boxCollider;
    public float speedGain = 0.001f;
    AudioSource getPotion;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        getPotion = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        RootMotionPlayerMovement ct = other.attachedRigidbody.gameObject.GetComponent<RootMotionPlayerMovement>();
        if (ct != null)
        {
        	getPotion.Play();
            ct.GainSpeed(speedGain);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.7f);
        }
    }
}
