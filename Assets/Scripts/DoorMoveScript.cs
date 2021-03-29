﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoveScript : MonoBehaviour
{
    public bool buttonPushed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (buttonPushed == true)
        {
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