using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
    public int currentHealth;
    public float gainBooster = 1f;
    public Slider healthSlider;
    public Text healthText;
    public AudioClip deathClip;

    Animator anim;
    AudioSource playerAudio;
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

        playerAudio = GetComponent<AudioSource>();
	    hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
        
        currentHealth = maxHealth;
    }


    void Update ()
    {
    		damaged = false;
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (currentHealth > 0)
        {
            damaged = true;

            currentHealth -= amount;
            playerAudio.Play();

            healthSlider.value = currentHealth;
            healthText.text = "" + currentHealth;
        }
//		hitParticles.transform.position = hitPoint;
//		hitParticles.Play();

		if(currentHealth <= 0)
		{
			Death();
		}
    }

    public void GainHealth (int amount)
    {
        amount += (int)(amount * gainBooster);
        if (currentHealth + amount >= maxHealth)
        {
            currentHealth = maxHealth;
            damaged = false;
        } else
        {
            currentHealth += amount;
        }
        healthSlider.value = currentHealth;
        healthText.text = "" + currentHealth;
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        healthSlider.value = currentHealth;
        healthText.text = "" + currentHealth;
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();


        rootMotionPlayerMovement.enabled = false;
        playerShooting.enabled = false;
    }

}
