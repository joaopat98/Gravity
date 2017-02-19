using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
		if (obj.tag == "Key") {
            Destroy(obj.gameObject);
		}
		else if (obj.tag == "End" && UI_Script.keysLeft() == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex != 16)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {

            }
        }
        	
    }

	// Update is called once per frame
	void Update () {
		
	}
}
