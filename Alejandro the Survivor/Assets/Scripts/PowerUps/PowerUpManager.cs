using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public GameObject playerGun;
    public GameObject[] powerUps;
    public GameObject[] rarePowerUps;
    public float spawnChance = 1f;
    public float rareChance = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnPowerUp(Vector3 position)
    {
        GameObject powerUp;
        if (Random.value > (1 - rareChance))
        {
            powerUp = rarePowerUps[Random.Range(0, rarePowerUps.Length)];
            Vector3 pos = position + new Vector3(0, 0.5f, 0);
            Instantiate(powerUp, pos, powerUp.transform.rotation);
        }
        else
        {
            powerUp = powerUps[Random.Range(0, powerUps.Length)];
            Instantiate(powerUp, position, powerUp.transform.rotation);
        }
        
    }
}
