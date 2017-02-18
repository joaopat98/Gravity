using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.down, 0.1f))
			print ("lel");
	}
}
