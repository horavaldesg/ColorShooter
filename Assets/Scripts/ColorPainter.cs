using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorPainter : MonoBehaviour
{
    public bool magenta;
    public bool cyan;
    public bool yellow;
    public bool black;
    public Transform camTransform;
    [SerializeField] float ammo;
    [SerializeField] float depletionAmmo;
    public GameObject brush;
    [SerializeField] Material splatter;
    [SerializeField] Material part;
    public float BrushSize = 0.1f;
    Color color;
    [SerializeField] Image img;
    // Start is called before the first frame update
    void Start()
    {
        color = Color.magenta;
        img.color = color;
        part.color = color;

    }

    // Update is called once per frame
    void Update()
    {
        if (magenta)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                color = Color.magenta;
                part.color = color;
                img.color = color;
                //splatter.color = color;

            }
        }
        if (cyan)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                color = Color.cyan;
                part.color = color;
                img.color = color;
                //splatter.color = color;

            }
        }
        if (yellow)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                color = Color.yellow;
                part.color = color;
                img.color = color;
                //splatter.color = color;
            }
        }
        if (black)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                color = Color.black;
                part.color = color;
                img.color = color;
                //splatter.color = color;
            }
        }
        if (ammo > 0)
        {
            if (Input.GetMouseButton(0))
            {

                RaycastHit hit;
                if (Physics.Raycast(camTransform.transform.position, camTransform.forward, out hit))
                {
                    if (color != Color.black)
                    {
                        brush.tag = "Splatter";
                        brush.layer = 10;
                        if (hit.collider.tag != "Splatter" && hit.collider.tag != "Player" && hit.collider.tag != "Button")
                        {
                            ammo -= depletionAmmo;
                            if (hit.collider.gameObject.name == "XLeft")
                            {
                                //Debug.Log("X Left");

                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(90, 0, 0), transform);
                                go.GetComponent<Renderer>().material.color = color;

                            }
                            else if (hit.collider.gameObject.name == "XRight")
                            {
                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0), transform);
                                go.GetComponent<Renderer>().material.color = color;

                                //Debug.Log("X Right");
                            }
                            else if (hit.collider.gameObject.name == "ZLeft")
                            {
                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 90), transform);
                                go.GetComponent<Renderer>().material.color = color;

                                //Debug.Log("Z Left");
                            }
                            else if (hit.collider.gameObject.name == "ZRight")
                            {
                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, -90), transform);
                                go.GetComponent<Renderer>().material.color = color;
                                //Debug.Log("Z Right");
                            }
                            else if (hit.collider.gameObject.name == "YTop")
                            {
                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 0), transform);
                                go.GetComponent<Renderer>().material.color = color;
                                //Debug.Log("Y Top");
                            }
                            else if (hit.collider.gameObject.name == "YBottom")
                            {
                                var go = Instantiate(brush, hit.point - Vector3.up * 0.1f, Quaternion.Euler(180, 0, 0), transform);
                                go.GetComponent<Renderer>().material.color = color;
                                //Debug.Log("Y Bottom");
                            }
                            else
                            {
                                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0, 0, 0), transform);
                                go.GetComponent<Renderer>().material.color = color;

                            }
                        }
                    }
                    else if (color == Color.black)
                    {
                        if (hit.collider.tag == "Splatter" && hit.collider.tag != "Player" && hit.collider.tag != "Button" && hit.collider.gameObject.layer != 8)
                        {
                            hit.collider.GetComponent<Renderer>().material.color = color;
                        }
                    }
                    //go.transform.localScale = Vector3.one * BrushSize;
                }
            }
        }
    }
}
    

