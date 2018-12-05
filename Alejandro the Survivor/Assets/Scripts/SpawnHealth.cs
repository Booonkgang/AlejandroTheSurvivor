using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour {

    public int startingHealth = 500;
    public int currentHealth;

    bool isDestroyed;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDestroyed)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isDestroyed = true;
        Destroy(gameObject, 2f);
    }
}
