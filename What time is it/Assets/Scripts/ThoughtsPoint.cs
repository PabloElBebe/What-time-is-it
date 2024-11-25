using System;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsPoint : MonoBehaviour
{
    [SerializeField] private List<string> Phrases;
    [SerializeField] private bool _isDestroy;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Phrases.Count > 0)
        {
            HelpSystems.OpenThoughts(Phrases);
        }
        
        if (!_isDestroy)
            return;
        
        Destroy(gameObject);
    }
}
