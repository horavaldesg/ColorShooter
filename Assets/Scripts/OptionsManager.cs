using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
  [SerializeField] private GameObject optionsMenu;
  [SerializeField] private mouseLook m_MouseLook;

  private void Start()
  {
    optionsMenu.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      optionsMenu.SetActive(!optionsMenu.activeSelf);
      Time.timeScale = optionsMenu.activeSelf ? 0 : 1;
      Cursor.lockState = optionsMenu.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
    }
  }
}
