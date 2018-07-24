using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodCellHealth : MonoBehaviour {

    public float health = 50f;
    public GameObject bloodCell;

	private static int bloodDeathCount;

	void Start(){
		
		bloodDeathCount = 0;
	}

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health is " + health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
		
		BloodCellSpawner.bloodCellSpawner.bloodCellCount++;
        gameObject.SetActive(false);
        Debug.Log("Blood Cell Destroyed!");
		addDeathCount (1);
    }

	public void addDeathCount(int newDeathCount)
	{
		bloodDeathCount += newDeathCount;
	}
	public static int getBloodDeathCount()
	{
		return bloodDeathCount;
	}
}
