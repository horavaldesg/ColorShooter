using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVCopyScript : MonoBehaviour
{
    public GameObject brush;
    public float BrushSize = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                if (hit.collider.tag != "Splatter")
                {
                    if (hit.collider.gameObject.name == "XLeft")
                    {
                        Debug.Log("X Left");

                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(90, 0, 0), transform);
                    }
                    else if(hit.collider.gameObject.name == "XRight")
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0), transform);

                        Debug.Log("X Right");
                    }
                    else if(hit.collider.gameObject.name == "ZLeft")
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 90), transform);

                        Debug.Log("Z Left");
                    }
                    else if(hit.collider.gameObject.name == "ZRight")
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, -90), transform);
                        Debug.Log("Z Right");
                    }
                    else if(hit.collider.gameObject.name == "YTop")
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 0), transform);
                        Debug.Log("Y Top");
                    }
                    else if(hit.collider.gameObject.name == "YBottom")
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(180, 0, 0), transform);
                        Debug.Log("Y Bottom");
                    }
                    else
                    {
                        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 0), transform);

                    }
                }

                //go.transform.localScale = Vector3.one * BrushSize;
            }
        }
    }
}
