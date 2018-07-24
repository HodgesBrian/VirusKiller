using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellSpawner : MonoBehaviour {

	ObjectPooler objectPooler;
    public int bloodCellCount = 0;
	public static BloodCellSpawner bloodCellSpawner;

	private void Start()
	{
		bloodCellSpawner = this;
		objectPooler = ObjectPooler.Instance;
        //bloodCellCount = 10;
	}
	
	// Update is called once per frame
	void Update () {
        for (; bloodCellCount > 0; bloodCellCount--)
        {
            objectPooler.SpawnFromPool("bloodCell", transform.position, Quaternion.identity);
        }
	}
}
