using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradeTrigger : MonoBehaviour {

    BoxCollider boxCollider;
    public int healthGain = 25;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
    	transform.Rotate(0,0,90*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ct = other.attachedRigidbody.gameObject.GetComponent<PlayerHealth>();
        if (ct != null)
        {
            ct.IncreaseMaxHealth(healthGain);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }
}
