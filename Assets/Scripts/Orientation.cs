using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public float sens = 50;
    public Transform camTransform;
    float camRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveCharacter.gravityChange)
        {
            float mouseX = -Input.GetAxis("Mouse X") * sens * Time.deltaTime;
            //transform.Rotate(new Vector3(transform.rotation.x, mouseX, transform.rotation.z));
            yRotation += mouseX;
            float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
            camRotation += mouseY;
            camRotation = Mathf.Clamp(camRotation, -30, 30);
            transform.localRotation = Quaternion.Euler(camRotation, yRotation, 0);
        }
        else
        {
            float mouseX = -Input.GetAxis("Mouse X") * sens * Time.deltaTime;
            transform.Rotate(new Vector3(transform.rotation.x, mouseX, transform.rotation.z));
            float mouseY = -Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
            camRotation += mouseY;
            camRotation = Mathf.Clamp(camRotation, -80f, 90f);
            camTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, transform.rotation.y, transform.rotation.z));
        }
    }
}
