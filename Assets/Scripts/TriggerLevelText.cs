using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerLevelText : MonoBehaviour
{
   public static event Action ShowLevelText;
   public static event Action HideLevelText;
   public void ShowLevel()
   {
      ShowLevelText.Invoke();
      StartCoroutine(Hide());
   }

   private IEnumerator Hide()
   {      
      HideLevelText.Invoke();

      yield return new WaitForSeconds(0.8f);
   }
}
