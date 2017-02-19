using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour {
    
    private Text level;

    private int level_keys;
    private int current_keys;
    private int obtained_keys = 0;

    // Use this for initialization
    void Start () {
        level = this.GetComponentInChildren<Text>();
        
        level_keys = keysLeft();
        current_keys = level_keys;
    }
	
	// Update is called once per frame
	void Update () {
        level.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex;

        current_keys = keysLeft();
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

    public static int keysLeft()
    {
        return (GameObject.FindGameObjectsWithTag("Key")).Length;
    }
}
