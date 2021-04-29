using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReSpawn : MonoBehaviour
{
    GameObject[] respawnChildren;

    CharacterController cc;
    public Transform parentPos;
    // Start is called before the first frame update
    void Start()
    {
        respawnChildren = GameObject.FindGameObjectsWithTag("DieSplatter");
        foreach(GameObject children in respawnChildren)
        {
            children.SetActive(false);
        }
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
            StartCoroutine(respawnAnim());
            parentPos.position = new Vector3(0, 0, 0);
            cc.enabled = true;
            //Debug.Log("Respawn");


        }
    }
    IEnumerator respawnAnim()
    {
        cc.enabled = false;
        GameObject respawnObj = GameObject.FindGameObjectWithTag("Die");
        respawnObj.SetActive(true);
        respawnObj.GetComponent<Animator>().enabled = true;
        foreach (GameObject children in respawnChildren)
        {
            children.GetComponent<Image>().color = Color.black;
        }
        respawnObj.GetComponent<Animator>().Play("DeathTransition");
        yield return new WaitForSeconds(1.5f);
        respawnObj.GetComponent<Animator>().enabled = false;
        foreach (GameObject children in respawnChildren)
        {
            children.SetActive(false);
        }
    }
}
