using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour {
    private bool exists_audio = false;

    private Text level;
    private AudioSource som_bg;

    private int level_keys;
    private int current_keys = 0;

    // Use this for initialization
    void Start () {
        level = this.GetComponentInChildren<Text>();
        
        if (exists_audio == false)
        {
            som_bg = this.GetComponent<AudioSource>();
            som_bg.Play();
            exists_audio = true;
            DontDestroyOnLoad(this);
            
        }

        level_keys = (GameObject.FindGameObjectsWithTag("Key")).Length;
    }
	
	// Update is called once per frame
	void Update () {
        level.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex;


        //GameObject son = this.GetComponentInChildren<RectTransform>().gameObject;
        //son.GetComponentInChildren<Text>().text = 3.ToString();
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(2);
        }


    }
}
