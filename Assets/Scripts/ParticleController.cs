using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem shootPart;
    public GameObject brush;

    // Start is called before the first frame update
    void Start()
    {
        shootPart.Stop();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootPart.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            shootPart.Stop();
        }

        if (shootPart.IsAlive(false))
        {
            //Debug.Log("DEAD");

            //var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(Ray, out hit))
            //{
            //    var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
            //    //go.transform.localScale = Vector3.one * BrushSize;
            //}
        }

        if (shootPart.IsAlive(true))
        {
            //Debug.Log("ALIVE");
        }
    }
}
