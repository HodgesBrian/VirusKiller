using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health = 50f;
    public GameObject Virus;
    private static int killCounter;

    public void Start()
    {

        killCounter = 0;

    }

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health is " + health);
        if (health <= 0f) {
            Die();
        }
    }

    void Die()
    {
        VirusSpawner.virusSpawner.spawnCount++;
        gameObject.SetActive(false);
        Debug.Log("Enemy Destroyed!");
        addKillCount(1); 
    }

    public void addKillCount(int newKillCount) 
	{

        killCounter += newKillCount;
        Debug.Log("New kill count is: "+ killCounter);

    }

    public static int getKillCount()
    {
        return killCounter;
    }
}
