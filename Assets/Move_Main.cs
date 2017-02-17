using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Main : MonoBehaviour {
	public float mov_speed;
	public float rot_speed;
	Vector2 rt = new Vector2(1,0), lt = new Vector2(-1,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D) == true) {
			transform.Translate (rt * mov_speed * Time.deltaTime, Space.World);
			if (transform.eulerAngles.y != 0)
				transform.Rotate (-Vector2.up * rot_speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A) == true) {
			transform.Translate (lt * mov_speed * Time.deltaTime, Space.World);
			if (transform.eulerAngles.y != 180)
				transform.Rotate (Vector2.up * rot_speed * Time.deltaTime);
		}

		if (transform.eulerAngles.y > 180)
			transform.eulerAngles = new Vector2(0,180);
	}
}
