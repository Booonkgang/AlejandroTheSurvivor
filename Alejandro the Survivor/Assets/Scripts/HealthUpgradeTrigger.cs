using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradeTrigger : MonoBehaviour {

    BoxCollider boxCollider;
    public int healthGain = 25;
    AudioSource getPotion;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        getPotion = GetComponent<AudioSource>();
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
            getPotion.Play();
            ct.IncreaseMaxHealth(healthGain);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.7f);
        }
    }
}
