using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightAttack : MonoBehaviour {

    bool translate = false;
    public GameObject g;
    public Vector3 startPoint, hitPoint;
    public float movementSpeed;
    public LayerMask whatToHit;
    public int range = 25;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (translate)
        {
            transform.position = Vector3.Lerp(transform.position, hitPoint, movementSpeed);
            if (g.transform.position == hitPoint)
            {
                translate = false;
            }
        }
        RaycastHit2D hit = Physics2D.Raycast(g.transform.position, hitPoint - g.transform.position, range, whatToHit);
        Debug.DrawLine(g.transform.position, (hitPoint - g.transform.position) * 1, Color.cyan);
        Debug.DrawLine(g.transform.position, hit.point, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "bloodCell")
            {
                startPoint = g.transform.position;
                hitPoint = hit.point;
                translate = true;
            }
        }
	}
}
