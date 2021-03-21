using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    public Texture2D splashTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        MyShaderBehavior script = collision.collider.GetComponent<MyShaderBehavior>();
        script.PaintOn(moveCharacter.coord, splashTexture);
        Destroy(gameObject);
    }
}
