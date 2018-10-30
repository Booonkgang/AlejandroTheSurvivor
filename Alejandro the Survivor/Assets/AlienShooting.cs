using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShooting : MonoBehaviour {

	public int damagePerShot = 5;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;


	float timer;
	Animator anim;
	Ray shootRay;
	RaycastHit shootHit;
	GameObject astronautPlayer;
	GameObject alien;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	public GameObject alien_obj;
	float effectsDisplayTime = 0.2f;
	AlienOneHealth alienHealth;


	void Awake ()
	{
			alien = GameObject.FindGameObjectWithTag ("Alien");
			anim = alien.GetComponent <Animator> ();
			shootableMask = LayerMask.GetMask ("Shootable");
			gunParticles = GetComponent<ParticleSystem> ();
			gunLine = GetComponent <LineRenderer> ();
			astronautPlayer = GameObject.FindGameObjectWithTag ("AstronautPlayer");
			alienHealth = (AlienOneHealth) alien_obj.GetComponent(typeof(AlienOneHealth));
	}


	void Update ()
	{
			anim.SetTrigger("GunUp");

			timer += Time.deltaTime;

			if(Vector3.Distance(transform.position, astronautPlayer.transform.position) <= 30.0f && timer >= timeBetweenBullets)
			{
				if(alienHealth.currentHealth <= 0)
        	{
					DisableEffects();
				} else {
					Shoot ();
				}

			}

			if(timer >= timeBetweenBullets * effectsDisplayTime)
			{
					DisableEffects ();
			}

	}


	public void DisableEffects ()
	{
			gunLine.enabled = false;
	}


	void Shoot ()
	{
			timer = 0f;
			anim.SetTrigger("Shoot");

			gunParticles.Stop ();
			gunParticles.Play ();

			gunLine.enabled = true;
			gunLine.SetPosition (0, transform.position);

			shootRay.origin = transform.position;
			shootRay.direction = transform.forward;

			if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
			{
					PlayerHealth playerHealth = shootHit.collider.GetComponent <PlayerHealth> ();
					if(playerHealth != null)
					{
							playerHealth.TakeDamage(damagePerShot, shootHit.point);
					}
					gunLine.SetPosition (1, shootHit.point);
			}
			else
			{
					gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			}
	}
}
