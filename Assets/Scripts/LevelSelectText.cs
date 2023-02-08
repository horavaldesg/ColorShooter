using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelSelectText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private Color _faceColor;
    private Color _outlineColor;
    private float _t;
    private bool _showText;
    private RectTransform _anchor;

    private void Awake()
    {

        _anchor = GetComponent<RectTransform>();
        _anchor.anchorMax = new Vector2(_anchor.anchorMax.x, 0.5f);
        _anchor.anchorMin = new Vector2(_anchor.anchorMin.x, 0.5f);
        _anchor.localPosition = new Vector2(_anchor.localPosition.x, 0);
        

        TryGetComponent(out _textMeshProUGUI);
        if (!_textMeshProUGUI) return;
        _showText = false;
        _faceColor = _textMeshProUGUI.faceColor;
        _outlineColor = _textMeshProUGUI.outlineColor;
        _faceColor.a = 0;
        _textMeshProUGUI.faceColor = _faceColor;
        _outlineColor.a = 0;
        _textMeshProUGUI.outlineColor = _outlineColor;
        DisplayLevel();
    }
    
    private void OnEnable()
    {
        TriggerLevelText.ShowLevelText += ShowLevel;
        TriggerLevelText.HideLevelText += HideLevel;
        
    }

    private void OnDisable()
    {  
        TriggerLevelText.ShowLevelText -= ShowLevel;
        TriggerLevelText.HideLevelText -= HideLevel;
    }


    private void DisplayLevel()
    {
        _textMeshProUGUI.SetText(SceneManager.GetActiveScene().name);
        StartCoroutine(ShowText());
    }

    private void ShowLevel()
    {
        StartCoroutine(HideText());
    }
    private void HideLevel()
    {
       StartCoroutine(ChangePos());
    }

    private IEnumerator ShowText()
    {

        for (var i = _faceColor.a + 1; i < 256; i+= 0.1f)
        {
            yield return new WaitForSeconds(0.02f);

            _faceColor.a += 0.053f;
            _outlineColor.a += 0.035f;
            _textMeshProUGUI.faceColor = _faceColor;
            _textMeshProUGUI.outlineColor = _outlineColor;

        }

      

        yield return null;
       
    }

    private IEnumerator ChangePos()
    {
        Debug.Log("hide");
        
        
        for (float f = _textMeshProUGUI.faceColor.a; _textMeshProUGUI.outlineColor.a > 0; f--)
        {
            yield return new WaitForSeconds(0.02f);

            _faceColor.a -= 0.053f;
            _outlineColor.a -= 0.035f;
            _textMeshProUGUI.faceColor = _faceColor;
            _textMeshProUGUI.outlineColor = _outlineColor;

        }
        _anchor.pivot = new Vector2(_anchor.pivot.x, 1);
        
            yield return new WaitForSeconds(0.05f);
            _anchor.anchorMax = new Vector2(_anchor.anchorMax.x, 1);
            _anchor.anchorMin = new Vector2(_anchor.anchorMin.x, 1);
           
        yield return null;
        
    }

    private IEnumerator HideText()
    {
        Debug.Log("hide");
        
        
        for (float f = _textMeshProUGUI.faceColor.a; _textMeshProUGUI.outlineColor.a > 0; f--)
        {
            yield return new WaitForSeconds(0.02f);

            _faceColor.a -= 0.053f;
            _outlineColor.a -= 0.035f;
            _textMeshProUGUI.faceColor = _faceColor;
            _textMeshProUGUI.outlineColor = _outlineColor;

        }

        yield return null;

    }



    private void Update()
    {
        /*_t += Time.deltaTime;
        if (_t < 0.5f) return;*/
        /*if(!_showText) return;
        if (!(_faceColor.a <= 255)) return;
        _faceColor.a += 0.005f;
        _textMeshProUGUI.faceColor = _faceColor;
        _outlineColor.a += 0.005f;
        _textMeshProUGUI.outlineColor = _outlineColor;
        _t = 0;*/
    }
}
