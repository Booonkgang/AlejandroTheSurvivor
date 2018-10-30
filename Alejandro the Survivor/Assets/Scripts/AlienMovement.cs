using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour {

	Transform astronautPlayer;
	PlayerHealth playerHealth;
	AlienOneHealth alienHealth;
	UnityEngine.AI.NavMeshAgent nav;


	void Awake ()
	{
			astronautPlayer = GameObject.FindGameObjectWithTag ("AstronautPlayer").transform;
			playerHealth = astronautPlayer.GetComponent <PlayerHealth> ();
			alienHealth = GetComponent <AlienOneHealth> ();
			nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{
			if(alienHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
			{
					nav.SetDestination (astronautPlayer.position);
					transform.LookAt(astronautPlayer);
			}
			else
			{
					nav.enabled = false;
			}
	}
}
