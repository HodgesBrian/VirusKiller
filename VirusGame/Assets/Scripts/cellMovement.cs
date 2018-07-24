using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellMovement : MonoBehaviour {

	public GameObject bloodCell;
    public Vector3 randVec;
    public float moveSpeed = 2;
    public float rotationSpeed = 1f;


    void Start()
    {

        randVec = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));

    }

	void OnTriggerEnter2D()
    {
		Debug.Log ("Get AWAAAAAAAAAAAAAAAAAY!");

		if (bloodCell.tag == "virus")
        {
            moveSpeed = .1f;
            Debug.Log("SSSSSSSSSHHHHHHHHHHHHHHHHHHIIIIIIIIIIIIT");
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
        transform.position = Vector2.MoveTowards(transform.position, randVec, moveSpeed * Time.deltaTime);
        
        if (transform.position == randVec)
        {
          randVec = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));  
        }
    }
}
