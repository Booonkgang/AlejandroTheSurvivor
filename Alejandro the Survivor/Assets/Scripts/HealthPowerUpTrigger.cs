using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpTrigger : MonoBehaviour {

    BoxCollider boxCollider;
    public int healthGain = 20;
    AudioSource getPotion;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        getPotion = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ct = other.attachedRigidbody.gameObject.GetComponent<PlayerHealth>();
        if (ct != null)
        {
            getPotion.Play();
            ct.GainHealth(healthGain);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.7f);
        }
    }
}
