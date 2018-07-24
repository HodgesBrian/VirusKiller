using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTracking : MonoBehaviour
{

    public GameObject virus;
    public float rotationSpeed = 1;
    public int virusSpeed;
    public Transform parent;
    public float damage = 10f;
    private int layerMask = 1 << 8;

    public Vector3 randVec;

    float vision_angle_ = 50;
    //float direction;
    Vector2 angle;
    Vector2 angle1;
    Vector2 position;
    Quaternion q;
    int x = 10;

    public bool gottaHit = false;

    Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    //public GameObject explosion;

    private Rigidbody2D rb;

    void start()
    {
        parent = transform.parent;
        randVec = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    void Update()
    {
        
        moveToAttack();
        //randMovement();
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("CCCCCCCCCCCCCCCCC");

		if (collision.collider.tag == "bloodCell") //this block accounts the damage to the red blood cells.
        {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
			bloodCellHealth bloodcellhealth = collision.collider.GetComponent<bloodCellHealth>(); 
			bloodcellhealth.takeDamage(damage);
        }
        
        
    }

    void randMovement() // this makes the movement of the blood cell and virus random.
    {

        transform.position = Vector2.MoveTowards(transform.position, randVec, .5f * Time.deltaTime);

        if (transform.position == randVec)
        {
            randVec = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }

    void moveToAttack() // This is the virus's raycast that detects the red bloodcell, and moves it towards it to do damage.
    {
		Vector2 transDirection = transform.TransformDirection(angle1);
        RaycastHit2D tile_hit = Physics2D.Raycast(transform.position, transDirection, 2f, layerMask);
        angle = new Vector2(x, Mathf.Tan((vision_angle_) * .5f * Mathf.Deg2Rad) * x);
		q = Quaternion.AngleAxis(100*Time.time, -transform.forward) * q;
        //position = new Vector2(transform.position.x, transform.position.y);
        angle1 = q * angle;

        Debug.Log("I'M LOOKING TO ATTACK!!!!!!!!");
		Debug.DrawRay(transform.position, transDirection, Color.green);
        if (tile_hit && tile_hit.collider.tag == "bloodCell")
        {
            Debug.Log("We Hit " + tile_hit.collider.name + "! ");
            Debug.DrawRay(transform.position, tile_hit.rigidbody.position, Color.red);

            if (tile_hit.collider != null)
            {
                gottaHit = true;
                Debug.Log(gottaHit);
                transform.position = Vector2.MoveTowards(transform.position, tile_hit.point, speed * Time.deltaTime);

            }
        }
        else
        {
            transform.Rotate(0, 0, rotationSpeed);
            randMovement();
        }
    }
}
