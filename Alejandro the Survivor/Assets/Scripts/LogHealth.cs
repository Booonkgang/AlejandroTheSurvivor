using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHealth : MonoBehaviour {

    public int startingHealth = 30;
    public int currentHealth;
    public AudioClip[] deathSounds;
    public AudioSource explode;

    bool isDestroyed;

	// Use this for initialization
	void Start ()
    {
        currentHealth = startingHealth;
        explode = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDestroyed)
        {
            return;
        }

        currentHealth -= amount;
        explode.Play();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        explode.clip = deathSounds[Random.Range(0, deathSounds.Length)];
        explode.Play();
        isDestroyed = true;
        Destroy(gameObject, 2f);
    }
}
