using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {
    public Camera mainCamera;
    public Texture2D splashTexture;

    private void Update ()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out var hit)) return;
        var script = hit.collider.gameObject.GetComponent<MyShaderBehavior>();
        if (null != script)
            script.PaintOn(hit.textureCoord, splashTexture);
    }
}
