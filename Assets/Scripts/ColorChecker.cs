using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{

    //    if (hit.collider.gameObject.GetComponent<Renderer>().material.color != null &&
    //        hit.collider.gameObject.name != "XLeft" &&
    //        hit.collider.gameObject.name != "XRight" &&
    //        hit.collider.gameObject.name != "ZLeft" &&
    //        hit.collider.gameObject.name != "ZRight" &&
    //        hit.collider.gameObject.name != "YTop" &&
    //        hit.collider.gameObject.name != "YBottom")
    //        Debug.Log(hit.collider.name);
    //    {
    //        if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
    //        {
    //            moveCharacter.fast = true;
    //            moveCharacter.jump = false;
    //            moveCharacter.gravityChange = false;

    //            Debug.Log("Magenta");
    //        }
    //        else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.cyan)
    //        {
    //            moveCharacter.jump = true;
    //            moveCharacter.fast = false;
    //            moveCharacter.gravityChange = false;


    //            Debug.Log("Cyan");
    //        }
    //        else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
    //        {
    //            //moveCharacter.gravityChange = true;
    //            moveCharacter.jump = false;
    //            moveCharacter.fast = false;
    //            Debug.Log("Yellow");
    //        }
    //        else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
    //        {
    //            Debug.Log("Black");
    //        }
    //        else
    //        {
    //            moveCharacter.jump = false;
    //            moveCharacter.fast = false;
    //            moveCharacter.gravityChange = false;

    //        }
    //        Debug.Log(hit.gameObject.GetComponent<Renderer>().material.color);

    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "YTop")
        {
            GetComponentInParent<moveCharacter>().grounded = true;
        }
        //if (other.CompareTag("Player"))
        //{
        Debug.Log("Player");
        if (other.gameObject.GetComponent<Renderer>().material.color != null &&
            other.gameObject.name != "XLeft" &&
            other.gameObject.name != "XRight" &&
            other.gameObject.name != "ZLeft" &&
            other.gameObject.name != "ZRight" &&
            other.gameObject.name != "YTop" &&
            other.gameObject.name != "YBottom")
            Debug.Log(other.name);
        {
            //Fast
            if (other.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
            {
                moveCharacter.fast = true;
                moveCharacter.jump = false;
                moveCharacter.gravityChange = false;

                Debug.Log("Magenta");
            }
            //Jump
             if (other.gameObject.GetComponent<Renderer>().material.color == Color.cyan)
            {

                GetComponentInParent<moveCharacter>().verticalSpeed = GetComponentInParent<moveCharacter>().jumpSpeed;
                moveCharacter.fast = false;
                moveCharacter.gravityChange = false;


                Debug.Log("Cyan");
            }
            //Gravity
             if (other.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
            {
                //moveCharacter.gravityChange = true;
                moveCharacter.jump = false;
                moveCharacter.fast = false;
                Debug.Log("Yellow");
            }
             if (other.gameObject.GetComponent<Renderer>().material.color == Color.black)
            {
                Debug.Log("Black");
            }
            else
            {
                moveCharacter.jump = false;
                moveCharacter.fast = false;
                moveCharacter.gravityChange = false;

            }
            //Debug.Log(other.gameObject.GetComponent<Renderer>().material.color);

        }

        //}
    }
}
