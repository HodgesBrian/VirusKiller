using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tracking : MonoBehaviour {

    public Transform stSight;
    public Transform endSight;

	public bool spotted;

	void Update(){

		Raycasting ();

	}

	void Raycasting (){
		Debug.DrawLine (stSight.position, endSight.position, Color.white);
		spotted = Physics2D.Linecast (stSight.position, endSight.position, 1 << 8);
	}

}
