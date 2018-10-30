using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

		public int startingHealth = 50;
    public int currentHealth;
    public Slider healthSlider;

    Animator anim;
    RootMotionPlayerMovement rootMotionPlayerMovement;
    PlayerShooting playerShooting;
		ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        rootMotionPlayerMovement = GetComponent <RootMotionPlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();

				hitParticles = GetComponentInChildren <ParticleSystem> ();
				capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
    		damaged = false;
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        damaged = true;

				currentHealth -= amount;

				healthSlider.value = currentHealth;

				hitParticles.transform.position = hitPoint;
				hitParticles.Play();

				if(currentHealth <= 0)
				{
						Death ();
				}
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");


        rootMotionPlayerMovement.enabled = false;
        playerShooting.enabled = false;
    }

}
