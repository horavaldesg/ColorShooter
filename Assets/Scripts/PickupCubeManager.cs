using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCubeManager : MonoBehaviour
{
    public enum colorChoice {Magenta, Cyan, Yellow};
    [Header("Change Color Pickup to Desired Color, Script Will take care of the rest")]
    public ColorType.colorChoice ColorPickup;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        gameObject.tag = "Pickup";
        TryGetComponent(out meshRenderer);
        if(!meshRenderer)return;
        switch (ColorPickup)
        {
            case ColorType.colorChoice.Magenta:
                meshRenderer.materials[1].color = Color.magenta;
                break;
            case ColorType.colorChoice.Cyan:
                meshRenderer.materials[1].color = Color.cyan;
                break;
            case ColorType.colorChoice.Yellow:
                meshRenderer.materials[1].color = Color.yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Color CurrentColor()
    {
        return meshRenderer.materials[1].color;

    }
}
