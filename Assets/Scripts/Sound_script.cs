using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_script : MonoBehaviour {
    private bool exists_audio = false;


    private AudioSource som_bg;

    // Use this for initialization
    void Start () {

        if (exists_audio == false)
        {
            som_bg = this.GetComponent<AudioSource>();
            som_bg.Play();
            exists_audio = true;
            DontDestroyOnLoad(this);

        }
    }
	
}
