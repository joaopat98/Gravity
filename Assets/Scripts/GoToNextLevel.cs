﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter2D(Collider2D player)
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextIndex < 16)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {

        }

        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
