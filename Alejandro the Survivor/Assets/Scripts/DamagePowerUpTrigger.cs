using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUpTrigger : MonoBehaviour
{

    BoxCollider boxCollider;
    public int damage = 5;
    public float fireRate;
    public float range;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShooting playerShooting = other.attachedRigidbody.gameObject.GetComponentInChildren<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.powerUp(damage, fireRate, range);
            boxCollider.enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }
}
