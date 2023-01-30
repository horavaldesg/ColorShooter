using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public FloatVal sens;
    public Transform camTransform;
    float camRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Rotation
        
        if (!moveCharacter.gravityChange)
        {
            var mouseX = Input.GetAxis("Mouse X") * sens.val * Time.deltaTime * 10;
            transform.Rotate(new Vector3(transform.rotation.x, mouseX, transform.rotation.z));
            var mouseY = -Input.GetAxis("Mouse Y") * sens.val * Time.deltaTime * 10;
            camRotation += mouseY;
            camRotation = Mathf.Clamp(camRotation, -80f, 90f);
            camTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, transform.rotation.y, transform.rotation.z));
        }
        else
        {
            var mouseX = -Input.GetAxis("Mouse X") * sens.val * Time.deltaTime * 10;
            transform.Rotate(new Vector3(transform.rotation.x, mouseX, transform.rotation.z));
            var mouseY = -Input.GetAxis("Mouse Y") * sens.val * Time.deltaTime * 10;
            camRotation += mouseY;
            camRotation = Mathf.Clamp(camRotation, -80f, 90f);
            camTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, transform.rotation.y, transform.rotation.z));
        }
        //camTransform.Rotate(new Vector3(mouseY, 0, 0));
    }

    public string GetSens()
    {
        return sens.ToString();
    }
}
