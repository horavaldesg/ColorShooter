using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoveScript : MonoBehaviour
{
    public static bool buttonPushed;

    AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (buttonPushed == true)
        {
            doorSound.Play();
            DoorMove();        
        }

        if (buttonPushed == false)
        {
            if (transform.position.y <= 2.37f)
            {
                transform.position += new Vector3(0, +0.01f, 0);
            }

            if (transform.position.y >= 2.37f)
            {
                transform.position += new Vector3(0, 0, 0);
            }
        }
    }

    void DoorMove()
    {
        if (transform.position.y >= -2.52f)
        {
            transform.position += new Vector3(0, -0.01f, 0);
        }
        
        if(transform.position.y <= -2.52f)
        {
            transform.position += new Vector3(0, 0, 0);
        }
    }

}
