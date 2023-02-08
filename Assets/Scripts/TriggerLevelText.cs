using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerLevelText : MonoBehaviour
{
   public static event Action ShowLevelText;
   public void ShowLevel()
   {
      ShowLevelText.Invoke();
   }
}
