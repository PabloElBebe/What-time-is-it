using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private float _dialogueSpeed;
    [SerializeField] private TextMeshProUGUI _dialogueTMP;

    private Animator _animator;

    private List<string> _currentPhrases;

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
        _currentPhrases = phrases;
        
        _animator.SetBool("isOpened", true);
    }

    private void AnimationEnded()
    {
        if (_currentPhrases.Count <= 0)
            return;

        StartCoroutine(WritePhrases(_currentPhrases));
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

                yield return new WaitForSeconds(_dialogueSpeed);
            }
            
            yield return new WaitForSeconds(2);
        }
        
        ReloadText(String.Empty);
         
        _animator.SetBool("isOpened", false);
    }

    private void ReloadText(string currentString)
    {
        _dialogueTMP.text = currentString;
    }
}
