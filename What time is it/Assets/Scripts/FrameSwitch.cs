using System;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _currentFrame;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _currentFrame.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _currentFrame.SetActive(false);
    }
}
