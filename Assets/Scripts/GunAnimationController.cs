using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationController : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("GunShoot", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("GunShoot", false);
        }
    }
}
