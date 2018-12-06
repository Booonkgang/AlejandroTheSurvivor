using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHealth : MonoBehaviour {

    public int startingHealth = 30;
    public int currentHealth;
    public AudioClip[] deathSounds;
    public AudioSource explode;
    private Material mat;

    bool isDestroyed;

	// Use this for initialization
	void Start ()
    {
        currentHealth = startingHealth;
        explode = GetComponent<AudioSource>();
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {

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
        isDestroyed = true;
        while (mat.color.a > 0)
        {
            Color newColor = mat.color;
            newColor.a -= Time.deltaTime;
            mat.color = newColor;
            gameObject.GetComponent<MeshRenderer>().material = mat;
        }
        Destroy(gameObject, 2f);
        explode.clip = deathSounds[Random.Range(0, deathSounds.Length)];
        explode.Play();
    }
}
