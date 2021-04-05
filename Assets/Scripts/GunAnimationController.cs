using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationController : MonoBehaviour
{
    Animator anim;
    AudioSource spraySound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spraySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("GunShoot", true);
            spraySound.Play();
            spraySound.loop = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("GunShoot", false);
            spraySound.Pause();
            spraySound.loop = false;
        }
    }
}
