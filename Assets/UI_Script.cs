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
    private int current_keys;
    private int obtained_keys = 0;

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
        current_keys = level_keys;
    }
	
	// Update is called once per frame
	void Update () {
        level.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex;

        current_keys = (GameObject.FindGameObjectsWithTag("Key")).Length;
        obtained_keys = level_keys - current_keys;


        Transform painel = this.transform.GetChild(1).transform;
        for (int i =0; i< painel.childCount; i++)
        {
            GameObject child = painel.GetChild(i).gameObject;
            Debug.Log(child.name);
            if(child.name.Equals("Map Keys"))
            {
                child.GetComponent<Text>().text = current_keys.ToString("D2");
            }
            else if (child.name.Equals("Current Keys"))
            {
                child.GetComponent<Text>().text = obtained_keys.ToString("D2");
            }
        }



    }
}
