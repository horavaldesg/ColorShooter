using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    public Texture2D splashTexture;
  
 
    private void OnCollisionEnter(Collision collision)
    {
        var script = collision.collider.GetComponent<MyShaderBehavior>();
        script.PaintOn(moveCharacter.coord, splashTexture);
        Destroy(gameObject);
    }
}
