using System;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsPoint : MonoBehaviour
{
    [SerializeField] private List<string> Phrases;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Phrases.Count > 0)
        {
            HelpSystems.OpenThoughts(Phrases);
        }
    }
}
