using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public GameObject playerGun;
    public GameObject[] powerUps;
    public float spawnChance = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnPowerUp(Vector3 position)
    {
        GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];
        Instantiate(powerUp, position, powerUp.transform.rotation);
    }
}
