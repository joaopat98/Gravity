using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public Canvas button_canvas;
    public Canvas confirm_canvas;
    private bool confirming = false;
    private int index_saved;

    void Update()
    {
        if (confirming == true)
        {
            Debug.Log("inside");
            if(Input.GetButton("Submit") == true)
            {
                SceneManager.LoadScene(index_saved);
            }
            else if(Input.GetButton("Cancel") == true)
            {
                confirming = false;
                confirm_canvas.gameObject.SetActive(false);
            }
            
        }
    }

    public void LoadByIndex(int index)
    {
        
        confirm_canvas.gameObject.SetActive(true);

        Text painel = confirm_canvas.GetComponentInChildren<Text>();

        painel.text = "Deseja continuar para o nivel " + index + "?\n\n\nPressione [Submit] para continuar\nPressione [Cancel] para cancelar";
        index_saved = index;
        confirming = true;
    }
    
}
