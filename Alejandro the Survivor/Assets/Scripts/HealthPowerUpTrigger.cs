using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpTrigger : MonoBehaviour {

    BoxCollider boxCollider;
    public int healthGain = 20;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ct = other.attachedRigidbody.gameObject.GetComponent<PlayerHealth>();
        if (ct != null)
        {
            ct.GainHealth(healthGain);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }
}
