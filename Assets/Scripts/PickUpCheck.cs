using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCheck : MonoBehaviour
{
  [SerializeField] private Transform camTransform;
  [SerializeField] private ColorPainter colorPainter;
  [SerializeField] private GameObject pickupText;

  private void Update()
  {
      if (Physics.Raycast(camTransform.position, camTransform.forward, out var hit, 6))
      {
          
          if (hit.collider.CompareTag("Pickup"))
          {
              pickupText.SetActive(true);
              if (Input.GetAxis("Interact") != 1) return;
              hit.collider.TryGetComponent(out PickupCubeManager cubeManager);
              if (!cubeManager) return;
              colorPainter.ChangeColor(cubeManager.CurrentColor());
             
          }
          else
          {
              pickupText.SetActive(false);

          }
      }
      
  }
}
