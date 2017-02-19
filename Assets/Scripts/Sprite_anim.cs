using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_anim : MonoBehaviour {
	public Sprite[] sprites;
	SpriteRenderer s_rend;
	// Use this for initialization
	void Start () {
		s_rend = gameObject.GetComponent<SpriteRenderer> ();
		s_rend.sprite = sprites [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") != 0) {
			if(Time.fixedTime % 0.1f <= 0.05f)
				s_rend.sprite = sprites [1];
			else
				s_rend.sprite = sprites [2];
		}
		else
			s_rend.sprite = sprites [0];
	}
}
