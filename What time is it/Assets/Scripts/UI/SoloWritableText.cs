using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoloWritableText : MonoBehaviour
{
    [SerializeField] private float _writingSpeed;
    [SerializeField] private float _delayTime;

    private TextMeshProUGUI _textTMP;
    private List<string> CurrentPhrases;
    
    private Coroutine _currentRoutine;

    private void OnEnable()
    {
        _textTMP = GetComponent<TextMeshProUGUI>();
    }
    
    protected void StartWriting(List<string> phrases)
    {
        if (_textTMP == null || _currentRoutine != null)
            return;
        
        CurrentPhrases = phrases;

        _currentRoutine = StartCoroutine(WritePhrases(CurrentPhrases));
    }

    private IEnumerator WritePhrases(List<string> phrases)
    {
        string phrase = String.Empty;
        
        foreach (string currentPhrase in phrases)
        {
            phrase = String.Empty;
            ReloadText(phrase);
            
            foreach (char letter in currentPhrase)
            {
                phrase += letter;
                ReloadText(phrase);

                yield return new WaitForSeconds(_writingSpeed);
            }
            
            yield return new WaitForSeconds(_delayTime * phrase.Length);
        }

        string newPhrase = phrase;

        for (int i = phrase.Length - 1; i > 0; i--)
        {
            newPhrase = phrase[..i];
            ReloadText(newPhrase);
            
            yield return new WaitForSeconds(_writingSpeed);
        }
        
        ReloadText(String.Empty);

        _currentRoutine = null;
    }

    private void ReloadText(string currentString)
    {
        _textTMP.text = currentString;
    }
}
