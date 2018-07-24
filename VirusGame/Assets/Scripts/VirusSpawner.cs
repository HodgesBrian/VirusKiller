using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour {

    ObjectPooler objectPooler;
    public int spawnCount = 0;
    public static VirusSpawner virusSpawner;

	// Use this for initialization
	void Start () {
		
        virusSpawner = this;
        objectPooler = ObjectPooler.Instance;
        //spawnCount = 25;
	}
	
	// Update is called once per frame
	void Update () {
        for (;spawnCount > 0; spawnCount--)
        {
            objectPooler.SpawnFromPool("Virus", transform.position, Quaternion.identity);
        }
	}
}
