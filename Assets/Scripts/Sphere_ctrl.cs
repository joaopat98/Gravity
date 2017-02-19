using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_ctrl : MonoBehaviour {
	public Rigidbody2D p_rigidbody;
	public Transform p_transform, world;
	public float atr_force, rot_speed;

	int mult;
	bool active = false, caught = false, transition = false;
	float ang, d_ang;
	float def_grav;

	// Use this for initialization
	void Start () {
		def_grav = p_rigidbody.gravityScale;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player"){
			active = true;
			caught = true;
		}
	}

	// Update is called once per frame
	void Update () {
		ang = world.eulerAngles.z;

		if (caught == true && (transform.position - p_transform.position).magnitude <= 0.5) {
			print (Time.deltaTime);
			p_rigidbody.velocity = Vector3.zero;
			p_rigidbody.MovePosition (transform.position);
			p_rigidbody.isKinematic = true;
			world.RotateAround(transform.position, Vector3.forward, rot_speed * Time.deltaTime);
		}

		if (active == true && (transform.position - p_transform.position).magnitude > 0.5) {
			p_rigidbody.gravityScale = 0;
			p_rigidbody.AddForce ((transform.position - p_transform.position) * atr_force);
		}
		if (Input.GetButtonDown ("Jump") && caught == true) {
			caught = false;
			transition = true;

		}
		if(transition == true){
			active = false;
			mult = (int)ang / 45;
			if ((ang > 50 && ang < 85) || (ang > 140 && ang < 175) || (ang > 230 && ang < 265) || (ang > 320 && ang < 355))
				world.RotateAround (transform.position, Vector3.forward, 2 * rot_speed * Time.deltaTime);
			else if ((ang > 5 && ang < 40) || (ang > 95 && ang < 130) || (ang > 185 && ang < 220) || (ang > 275 && ang < 310))
				world.RotateAround (transform.position, Vector3.forward, -2 * rot_speed * Time.deltaTime);
			else {
				switch (mult) {
				case 1:
				case 3:
				case 5:
				case 7:
					world.eulerAngles = new Vector3(world.eulerAngles.x, world.eulerAngles.y, ((mult + 1) * 45));
					break;
				default: 
					world.eulerAngles = new Vector3(world.eulerAngles.x, world.eulerAngles.y, (mult * 45));
					break;
				}
				p_rigidbody.isKinematic = false;
				p_rigidbody.gravityScale = def_grav;
				transition = false;
			}

		}

	}
}
