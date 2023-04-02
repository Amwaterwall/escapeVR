using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Keeps track of total coin count in scene
    public static int CoinCount = 0;
    // Use this for initialization

    void Awake()
    {
        // Object created, increment coin count
        ++Coin.CoinCount;
    }

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log ("Entered Collider");
        // If player collected coin, then destroy object
        if (Col.CompareTag("Player")) {
            Destroy(gameObject);
            // in this case, "Destroy" means collect
        }
    }

    // Called when object is destroyed
    void OnDestroy()
    {
        // Decrement coin count
        --Coin.CoinCount;
        
        // Check remaining coins
        if (Coin.CoinCount <= 0)
        {
            //Game is won. Collected all coins. Destroy Timer and launch fireworks
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);
            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach (GameObject GO in FireworkSystems)
            GO.GetComponent<ParticleSystem>().Play();
        }
    }
}
