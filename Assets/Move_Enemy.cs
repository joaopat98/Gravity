using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Enemy : MonoBehaviour
{
    public float mov_speed, rot_speed;
    public float minPos, maxPos;

    Vector2 rot = new Vector2(0, 0);
    bool rotating = false;
    bool heading_right = true;

    // Use this for initialization
    void Start()
    {

        //Starts going in a random direction
        /*float[] direcao_inicial = { mov_speed, -mov_speed };
        mov_speed = direcao_inicial[Random.Range(0, 1)];*/

    }
    

    // Update is called once per frame
    void Update()
    {

        Debug.Log(rotating);

        if (rotating == false)
        {

            transform.Translate(new Vector3(mov_speed * Time.deltaTime, 0, 0));

            if (transform.position.x >= maxPos && rot.y == 0)
            {
                //turn left
                rotating = true;
                transform.Translate(new Vector3(0, 0, 0));
            }
            else if (transform.position.x <= minPos && rot.y == 180)
            {
                // turn right
                rotating = true;
                transform.Translate(new Vector3(0, 0, 0));
            }

        }
        else
        {
            if (rot.y < 180 && heading_right== true)
                rot += new Vector2(0, rot_speed * Time.deltaTime);
            else if (rot.y > 0 && heading_right == false)
                rot += new Vector2(0, -rot_speed * Time.deltaTime);

            if (rot.y <= 0)
            {
                rot = new Vector2(0, 0);
                rotating = false;
                heading_right = true;
            }   
            else if (rot.y >= 180)
            {
                rot = new Vector2(0, 180);
                rotating = false;
                heading_right = false;
            }
            transform.eulerAngles = rot;
        }

        

        
            
        

        

    }
}
