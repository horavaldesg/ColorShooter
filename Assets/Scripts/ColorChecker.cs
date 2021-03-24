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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.GetComponent<Renderer>().material.color != null &&
            hit.collider.gameObject.name != "XLeft" &&
            hit.collider.gameObject.name != "XRight" &&
            hit.collider.gameObject.name != "ZLeft" &&
            hit.collider.gameObject.name != "ZRight" &&
            hit.collider.gameObject.name != "YTop" &&
            hit.collider.gameObject.name != "YBottom")
            Debug.Log(hit.collider.name);
        {
            if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
            {
                moveCharacter.fast = true;
                moveCharacter.jump = false;
                moveCharacter.gravityChange = false;

                Debug.Log("Magenta");
            }
            else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.cyan)
            {
                moveCharacter.jump = true;
                moveCharacter.fast = false;
                moveCharacter.gravityChange = false;


                Debug.Log("Cyan");
            }
            else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
            {
                moveCharacter.gravityChange = true;
                moveCharacter.jump = false;
                moveCharacter.fast = false;
                Debug.Log("Yellow");
            }
            else if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.black)
            {
                Debug.Log("Black");
            }
            else
            {
                moveCharacter.jump = false;
                moveCharacter.fast = false;
                moveCharacter.gravityChange = false;

            }
            Debug.Log(hit.gameObject.GetComponent<Renderer>().material.color);

        }

    }
}
