using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationController : MonoBehaviour
{
    Animator anim;
    AudioSource spraySound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spraySound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("GunShoot", true);
            spraySound.Play();
            //spraySound.loop = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("GunShoot", false);
            spraySound.Pause();
            //spraySound.loop = false;
        }
    }
}
