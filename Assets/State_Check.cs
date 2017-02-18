using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State_Check : MonoBehaviour {
	public int num_keys;
	int curr_keys;
	public Rigidbody2D rb;
	int pass = 0;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "key") {
			Destroy (col.gameObject);
			curr_keys++;
		}
		if (col.tag == "end") {
			if (curr_keys == num_keys)
				pass++;//declare win
			else
				pass++;//not enough keys
		}
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
