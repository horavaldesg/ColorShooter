using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCubeManager : MonoBehaviour
{
    public enum colorChoice {Magenta, Cyan, Yellow};
    [Header("Change Color Pickup to Desired Color, Script Will take care of the rest")]
    public colorChoice ColorPickup;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        TryGetComponent(out meshRenderer);
        if(!meshRenderer)return;
        switch (ColorPickup)
        {
            case colorChoice.Magenta:
                meshRenderer.material.color = Color.magenta;
                break;
            case colorChoice.Cyan:
                meshRenderer.material.color = Color.cyan;
                break;
            case colorChoice.Yellow:
                meshRenderer.material.color = Color.yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Color CurrentColor()
    {
        return meshRenderer.material.color;

    }
}
