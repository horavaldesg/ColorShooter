using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class OptionsManager : MonoBehaviour
{
  [SerializeField] private GameObject optionsMenu;
  [SerializeField] private mouseLook m_MouseLook;
  [SerializeField] private TMP_InputField m_TMPInputField;
  [SerializeField] private FloatVal sensitivity;
  [SerializeField] private GameObject levelSelectorButton;
  [SerializeField] private Transform selectorParent; 
  private List<string> _levelNames = new List<string>();

  private void Awake()
  {
    for (var i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
    {
      var sceneName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
      _levelNames.Add(sceneName);
    }
  }

  private void Start()
  {
    optionsMenu.SetActive(false);
    m_TMPInputField.placeholder.GetComponent<TextMeshProUGUI>().SetText(sensitivity.val.ToString());
   
    foreach (var t in _levelNames)
    {
      CreateLevelMenu(t);
    }
  }

  private void OnEnable()
  {
    m_TMPInputField.onValueChanged.AddListener(delegate {ChangeSens(m_TMPInputField);  });
  }

  private void ChangeSens(TMP_InputField newSens)
  {
    float.TryParse(m_TMPInputField.text, out var sens);
    sensitivity.val = sens;
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

  private void CreateLevelMenu(string levelName)
  {
    var levelButton = Instantiate(levelSelectorButton, selectorParent);
    levelButton.transform.parent = selectorParent;
    levelButton.TryGetComponent(out LevelSelectorButton levelSelectorButtonComp);
    levelSelectorButtonComp.SetText(levelName);
  }
}
