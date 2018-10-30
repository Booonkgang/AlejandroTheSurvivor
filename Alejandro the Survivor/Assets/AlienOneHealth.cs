using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienOneHealth : MonoBehaviour {

	public int startingHealth = 20;
    public int currentHealth;

    Animator anim;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
		AlienShooting alienShooting;
    bool isDead;


    void Awake ()
    {
        anim = GetComponent <Animator> ();

        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

				alienShooting = GetComponentInChildren <AlienShooting> ();

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

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

				alienShooting.DisableEffects();

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
