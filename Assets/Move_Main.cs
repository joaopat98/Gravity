using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Main : MonoBehaviour {
	public float mov_speed;
	public float rot_speed;
    public float jump_height;

    Vector2 rt = new Vector2(1, 0), lt = new Vector2(-1,0); 
	Vector2 rot = new Vector2(0,0);
	bool orient = true, isgrounded = false;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
    }

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Floor") {
			isgrounded = true;
			print ("grounded");
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		isgrounded = false;
		print ("not grounded");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") > 0) {
			rb.velocity = new Vector2 (mov_speed, rb.velocity.y);
			if (rot.y > 0)
				rot += new Vector2(0,-rot_speed * Time.deltaTime);
			orient = true;
		}
		else if (orient == true && rot.y > 0)
			rot += new Vector2(0,-rot_speed * Time.deltaTime);


		if (Input.GetAxisRaw("Horizontal") < 0){
			rb.velocity = new Vector2 (-mov_speed, rb.velocity.y);
			if (rot.y < 180)
				rot += new Vector2(0,rot_speed * Time.deltaTime);
			orient = false;
		}
		else if (orient == false && rot.y < 180)
			rot += new Vector2(0,rot_speed * Time.deltaTime);

		if(Input.GetAxisRaw("Horizontal") == 0)
			rb.velocity = new Vector2 (0, rb.velocity.y);


		if (rot.y < 0)
			rot = new Vector2 (0, 0);
		if (rot.y > 180)
			rot = new Vector2 (0, 180);
		transform.eulerAngles = rot;

		if (Input.GetButtonDown("Jump") == true && isgrounded == true)
        {
            rb.AddForce(new Vector2(0, jump_height), ForceMode2D.Impulse);
        }
    }
}
