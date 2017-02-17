using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Main : MonoBehaviour {
	public float mov_speed;
	public float rot_speed;
    public float jump_height = 5;

	Vector2 rt = new Vector2(1,0), lt = new Vector2(-1,0); 
	Vector2 rot = new Vector2(0,0);
	bool orient = true;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D) == true) {
			transform.Translate (rt * mov_speed * Time.deltaTime, Space.World);
			if (rot.y > 0)
				rot += new Vector2(0,-rot_speed * Time.deltaTime);
			orient = true;
		}
		else if (orient == true && rot.y > 0)
			rot += new Vector2(0,-rot_speed * Time.deltaTime);


		if (Input.GetKey (KeyCode.A) == true){
			transform.Translate (lt * mov_speed * Time.deltaTime, Space.World);
			if (rot.y < 180)
				rot += new Vector2(0,rot_speed * Time.deltaTime);
			orient = false;
		}
		else if (orient == false && rot.y < 180)
			rot += new Vector2(0,rot_speed * Time.deltaTime);


		if (rot.y < 0)
			rot = new Vector2 (0, 0);
		if (rot.y > 180)
			rot = new Vector2 (0, 180);
		transform.eulerAngles = rot;

        //Input.GetButtonDown("Jump") == true
        if (Input.GetKey(KeyCode.W) == true)
        {
            rb.AddForce(new Vector2(0, jump_height), ForceMode2D.Impulse);
        }
    }
}
