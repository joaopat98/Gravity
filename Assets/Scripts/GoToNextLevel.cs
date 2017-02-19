using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {
	public int num_keys;
	int curr_keys = 0;

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter2D(Collider2D obj)
    {
		if (obj.tag == "Key") {
			Destroy (obj.gameObject);	
			curr_keys++;
		}
		else if (obj.tag == "End" && curr_keys == num_keys)
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
