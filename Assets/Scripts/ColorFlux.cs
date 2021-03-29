using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlux : MonoBehaviour
{
    public Material RainbowMat;
    private MeshRenderer mr;

    public float rainbowSpeed;
    float hue;
    float sat;
    float bri;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color.RGBToHSV(mr.material.color, out hue, out sat, out bri);
        hue += rainbowSpeed / 10000;
        if(hue >= 1)
        {
            hue = 0;
        }
        sat = 1;
        bri = 1;
        mr.material.color = Color.HSVToRGB(hue, sat, bri);
    }
}
