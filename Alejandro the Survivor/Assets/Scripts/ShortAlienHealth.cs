﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortAlienHealth : MonoBehaviour {

	public int startingHealth = 15;
    public int currentHealth;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 2;
    public AudioClip deathClip;
    public GameObject impactParticle;

    Animator anim;
    private bool isDead;

    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    GameObject astronautPlayer;
    PowerUpManager powerUpManager;
    AudioSource playerAudio;
    bool playerInRange;
    float timer;

    void Awake ()
    {
        anim = GetComponent <Animator> ();

        GameObject managerObj = GameObject.FindGameObjectWithTag("PowerUpManager");
        powerUpManager = managerObj.GetComponent<PowerUpManager>();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        boxCollider = GetComponent<BoxCollider>();
        astronautPlayer = GameObject.FindGameObjectWithTag ("AstronautPlayer");
        playerAudio = GetComponent<AudioSource>();
		//		alienShooting = GetComponentInChildren <AlienShooting> ();

        currentHealth = startingHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == astronautPlayer)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == astronautPlayer)
        {
            playerInRange = false;
        }
    }

    void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && currentHealth > 0)
        {
            Attack();
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;


        currentHealth -= amount;
        playerAudio.Play();
        GameObject cloneImpactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, hitPoint)) as GameObject;
        Destroy (cloneImpactParticle, 1f);
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death ();
        }
    }

    void Attack()
    {
        timer = 0f;
        PlayerHealth playerHealth = astronautPlayer.GetComponent<PlayerHealth>();
        if (playerHealth != null && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage, new Vector3(0,0,0));
        }
    }

    void Death ()
    {

        //alienShooting.DisableEffects();

        isDead = true;
        playerAudio.clip = deathClip;
        playerAudio.Play();
        if (Random.value > (1 - powerUpManager.spawnChance))
        {
            powerUpManager.spawnPowerUp(this.transform.position);
        }
        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");
        StartSinking();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        Destroy (gameObject, 2f);
    }
}
