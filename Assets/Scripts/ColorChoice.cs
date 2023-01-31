using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

public class ColorChoice : MonoBehaviour
{
   
    public Color CurrentColor()
    {
        TryGetComponent(out MeshRenderer meshRenderer);
        return meshRenderer.material.color;
    }
}
