using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorType : ScriptableObject
{
    public enum colorChoice {Magenta, Cyan, Yellow};
    [Header("Change Color Pickup to Desired Color, Script Will take care of the rest")]
    public colorChoice ColorPickup;
}
