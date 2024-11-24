using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private float _dialogueSpeed;
    [SerializeField] private float _delayTime;
    [SerializeField] private TextMeshProUGUI _dialogueTMP;

    private Animator _animator;

    private List<string> CurrentPhrases;

    private Coroutine _currentRoutine;

    private void Awake()
    {
        HelpSystems.StartDialogue += StartDialogue;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void StartDialogue(List<string> phrases)
    {
        if (_currentRoutine != null)
            return;
        
        CurrentPhrases = phrases;
        
        _animator.SetBool("isOpened", true);
    }

    private void AnimationEnded()
    {
        if (CurrentPhrases.Count <= 0)
            return;

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
                
                if (Input.GetMouseButtonDown(0))
                {
                    phrase = currentPhrase;
                    ReloadText(phrase);
                    break;
                }

                yield return new WaitForSeconds(_dialogueSpeed);
            }
            
            yield return new WaitForSeconds(_delayTime * phrase.Length);
        }
        
        ReloadText(String.Empty);
         
        _animator.SetBool("isOpened", false);

        _currentRoutine = null;
    }

    private void ReloadText(string currentString)
    {
        _dialogueTMP.text = currentString;
    }
}
