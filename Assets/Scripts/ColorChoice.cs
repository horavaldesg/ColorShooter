using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

public class ColorChoice : MonoBehaviour
{
    [SerializeField] private ColorType.colorChoice _colorChoice;

    private void Awake()
    {
        TryGetComponent(out MeshRenderer meshRenderer);
        switch (_colorChoice)
        {
            case ColorType.colorChoice.Magenta:
                meshRenderer.material.color = Color.magenta;
                break;
            case ColorType.colorChoice.Cyan:
                meshRenderer.material.color = Color.cyan;
                break;
            case ColorType.colorChoice.Yellow:
                meshRenderer.material.color = Color.yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Color CurrentColor()
    {
        TryGetComponent(out MeshRenderer meshRenderer);
        return meshRenderer.material.color;
    }
}
