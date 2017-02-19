using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour {
    private bool exists = false;

    private Text level;

    // Use this for initialization
    void Start () {
         level = this.GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        level.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex;

    }
}
