﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 5;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	float effectsDisplayTime = 0.2f;


	void Awake ()
	{
			shootableMask = LayerMask.GetMask ("Shootable");
			gunParticles = GetComponent<ParticleSystem> ();
			gunLine = GetComponent <LineRenderer> ();
			gunAudio = GetComponent<AudioSource>();
	}


	void Update ()
	{
			timer += Time.deltaTime;

			if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale == 1f)
			{
					Shoot ();
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

    public void powerUp(int damage, float fireRate, float range)
    {
        this.damagePerShot += damage;
        this.timeBetweenBullets = timeBetweenBullets - timeBetweenBullets * fireRate;
        this.range += range;
    }


	void Shoot ()
	{
			timer = 0f;

			gunAudio.Play();
			gunParticles.Stop ();
			gunParticles.Play ();

			gunLine.enabled = true;
			gunLine.SetPosition (0, transform.position);
            shootRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //shootRay.origin = transform.position;
			//shootRay.direction = transform.forward;

			if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
			{
					AlienOneHealth alienHealth = shootHit.collider.GetComponent <AlienOneHealth> ();
					if(alienHealth != null)
					{
							alienHealth.TakeDamage (damagePerShot, shootHit.point);
					}

					ShortAlienHealth shortHealth = shootHit.collider.GetComponent<ShortAlienHealth>();
					if(shortHealth != null)
					{
						shortHealth.TakeDamage(damagePerShot, shootHit.point);
					}

                    LogHealth logHealth = shootHit.collider.GetComponent<LogHealth>();
                    if (logHealth != null)
                    {
                        logHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    SpawnHealth spawnHealth = shootHit.collider.GetComponent<SpawnHealth>();
                    if (spawnHealth != null)
                    {
                        spawnHealth.TakeDamage(damagePerShot, shootHit.point);
                    }
            gunLine.SetPosition (1, shootHit.point);
			}
			else
			{
					gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			}
	}
}
