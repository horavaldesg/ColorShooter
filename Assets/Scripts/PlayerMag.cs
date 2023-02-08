using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMag : MonoBehaviour
{
    public enum colorChoice {Magenta, Cyan, Yellow};
    [Header("Change Color Pickup to Desired Color, Script Will take care of the rest")]
    public ColorType.colorChoice ColorPickup;
    public MeshRenderer[] meshRenderer;
    [SerializeField] private ColorPainter colorPainter;
    private void Awake()
    {
        gameObject.tag = "Pickup";
        foreach (var t in meshRenderer)
        {
            if (!t) return;
            switch (ColorPickup)
            {
                case ColorType.colorChoice.Magenta:
                    t.materials[1].color = Color.magenta;
                    colorPainter.ChangeColor(Color.magenta);

                    break;
                case ColorType.colorChoice.Cyan:
                    t.materials[1].color = Color.cyan;
                    colorPainter.ChangeColor(Color.cyan);

                    break;
                case ColorType.colorChoice.Yellow:
                    t.materials[1].color = Color.yellow;
                    colorPainter.ChangeColor(Color.yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        

    }

    public ColorType.colorChoice ColorChoice()
    {
        return ColorPickup;
    }

    public void ChangeColor(ColorType.colorChoice colorChoice)
    {
        ColorPickup = colorChoice;
        foreach (var t in meshRenderer)
        {
            if (!t) return;
            switch (ColorPickup)
            {
                case ColorType.colorChoice.Magenta:
                    t.materials[1].color = Color.magenta;
                    colorPainter.ChangeColor(Color.magenta);

                    break;
                case ColorType.colorChoice.Cyan:
                    t.materials[1].color = Color.cyan;
                    colorPainter.ChangeColor(Color.cyan);

                    break;
                case ColorType.colorChoice.Yellow:
                    t.materials[1].color = Color.yellow;
                    colorPainter.ChangeColor(Color.yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
