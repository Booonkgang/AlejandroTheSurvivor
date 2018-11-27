using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienOneHealth : MonoBehaviour {

    public int startingHealth = 20;
    public int currentHealth;
    public AudioClip deathClip;
    public GameObject impactParticle;

    PowerUpManager powerUpManager;
    AudioSource playerAudio;
    Animator anim;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    AlienShooting alienShooting;
    bool isDead;


    void Awake ()
    {
        GameObject managerObj = GameObject.FindGameObjectWithTag("PowerUpManager");
        powerUpManager = managerObj.GetComponent<PowerUpManager>();
        anim = GetComponent <Animator> ();

        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        alienShooting = GetComponentInChildren <AlienShooting> ();
        playerAudio = GetComponent<AudioSource>();
        alienShooting = GetComponentInChildren<AlienShooting>();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        //
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;


        currentHealth -= amount;

        playerAudio.Play();
        impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, hitPoint)) as GameObject;
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
        alienShooting.DisableEffects();
        playerAudio.clip = deathClip;
        playerAudio.Play();
        if (Random.value > (1 - powerUpManager.spawnChance))
        {
            powerUpManager.spawnPowerUp(this.transform.position);
        }
        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("Die");
        StartSinking();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;

        Destroy (gameObject, 2f);
    }
}
