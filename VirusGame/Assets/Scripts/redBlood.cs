using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBlood : MonoBehaviour, IPooledObjects
{
	public float upForce = 1f;
	public float sideForce = .1f;

	// Use this for initialization
	public void OnObjectSpawn ()
    {
		float xForce = Random.Range (-sideForce, sideForce);
		float yForce = Random.Range (upForce / 2f, upForce);
        //float zForce = Random.Range (0.0f, 0.0f);

		Vector2 force = new Vector2 (xForce, yForce);

		GetComponent<Rigidbody2D> ().velocity = force;
	}

}
