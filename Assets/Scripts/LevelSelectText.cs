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
    private void Awake()
    {
        TryGetComponent(out _textMeshProUGUI);
        if(!_textMeshProUGUI) return;
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
    }
/*
private void OnDisable()
    {
        TriggerLevelText.ShowLevelText -= ShowLevel;
    }
    */

    private void DisplayLevel()
    {
        _textMeshProUGUI.SetText(SceneManager.GetActiveScene().name);
    }

    private void ShowLevel()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for(var i = (int)_faceColor.a + 1; i < 254; i++)
        {
            yield return new WaitForSeconds(0.02f);

            _faceColor.a += 0.053f;
            _outlineColor.a += 0.035f;
            _textMeshProUGUI.faceColor = _faceColor;
            _textMeshProUGUI.outlineColor = _outlineColor;
        }

        yield return new WaitForSeconds(0.1f);
        //_faceColor.a += 0.05f;

        //  yield return new WaitWhile(() => _faceColor.a <= 255);
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
