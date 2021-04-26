using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    CharacterController cc;
    public Transform parentPos;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }     
    }
    void Respawn()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            //Debug.Log("Respawn");

            cc.enabled = false;
            parentPos.position = new Vector3(0, 0, 0);
            cc.enabled = true;
        }
    }
}
