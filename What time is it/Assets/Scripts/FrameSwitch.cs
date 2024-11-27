using System;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _currentFrame;

    private void Awake()
    {
        HelpSystems.DisableAllFrames += Disable;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        HelpSystems.DisableAllFrames?.Invoke();

        if (!other.CompareTag("Player"))
            return;
        _currentFrame.SetActive(true);

    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _currentFrame.SetActive(false);
    }*/

    private void Disable()
    {
        if (!_currentFrame.activeSelf)
            return;
        _currentFrame.SetActive(false);
    }
}
