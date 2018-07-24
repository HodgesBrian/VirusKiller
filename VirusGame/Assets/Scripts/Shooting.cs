using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooting : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10f;
	public LayerMask whatToHit;
	public int range = 100;
    //public GameObject shipGun;

    public LineRenderer laserGun;

    public Text killCounterText;
	public Text bloodDeathCounterText;

    float timeToFire = 0;
	Transform firePoint;

    private int count;

	void Awake()
	{
        laserGun = gameObject.AddComponent<LineRenderer>();
        laserGun.material = new Material(Shader.Find("Particles/Additive"));
        laserGun.SetWidth(0.1f, .1f);
        laserGun.SetColors(Color.green, Color.green);

		firePoint = transform.Find ("ShipGun");
		if (firePoint == null) 
		{
			Debug.LogError ("No Firepoint? WHAT?!");
		}
	}

	// Update is called once per frame
	void Update () {

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				shoot ();
			}
				
		} else {
            if (Input.GetButton("Fire1") && 0 > timeToFire)
            {
                timeToFire = 1 / fireRate;
                shoot();
            } else {
                laserGun.enabled = false;
                timeToFire -= Time.deltaTime;
            }
		}
        UpdateKillCount();	
	}

	void shoot()
	{
		//Debug.Log ("Test");
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
			                        Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, range, whatToHit);
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)* 100, Color.blue);

        laserGun.SetPosition(0, transform.position);
        laserGun.SetPosition(1, mousePosition);
        laserGun.enabled = true;

        if (hit.collider != null)
		{
            
			Debug.DrawLine (firePointPosition, hit.point, Color.red);

            Debug.Log(hit.collider.gameObject);
			if (hit.collider.gameObject.tag == "Virus") {

                

                Enemy enemy = hit.transform.GetComponent<Enemy> ();
				if (enemy != null) {
                    Debug.Log ("We Hit " + hit.collider.name + " and did " + damage + " damage!");
					enemy.takeDamage (damage);
				}
			}


		
		}
	}

    void UpdateKillCount()
    {
        killCounterText.text = "kill Count: " + Enemy.getKillCount();
		bloodDeathCounterText.text = "Cell Deaths: " + bloodCellHealth.getBloodDeathCount ();
    }

}
