using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoveScript : MonoBehaviour
{
    public static bool buttonPushed;
    [SerializeField]AudioClip clip;
    AudioSource doorSound;
    bool playSound;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        playSound = false;
        buttonPushed = false;
        doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (buttonPushed == true)
        {
           
            DoorMove();
            if (i == 0)
            {
                playSound = true;
            }
            i += Time.deltaTime;

        }

        //if (buttonPushed == false)
        //{
        //    if (transform.position.y <= 2.37f)
        //    {
        //        transform.position += new Vector3(0, +0.01f, 0);
        //    }

        //    if (transform.position.y >= 2.37f)
        //    {
        //        transform.position += new Vector3(0, 0, 0);
        //    }
        //}
    }

    void DoorMove()
    {
        if (playSound)
        {
            if (i > 0)
            {
                playSound = false;
            }
            StartCoroutine(PlaySound());
        }
        
        if (transform.position.y >= -2.52f)
        {
            transform.position += new Vector3(0, -0.01f, 0);
        }

        if (transform.position.y <= -2.52f)
        {
            transform.position += new Vector3(0, 0, 0);
        }

    }
   
    IEnumerator PlaySound()
    {
        
        doorSound.PlayOneShot(clip);
       
        yield return new WaitForSeconds(clip.length);
    }

}
