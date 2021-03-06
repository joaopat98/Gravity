using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Main : MonoBehaviour
{
	public float mov_speed, rot_speed, jump_height, repel;
	public Transform Bottom;

	Vector2 rot = new Vector2 (0, 0);
	bool orient = true;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
		
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

        }
    }

	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			rb.velocity = new Vector2 (mov_speed, rb.velocity.y);
			if (rot.y > 0)
				rot += new Vector2 (0, -rot_speed * Time.deltaTime);
			orient = true;
		} else if (orient == true && rot.y > 0)
			rot += new Vector2 (0, -rot_speed * Time.deltaTime);


		if (Input.GetAxisRaw ("Horizontal") < 0) {
			rb.velocity = new Vector2 (-mov_speed, rb.velocity.y);
			if (rot.y < 180)
				rot += new Vector2 (0, rot_speed * Time.deltaTime);
			orient = false;
		} else if (orient == false && rot.y < 180)
			rot += new Vector2 (0, rot_speed * Time.deltaTime);

		if (Input.GetAxisRaw ("Horizontal") == 0)
			rb.velocity = new Vector2 (0, rb.velocity.y);


		if (rot.y < 0)
			rot = new Vector2 (0, 0);
		if (rot.y > 180)
			rot = new Vector2 (0, 180);
		transform.eulerAngles = rot;

		if (Input.GetButtonDown ("Jump")) {
			if (Physics2D.Raycast (new Vector2 (Bottom.position.x,Bottom.position.y), Vector2.down, 0.1f))
				rb.AddForce (new Vector2 (0, jump_height), ForceMode2D.Impulse);
		}
	}
}
