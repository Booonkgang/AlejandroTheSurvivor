using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUpTrigger : MonoBehaviour
{

    BoxCollider boxCollider;
    public int damage = 5;
    public float fireRate;
    public float range;
    AudioSource getPotion;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        getPotion = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShooting playerShooting = other.attachedRigidbody.gameObject.GetComponentInChildren<PlayerShooting>();
        if (playerShooting != null)
        {
            getPotion.Play();

            playerShooting.powerUp(damage, fireRate, range);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.7f);
        }
    }
}
