using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
  [SerializeField] private GameObject optionsMenu;

  private void Start()
  {
    optionsMenu.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
  }
}
