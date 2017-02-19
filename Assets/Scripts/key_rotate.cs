using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_rotate : MonoBehaviour {
	public float rot_speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		transform.Rotate (0, rot_speed * Time.deltaTime, 0);
	}
}
