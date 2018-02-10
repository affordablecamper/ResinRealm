using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;
    public float range;
	float timeToFire = 0;
	 Transform firePoint;
    public Vector2 mousePosition;
    public Vector2 firePointPosition;
    public Camera _Camera;
    BlockHealth health;

    // Use this for initialization
	void Awake () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}
	
	// Update is called once per frame
	void Update () {
         mousePosition = new Vector2(_Camera.ScreenToWorldPoint(Input.mousePosition).x, _Camera.ScreenToWorldPoint(Input.mousePosition).y);
         firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {

                Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}
	
	void Shoot () {
       
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, range);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * range, Color.cyan);
        if (hit.collider.gameObject.layer == 11) {

                health = hit.collider.GetComponent<BlockHealth>();
               // Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
                health.shot(Damage);
		}
	}
}
